using NetworkMapCreator.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkMapCreator.EditorElements
{
    public class SubSegment
    {
        public Line Line;
        public SegmentDirection Direction;

        #region Cache
        public BezierCurve CachedCurvedPath { get; private set; }
        public GraphicsPath CachedBakedCurvedPath { get; private set; }

        public GraphicsPath CachedStepsPath { get; private set; }
        public Point CachedC1 { get; private set; }
        public Point CachedC2 { get; private set; }
        #endregion

        public SubSegment(Line l)
        {
            Line = l;
        }

        public void Invalidate()
        {
            InvalidateCurvedPath();
            InvalidateStepsPath();
        }

        public void InvalidateCurvedPath()
        {
            CachedCurvedPath = null;
        }

        public BezierCurve RecalcCurvedPath(PointF a, PointF m, PointF z)
        {
            CachedCurvedPath = new BezierCurve(new PointF[] { a, m, z });
            CachedBakedCurvedPath = CachedCurvedPath.BakePath(10);

            return CachedCurvedPath;
        }

        public GraphicsPath RecalcBakedCurvedPath(BezierCurve curve, float offset)
        {
            return CachedBakedCurvedPath = curve.BakeOffsetPath(10, offset);
        }

        public void InvalidateStepsPath()
        {
            CachedStepsPath = null;
        }

        public GraphicsPath RecalcStepsPath(Point a, PointF m, Point z, int corner_radius_inner, int corner_radius_outer, Graphics debug_paint_env)
        {
            Point cc1, cc2;
            CachedStepsPath = GetStepsPath(a, m, z, out cc1, out cc2, corner_radius_inner, corner_radius_outer, debug_paint_env);
            CachedC1 = cc1;
            CachedC2 = cc2;

            return CachedStepsPath;
        }

        #region Path generation
        private GraphicsPath GetStepsPath(Point a, PointF m, Point z,
            out Point c1, out Point c2,
            int corner_radius_inner, int corner_radius_outer,
            Graphics debug_paint_env)
        {
            bool horizontal = Math.Abs(z.X - a.X) > Math.Abs(z.Y - a.Y);

            c1 = horizontal ? new Point((int)m.X, a.Y) : new Point(a.X, (int)m.Y);
            c2 = horizontal ? new Point((int)m.X, z.Y) : new Point(z.X, (int)m.Y);

            Point visual_c1a = (new Vector3D(c1) - (new Vector3(c1) - new Vector3(a)).Unit() * corner_radius_inner).ToPoint();
            Point visual_c1b = (new Vector3D(c1) - (new Vector3(c1) - new Vector3(c2)).Unit() * corner_radius_inner).ToPoint();
            Point visual_c2a = (new Vector3D(c2) - (new Vector3(c2) - new Vector3(c1)).Unit() * corner_radius_outer).ToPoint();
            Point visual_c2b = (new Vector3D(c2) - (new Vector3(c2) - new Vector3(z)).Unit() * corner_radius_outer).ToPoint();

            var pa = new GraphicsPath();
            pa.AddLine(a, a); /* because this dumb shit does not support just adding points... */

            if (corner_radius_inner > 0 && new Vector3(visual_c1b).Distance(new Vector3(a)) >= corner_radius_inner * 2)
                AddCornerArc(visual_c1a, visual_c1b, c1, corner_radius_inner, pa, debug_paint_env);
            else
                pa.AddBezier(a, c1, c1, visual_c1b);

            pa.AddLine(visual_c1b, visual_c2a);

            if (corner_radius_outer > 0 && new Vector3(visual_c2a).Distance(new Vector3(z)) >= corner_radius_outer * 2)
                AddCornerArc(visual_c2a, visual_c2b, c2, corner_radius_outer, pa, debug_paint_env);
            else
                pa.AddBezier(visual_c2a, c2, c2, z);

            pa.AddLine(z, z);


            /* DEBUG PRINTING */
            if (Program.Config.DisplayDebugInfo && debug_paint_env != null)
            {
                var b = new SolidBrush(Color.Black);
                debug_paint_env.FillRectangle(b, visual_c1a.X - 3, visual_c1a.Y - 3, 6, 6);
                debug_paint_env.FillRectangle(b, visual_c1b.X - 3, visual_c1b.Y - 3, 6, 6);
                debug_paint_env.FillRectangle(b, visual_c2a.X - 3, visual_c2a.Y - 3, 6, 6);
                debug_paint_env.FillRectangle(b, visual_c2b.X - 3, visual_c2b.Y - 3, 6, 6);
                debug_paint_env.DrawString("c1a", Map.DefaultFont, b, visual_c1a);
                debug_paint_env.DrawString("c1b", Map.DefaultFont, b, visual_c1b);
                debug_paint_env.DrawString("c2a", Map.DefaultFont, b, visual_c2a);
                debug_paint_env.DrawString("c2b", Map.DefaultFont, b, visual_c2b);
            }


            return pa;
        }

        public void AddCornerArc(Point p1, Point p2, Point cp, int radius, GraphicsPath path, Graphics g)
        {
            var vec_p1 = new Vector3D(p1);
            var vec_p2 = new Vector3D(p2);
            var vec_cp = new Vector3D(cp);

            var vec_p1_p2 = vec_p2 - vec_p1;
            var vec_p1_cp = vec_cp - vec_p1;
            var angle = vec_p1_p2.Angle() - vec_p1_cp.Angle();
            bool clockwise = angle > 0 && angle < Math.PI;

            if (Program.Config.DisplayDebugInfo && g != null)
                g.DrawString((int)(angle / Math.PI * 180) + "° = " + (clockwise ? "clockwise" : "counter clockwise"), Map.DefaultFont, new SolidBrush(Color.Green), cp);

            var vec_start_cp = vec_cp - vec_p1;
            var start_angle = (int)(vec_start_cp.Angle() / Math.PI * 180) + (clockwise ? -90 : 90);

            var rect_c1 = (vec_p1 - vec_cp) * 2 + vec_cp;
            var rect_c2 = (vec_p2 - vec_cp) * 2 + vec_cp;
            var rect_pos = new Point((int)Math.Min(rect_c1.X, rect_c2.X), (int)Math.Min(rect_c1.Y, rect_c2.Y));

            var rect = new Rectangle(rect_pos, new Size(radius * 2, radius * 2));

            if (Program.Config.DisplayDebugInfo && g != null)
            {
                g.DrawString(start_angle + "°", Map.DefaultFont, new SolidBrush(Color.Red), new Point(cp.X, cp.Y + 20));
                g.DrawRectangle(new Pen(Color.Blue), rect);
            }

            path.AddArc(rect, start_angle, clockwise ? 90.0f : -90.0f);
        }
        #endregion

        #region ASCII and binary saving
        public XmlElement CreateXml(Map m, XmlDocument doc)
        {
            XmlElement ret = doc.CreateElement(string.Empty, "subsegment", string.Empty);

            int lineid = -1;
            for (var i = 0; i < m.Lines.Count; ++i)
                if (m.Lines[i] == Line)
                    lineid = i;
            if (lineid == -1)
                return null;

            ret.SetAttribute("line", lineid + "");

            if (Direction != SegmentDirection.Default)
                ret.SetAttribute("direction", Direction + "");

            return ret;
        }

        public byte[] CreateBinary(Map m, List<Station> stations)
        {
            return null;
        }
        #endregion
    }

    public enum SegmentDirection
    {
        Default = 0,
        Forward,
        Backward
    }
}
