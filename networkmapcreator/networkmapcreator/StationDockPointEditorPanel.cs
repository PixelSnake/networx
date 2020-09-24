using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    class StationDockPointEditorPanel : Control
    {
        Station Station;
        int left   { get { return Station.SegmentsLeft.Count(); } }
        int top    { get { return Station.SegmentsTop.Count(); } }
        int right  { get { return Station.SegmentsRight.Count(); } }
        int bottom { get { return Station.SegmentsBottom.Count(); } }
        int top_or_bottom { get { return bottom + top; } }
        int left_or_right { get { return left + right; } }
        Point Mouse = new Point(0, 0);

        private Collection<Segment>[] lists;

        Tuple<int, int> hover = new Tuple<int, int>(-1, -1);
        Tuple<int, int> dragging = new Tuple<int, int>(-1, -1);
        Tuple<int, int> drag_offset = new Tuple<int, int>(0, 0);

        public StationDockPointEditorPanel()
        {
            DoubleBuffered = true;
        }

        public void SetStation(Station s)
        {
            Station = s;

            if (s != null)
                lists = new Collection<Segment>[] { Station.SegmentsLeft, Station.SegmentsTop, Station.SegmentsRight, Station.SegmentsBottom };
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Station == null)
                return;

            Mouse = e.Location;

            bool one_is_hovered = false;

            for (int i = 0; i < lists.Count(); ++i)
                for (int j = 0; j < lists[i].Count; ++j)
                {
                    var s = lists[i][j];

                    var p = Station.GetDockingLocation(s);
                    p.X -= Station.Location.X;
                    p.Y -= Station.Location.Y;
                    var lw = (int)(1.8 * s.Width);

                    var w = Station.Width;
                    var h = Station.Height;

                    var x_coefficient = Math.Cos(i * Math.PI / 2);
                    var y_coefficient = -Math.Sin(i * Math.PI / 2);

                    var p1 = new PointF(p.X, p.Y);
                    var p2 = new PointF(
                        (float)(p1.X - this.Width * x_coefficient + lw / 2),
                        (float)(p1.Y + this.Height * y_coefficient) + lw / 2);

                    switch (i)
                    {
                        case 0:
                            if (Mouse.X > Width / 2 - w / 2)
                                break;
                            if (Math.Abs(Mouse.Y - p1.Y * 2 - Height / 2) >= lw)
                                break;
                            one_is_hovered = true;
                            hover = new Tuple<int, int>(i, j);
                            break;

                        case 1:
                            if (Mouse.Y > Height / 2 + h / 2)
                                break;
                            if (Math.Abs(Mouse.X - p1.X * 2 - Width / 2) >= lw)
                                break;
                            one_is_hovered = true;
                            hover = new Tuple<int, int>(i, j);
                            break;

                        case 2:
                            if (Mouse.X < Width / 2 + w / 2)
                                break;
                            if (Math.Abs(Mouse.Y - p1.Y * 2 - Height / 2) >= lw)
                                break;
                            one_is_hovered = true;
                            hover = new Tuple<int, int>(i, j);
                            break;

                        case 3:
                            if (Mouse.Y < Height / 2 - h / 2)
                                break;
                            if (Math.Abs(Mouse.X - p1.X * 2 - Width / 2) >= lw)
                                break;
                            one_is_hovered = true;
                            hover = new Tuple<int, int>(i, j);
                            break;
                    }
                }

            if (!one_is_hovered)
                hover = new Tuple<int, int>(-1, -1);

            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Station == null)
                return;

            dragging = new Tuple<int, int>(hover.Item1, hover.Item2);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (Station == null)
                return;

            dragging = new Tuple<int, int>(-1, -1);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (Station == null)
                return;

            if (hover.Item1 == -1 || hover.Item2 == -1)
                return;

            var l = hover.Item1;
            var i = hover.Item2;
            var seg = lists[l][i];

            var dir = (e.Button == MouseButtons.Left ? 1 : -1);
            if (l % 2 == 1) dir *= -1;

            if (i + dir < 0 || i + dir >= lists[l].Count)
                return;

            lists[l].RemoveAt(i);
            lists[l].Insert(i + dir, seg);
            MoveConnectionOnOtherEndIfPossible(seg, l, dir);

            Form1.ActivePanel.Refresh();
        }

        private void MoveConnectionOnOtherEndIfPossible(Segment seg, int list_id, int dir)
        {
            if (Station == null)
                return;

            var o = Station.OtherEnd(seg);
            Collection<Segment> list = o.GetCorrectList(seg);

            if (o == null)
                return;

            var i = list.IndexOf(seg);
            if (i + dir < 0 || i + dir >= list.Count)
                return;

            list.RemoveAt(i);
            list.Insert(i + dir, seg);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (Station == null)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), Bounds);
                g.DrawString("Select a station in the editor", Map.DefaultFont, new SolidBrush(Color.FromArgb(154, 154, 154)), new Point(10, 10));
                return;
            }

            g.FillRectangle(new SolidBrush(Color.White), Bounds);

            g.TranslateTransform(Width / 2, Height / 2);
            g.ScaleTransform(2, 2);
            
            int w = Station.Width;
            int h = Station.Height;

            for (int i = 0; i < lists.Count(); ++i)
                for (int j = 0; j < lists[i].Count; ++j)
                {
                    var s = lists[i][j];

                    var p = Station.GetDockingLocation(s);
                    p.X -= Station.Location.X;
                    p.Y -= Station.Location.Y;
                    var lw = (int)(1.8 * s.Width);

                    var x_coefficient = Math.Cos(i * Math.PI / 2);
                    var y_coefficient = -Math.Sin(i * Math.PI / 2);

                    var p1 = new PointF(p.X, p.Y);
                    var p2 = new PointF(
                        (float)(p1.X - this.Width * x_coefficient + lw / 2),
                        (float)(p1.Y + this.Height * y_coefficient) + lw / 2);

                    if (hover.Item1 == i && hover.Item2 == j)
                        g.DrawLine(new Pen(Color.FromArgb(0x7F, s.Line.c1), lw), p1, p2);
                    else
                        g.DrawLine(new Pen(s.Line.c1, lw), p1, p2);
                }

            var ge = new System.Drawing.Extended.ExtendedGraphics(g);
            var stationrect = new Rectangle(-w / 2, -h / 2, w, h);
            ge.FillRoundRectangle(new SolidBrush(Color.WhiteSmoke), stationrect, 2);
            ge.DrawRoundRectangle(new Pen(Color.Black, 1), stationrect, 2);

            //g.DrawString(Mouse.X + ", " + Mouse.Y, Backend.DefaultFont, new SolidBrush(Color.Black), Mouse.X - Width / 2, Mouse.Y - Height / 2);
        }
    }
}