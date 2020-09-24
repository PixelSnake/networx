using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapCreator
{
    public class Vector3D
    {
        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3D operator *(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        #region Multiplication operators
        public static Vector3D operator *(Vector3D a, int s)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3D operator *(Vector3D a, float s)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3D operator *(Vector3D a, double s)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3D operator *(int s, Vector3D a)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3D operator *(float s, Vector3D a)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        public static Vector3D operator *(double s, Vector3D a)
        {
            return new Vector3D(a.X * s, a.Y * s, a.Z * s);
        }
        #endregion

        public static Vector3D operator /(Vector3D a, int s)
        {
            return new Vector3D(a.X / s, a.Y / s, a.Z / s);
        }
        public static Vector3D operator /(Vector3D a, float s)
        {
            return new Vector3D(a.X / s, a.Y / s, a.Z / s);
        }
        public static Vector3D operator /(Vector3D a, double s)
        {
            return new Vector3D(a.X / s, a.Y / s, a.Z / s);
        }

        public double X, Y, Z;

        public Vector3D(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D(PointF p)
        {
            X = p.X;
            Y = p.Y;
            Z = 0;
        }

        public Vector3D Unit()
        {
            var a = Abs();

            if (a != 0)
                return new Vector3D(X / a, Y / a, Z / a);
            else
                return new Vector3D(0, 0, 0);
        }

        public double Abs()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public double Distance(Vector3D v)
        {
            double dx = v.X - X;
            double dy = v.Y - Y;
            double dz = v.Z - Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public Vector3D Rotate(double deg)
        {
            var rad = deg / 180 * Math.PI;
            var sin = Math.Sin(rad);
            var cos = Math.Cos(rad);
            var nx = X * cos - Y * sin;
            var ny = X * sin + Y * cos;

            return new Vector3D(nx, ny);
        }

        public Vector3D Revert()
        {
            return new Vector3D(-X, -Y, -Z);
        }

        /* calculates the angle between this vector and v clockwise */
        public double Angle()
        {
            var a = Math.Atan2(Y, X);
            if (a < 0)
                a += 2 * Math.PI;
            return a;
        }


        public Vector3 ToVector3()
        {
            return new Vector3((int)X, (int)Y, (int)Z);
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }

        public override String ToString()
        {
            return "Vector3D { x: " + X + ", y: " + Y + ", z: " + Z + "}";
        }
    }
}
