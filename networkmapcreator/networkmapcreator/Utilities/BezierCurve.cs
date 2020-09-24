using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator.Utilities
{
    public class BezierCurve
    {
        private PointF[] Points;

        public BezierCurve(Point[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException();

            Points = new PointF[points.Length];
            for (int i = 0; i < points.Length; ++i)
                Points[i] = new PointF(points[i].X, points[i].Y);
        }

        public BezierCurve(PointF[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException();

            Points = points;
        }

        public PointF GetPointAt(float percent)
        {
            if (percent < 0.0f || percent > 1.0f)
                throw new ArgumentException();
            if (percent == 0.0f)
                return Points.First();
            if (percent == 1.0f)
                return Points.Last();

            return GetPointInPointCloud(Points, percent);
        }

        private PointF GetPointInPointCloud(PointF[] points, float percentage)
        {
            PointF[] next_cloud = new PointF[points.Length - 1];

            for (int i = 0; i < next_cloud.Length; ++i)
            {
                var dx = points[i + 1].X - points[i].X;
                var dy = points[i + 1].Y - points[i].Y;

                var mx = points[i].X + dx * percentage;
                var my = points[i].Y + dy * percentage;
                next_cloud[i] = new PointF(mx, my);
            }

            if (next_cloud.Length == 1)
                return next_cloud[0];
            else
                return GetPointInPointCloud(next_cloud, percentage);
        }

        public Vector3D GetDerivativeAt(float percent)
        {
            if (Points.Length == 3)
                return GetQuadraticDerivativeAt(percent);
            if (Points.Length == 4)
                return GetCubicDerivativeAt(percent);

            throw new NotImplementedException("Derivatives are only implemented for cubic and quadratic bezier curves");
        }

        private Vector3D GetQuadraticDerivativeAt(float t)
        {
            var P = new Vector3D(Points[0]);
            var Q = new Vector3D(Points[1]);
            var R = new Vector3D(Points[2]);

            /* 2 ( P (t - 1) - 2 Q t + Q + R t) */
            return 2 * (P * (t - 1) - 2 * Q * t + Q + R * t);
        }

        private Vector3D GetCubicDerivativeAt(float t)
        {
            var P = new Vector3D(Points[0]);
            var Q = new Vector3D(Points[1]);
            var R = new Vector3D(Points[2]);
            var S = new Vector3D(Points[3]);

            /* -3P(1-t)² + 3Q(1-t)² - 6Qt(1-t) - 3Rt² + 6Rt(1-t) + 3St² */
            return -3 * P * Math.Pow(1 - t, 2) + 3 * Q * Math.Pow(1 - t, 2) - 6 * Q * t * (1 - t) - 3 * R * Math.Pow(t, 2) + 6 * R * t * (1 - t) + 3 * S * Math.Pow(t, 2) ;
        }

        public float GetLength()
        {
            return GetLengthAtPrecisionStep(1.0f, 1.0f);
        }

        private float GetLengthAtPrecisionStep(float last, float precision, float prev_result = -1.0f)
        {
            var a = GetPointAt(0.0f);
            var b = GetPointAt(last);

            if (prev_result == -1.0f)
            {
                var pdx = b.X - a.X;
                var pdy = b.Y - a.Y;
                prev_result = (float)Math.Sqrt(pdx * pdx + pdy * pdy);
            }

            var split_point = GetPointAt(last / 2.0f);

            var dx_half = split_point.X - a.X;
            var dy_half = split_point.Y - a.Y;
            var dist_half = (float)Math.Sqrt(dx_half * dx_half + dy_half * dy_half);
            var dist_new = 2.0f * dist_half;

            if (dist_new - prev_result < precision)
                return dist_new;
            else
                return 2.0f * GetLengthAtPrecisionStep(last / 2.0f, precision, dist_new);
        }

        public GraphicsPath BakePath(int steps)
        {
            GraphicsPath pa = new GraphicsPath();
            PointF prev_point = Points.First();
            var step = 1.0f / (float)steps;

            for (float i = 0.1f; i < 1.0f; i += step)
            {
                var now_point = GetPointAt(i);
                pa.AddLine(prev_point, now_point);
                prev_point = now_point;
            }

            pa.AddLine(prev_point, Points.Last());

            return pa;
        }

        public GraphicsPath BakeOffsetPath(int steps, float offset)
        {
            GraphicsPath pa = new GraphicsPath();

            PointF prev_point = GetOffsetPoint(0.0f, offset);
            var step = 1.0f / (float)steps;

            for (float i = 0.1f; i < 1.0f; i += step)
            {
                var now_point = GetOffsetPoint(i, offset);
                pa.AddLine(prev_point, now_point);
                prev_point = now_point;
            }

            pa.AddLine(prev_point, GetOffsetPoint(1.0f, offset));

            return pa;
        }

        private PointF GetOffsetPoint(float percentage, float offset)
        {
            var derivative = GetDerivativeAt(percentage).Unit();
            var normal = new Vector3D(-derivative.Y, derivative.X); /* still of length 1 */
            normal = normal * offset;

            return (new Vector3D(GetPointAt(percentage)) + normal).ToPointF();
        }
    }
}
