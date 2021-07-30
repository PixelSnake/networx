using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Collections.ObjectModel;
using NetworkMapCreator.Utilities;

namespace NetworkMapCreator.EditorElements
{
    public enum SegmentLineMode
    {
        Straight = 0,
        Curved,
        Steps,
        Wave
    }

    public enum LineLabelDisplayMode
    {
        Default = 0,
        Yes,
        No
    }

    public class Segment : Undoable, EditorElement
    {
        /* unused, but have to implement it */
        public Point Location { get { return new Point(); } set { } }

        public StyleSet Style;

        public Station Begin, End;
        [Obsolete("A segment doesnt have a Line anymore. Use the Line property of the segments in SubSegments")]
        public Line Line;
        public ObservableCollection<SubSegment> SubSegments = new ObservableCollection<SubSegment>();

        public int Width { get { return _cached_width; } }
        public delegate void WidthChangedEventHandler(Segment sender, int Width);
        public event WidthChangedEventHandler WidthChanged;

        private bool hover = false;
        public bool IsHovered { get { return hover; } }
        public bool IsSelected = false;
        public LineLabelDisplayMode DisplayLineLabel = LineLabelDisplayMode.Default;

        public SegmentLineMode LineMode { get { return _linemode; } set { _linemode = value; LineModeChanged?.Invoke(this, value); } }
        private SegmentLineMode _linemode = SegmentLineMode.Straight;
        public delegate void LineModeChangedEventHandler(Segment sender, SegmentLineMode mode);
        public event LineModeChangedEventHandler LineModeChanged;

        #region Cache
        private int _cached_width = 0;
        #endregion

        // percentage between Begin and End
        public PointF MiddlePoint
        {
            get { return _middlepoint; }
            set
            {
                var x = value.X < 0 ? 0 : value.X > 1 ? 1 : value.X;
                var y = value.Y < 0 ? 0 : value.Y > 1 ? 1 : value.Y;
                _middlepoint = new PointF(x, y);
            }
        }
        private PointF _middlepoint = new PointF(0.5f, 0.5f);
        public PointF MiddlePointA {
            get { return new PointF(Begin.Location.X + MiddlePoint.X * _dx, Begin.Location.Y + MiddlePoint.Y * _dy); }
        }
        public bool IsMiddlePointHover = false;
        private bool middle_point_moving = false;
        private float _dx { get { return End.Location.X - Begin.Location.X; } }
        private float _dy { get { return End.Location.Y - Begin.Location.Y; } }

        public Segment(Station a, Station z, Map m)
        {
            Map.StyleManager.StyleChanged += StyleManager_StyleChanged;
            ReloadStyle();

            LineModeChanged += this_LineModeChanged;
            SubSegments.CollectionChanged += SubSegments_Changed;

            Map = m;

            Begin = a;
            End = z;
            a.AddSegment(this);
            z.AddSegment(this);

            Begin.ObservableLocation.PointChanged += Begin_LocationChanged;
            End.ObservableLocation.PointChanged += End_LocationChanged;

            Map.UndoManager.Push(new UndoAction(UndoActionType.Create, this));
        }

        private void Begin_LocationChanged(object sender, Utilities.ObservablePointChangedEventArgs e)
        {
            foreach (var subseg in SubSegments)
                subseg.Invalidate();
        }

        private void End_LocationChanged(object sender, Utilities.ObservablePointChangedEventArgs e)
        {
            foreach (var subseg in SubSegments)
                subseg.Invalidate();
        }

        private void this_LineModeChanged(Segment sender, SegmentLineMode mode)
        {
            ReloadStyle();
        }

        private void StyleManager_StyleChanged()
        {
            ReloadStyle();
        }

        private void ReloadStyle()
        {
            var selector = "segment";

            if (LineMode != SegmentLineMode.Straight)
                selector += "." + LineMode.ToString().ToLower();

            if (Line != null && Line.IsBright)
                selector += ".bright";

            Style = Map.StyleManager.GetStyle(selector);
        }

        private void SubSegments_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (SubSegment i in e.NewItems)
                        _cached_width += i.Line.Width + Style.Margin.Left * 2;
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (SubSegment i in e.OldItems)
                        _cached_width -= i.Line.Width + Style.Margin.Left * 2;
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (SubSegment i in e.OldItems)
                        _cached_width -= i.Line.Width + Style.Margin.Left * 2;
                    foreach (SubSegment i in e.NewItems)
                        _cached_width += i.Line.Width + Style.Margin.Left * 2;
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    _cached_width = 0;
                    foreach (SubSegment i in SubSegments)
                        _cached_width += i.Line.Width + Style.Margin.Left * 2;
                    break;
            }

            WidthChanged?.Invoke(this, _cached_width);
        }

        public bool MouseMove(MouseEventArgs e)
        {
            float mdx = e.Location.X - Begin.Location.X;
            float mdy = e.Location.Y - Begin.Location.Y;

            int d = (int)new Vector3(e.Location).Distance(new Vector3D(new PointF(MiddlePointA.X, MiddlePointA.Y)).ToVector3());
            IsMiddlePointHover = d < Map.SEGMENT_MIDDLE_POINT_SNAP_DIST && IsSelected;

            if (middle_point_moving && IsSelected)
            {
                MiddlePoint = new PointF(_dx != 0 ? mdx / _dx : 0, _dy != 0 ? mdy / _dy : 0);

                foreach (var subseg in SubSegments)
                    subseg.Invalidate();
            }

            return IsMiddlePointHover;
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (LineMode != SegmentLineMode.Straight)
                middle_point_moving = IsMiddlePointHover;
        }

        public void MouseUp(MouseEventArgs e)
        {
            middle_point_moving = false;
        }

        public bool Select(Rectangle r)
        {
            return Intersection.LineIntersectsRect(Begin.Location, End.Location, r);
        }

        public void SelectionModeChanged(bool selected)
        {
            IsSelected = selected;
        }


        public void Paint(PaintEventArgs e)
        {
            if (SubSegments.Count < 1)
                return;

            switch (LineMode)
            {
                case SegmentLineMode.Straight:
                    PaintAllStraight(e);
                    break;

                case SegmentLineMode.Curved:
                    PaintAllCurved(e);
                    break;

                case SegmentLineMode.Steps:
                    PaintAllSteps(e);
                    break;

                case SegmentLineMode.Wave:
                    PaintAllWave(e);
                    break;
            }

            if (Program.Config.DisplayDebugInfo && IsSelected)
            {
                PaintSegmentDebugInfo(e.Graphics);
            }
        }

        #region Straight painting
        private void PaintAllStraight(PaintEventArgs e)
        {
            Point a = Begin.GetDockingLocation(this);
            Point b = End.GetDockingLocation(this);

            #region Docking point position and offset calculation
            var drawing_params = SegmentDrawingParams.FromStations(Begin, End, _cached_width);
            #endregion

            Point begin, end;
            begin = new Point(a.X + drawing_params.begin_shift_x, a.Y + drawing_params.begin_shift_y);
            end = new Point(b.X + drawing_params.end_shift_x, b.Y + drawing_params.end_shift_y);

            /* we returned earlier, if no lines are present, so Lines[0] definitely exists */
            begin.X += drawing_params.begin_factor_x * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);
            begin.Y += drawing_params.begin_factor_y * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);
            end.X += drawing_params.end_factor_x * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);
            end.Y += drawing_params.end_factor_y * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);

            for (int i = 0; i < SubSegments.Count; ++i)
            {
                DrawStraight(e, SubSegments[i], begin, end);
                begin.X += drawing_params.begin_factor_x * (SubSegments[i].Line.Width + Style.Margin.Left * 2);
                begin.Y += drawing_params.begin_factor_y * (SubSegments[i].Line.Width + Style.Margin.Left * 2);
                end.X += drawing_params.end_factor_x * (SubSegments[i].Line.Width + Style.Margin.Left * 2);
                end.Y += drawing_params.end_factor_y * (SubSegments[i].Line.Width + Style.Margin.Left * 2);
            }
            
            if (Program.Config.DisplayDebugInfo)
            {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(0xFF / 2, Color.Red), Width), a, b);
            }
        }

        private void DrawStraight(PaintEventArgs e, SubSegment seg, Point a, Point b)
        {
            if (!Style.Border.Color.IsNone)
                e.Graphics.DrawLine(new Pen(Style.Border.Color.GetColorAuto(seg.Line.c1), seg.Line.Width + 2), a, b);

            if (!IsSelected)
            {
                if (seg.Line.IsAlternating)
                    new System.Drawing.Extended.ExtendedGraphics(e.Graphics).DrawTwoToneLine(seg.Line.c1, seg.Line.c2, seg.Line.Width, Map.LINE_DASH_LENGTH, a, b);
                else
                    e.Graphics.DrawLine(new Pen(seg.Line.c1, seg.Line.Width), a, b);
            }
            else
                e.Graphics.DrawLine(new Pen(Map.SelectionColor, Map.SELECTED_LINE_WIDTH), a, b);

            DrawLabelOnSegment(e, a, b, seg.Line);
        }
        #endregion

        #region Curved painting
        private void PaintAllCurved(PaintEventArgs e)
        {
            Point a = Begin.GetDockingLocation(this);
            Point b = End.GetDockingLocation(this);

            var angle = (new Vector3D(b) - new Vector3D(a)).Angle();
            var switch_offset = angle > Math.PI / 4 && angle < 5 * Math.PI / 4;

            BezierCurve base_curve = new BezierCurve(new PointF[] { a, MiddlePointA, b });

            int offset;
            if (switch_offset)
                offset = _cached_width / 2 - (Style.Margin.Left + SubSegments[0].Line.Width / 2);
            else
                offset = -_cached_width / 2 + (Style.Margin.Left + SubSegments[0].Line.Width / 2);

            foreach (var seg in SubSegments)
            {
                GraphicsPath pa;

                if (seg.CachedCurvedPath == null)
                    seg.RecalcBakedCurvedPath(base_curve, offset);
                pa = seg.CachedBakedCurvedPath;

                if (IsSelected)
                    e.Graphics.DrawPath(new Pen(Map.SelectionColor, Map.SELECTED_LINE_WIDTH), pa);
                else
                    e.Graphics.DrawPath(new Pen(seg.Line.c1, seg.Line.Width), pa);

                if (switch_offset)
                    offset -= Style.Margin.Left * 2 + seg.Line.Width;
                else
                    offset += Style.Margin.Left * 2 + seg.Line.Width;
            }

            if (Program.Config.DisplayDebugInfo)
            {
                e.Graphics.DrawPath(new Pen(Color.FromArgb(0xFF / 2, Color.Red), Width), base_curve.BakePath(10));
            }

            if (IsSelected)
            {
                PaintSegmentMiddlePoint(e.Graphics);
            }
        }
        #endregion

        #region Steps painting
        private void PaintAllSteps(PaintEventArgs e)
        {
            Point a = Begin.GetDockingLocation(this);
            Point b = End.GetDockingLocation(this);

            #region Docking point position and offset calculation
            var drawing_params = SegmentDrawingParams.FromStations(Begin, End, _cached_width);
            #endregion

            Point begin, end;
            begin = new Point(a.X + drawing_params.begin_shift_x, a.Y + drawing_params.begin_shift_y);
            end = new Point(b.X + drawing_params.end_shift_x, b.Y + drawing_params.end_shift_y);

            #region Middlepoint position calculation
            /* get the relative orientation of the two stations */
            bool horizontal = Math.Abs(b.X - a.X) > Math.Abs(b.Y - a.Y);

            PointF mpa = MiddlePointA;

            /* mpa_factor is either 1 or -1, determining the order of the middlepoints. It is set to -1,
             * so that the order flips and the lines dont cross over if needed */
            var mpa_factor = (a.X > b.X && a.Y > b.Y) || (a.X < b.X && a.Y < b.Y) ? -1 : 1;

            if (horizontal)
            {
                mpa.X += mpa_factor * (-_cached_width / 2 + Style.Margin.Left + SubSegments[0].Line.Width / 2);
            }
            else
            {
                mpa.Y += mpa_factor * (-_cached_width / 2 + Style.Margin.Left + SubSegments[0].Line.Width / 2);
            }
            #endregion

            #region Radius calculation
            var corner_radius_inner = Style.Border.Radius.Left;
            var corner_radius_outer = Style.Border.Radius.Left + _cached_width;

            /* under some conditions, we have to switch the two radi. These conditions occurr, when
             * the angle of station vector ab divided by 45 degrees (PI/4) is odd */
            Vector3D vec_a = new Vector3D(a);
            Vector3D vec_b = new Vector3D(b);
            Vector3D vec_ab = vec_b - vec_a;
            var angle = vec_ab.Angle() / Math.PI * 180;

            System.Diagnostics.Debug.WriteLine(angle);

            var swap_radi = false;
            if (angle >= 90 && angle < 135)
                swap_radi = true;
            else if (angle >= 180 && angle < 270)
                swap_radi = true;
            else if (angle >= 315 && angle < 360)
                swap_radi = true;
            #endregion

            /* we returned earlier, if no lines are present, so Lines[0] definitely exists */
            begin.X += drawing_params.begin_factor_x * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);
            begin.Y += drawing_params.begin_factor_y * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);
            end.X += drawing_params.end_factor_x * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);
            end.Y += drawing_params.end_factor_y * (SubSegments[0].Line.Width / 2 + Style.Margin.Left);

            corner_radius_inner += Style.Margin.Left;
            corner_radius_outer -= Style.Margin.Left;

            for (int i = 0; i < SubSegments.Count; ++i)
            {
                if (swap_radi)
                    PaintSteps(e, SubSegments[i], begin, mpa, end, corner_radius_inner, corner_radius_outer);
                else
                    PaintSteps(e, SubSegments[i], begin, mpa, end, corner_radius_outer, corner_radius_inner);

                var delta = SubSegments[i].Line.Width + Style.Margin.Left * 2;

                begin.X += drawing_params.begin_factor_x * delta;
                begin.Y += drawing_params.begin_factor_y * delta;
                end.X += drawing_params.end_factor_x * delta;
                end.Y += drawing_params.end_factor_y * delta;

                corner_radius_inner += delta;
                corner_radius_outer -= delta;

                if (horizontal)
                    mpa.X += mpa_factor * delta;
                else
                    mpa.Y += mpa_factor * delta;
            }

            if (IsSelected)
            {
                PaintSegmentMiddlePoint(e.Graphics);
            }
        }

        private void PaintSteps(PaintEventArgs e, SubSegment seg, Point begin, PointF mp, Point end, int corner_radius_inner, int corner_radius_outer)
        {
            #region Reading the steps path from cache. It will be updated when it needs to
            GraphicsPath pa;
            if (seg.CachedStepsPath == null)
                seg.RecalcStepsPath(begin, mp, end, corner_radius_inner, corner_radius_outer, e.Graphics);
            pa = seg.CachedStepsPath;
            #endregion

            if (!Style.Border.Color.IsNone && Style.Border.Width.Value > 0 && !IsSelected)
            {
                e.Graphics.DrawPath(new Pen(Style.Border.Color.GetColorAuto(seg.Line.c1), seg.Line.Width + 2 * Style.Border.Width.Value), pa);
            }
            else
            {
                var ge = new System.Drawing.Extended.ExtendedGraphics(e.Graphics);

                Pen p;
                if (IsSelected)
                    p = new Pen(Map.SelectionColor, seg.Line.Width);
                else
                    p = new Pen(seg.Line.c1, seg.Line.Width);

                e.Graphics.DrawPath(p, pa);

                if (seg.Line.IsAlternating && !IsSelected)
                    e.Graphics.DrawPath(new Pen(seg.Line.c2, seg.Line.Width)
                    {
                        DashPattern = new float[] { Map.LINE_DASH_LENGTH, Map.LINE_DASH_LENGTH }
                    }, pa);
            }
            
            DrawLabelOnSegment(e, begin, seg.CachedC1, seg.Line);
            DrawLabelOnSegment(e, seg.CachedC1, seg.CachedC2, seg.Line);
            DrawLabelOnSegment(e, seg.CachedC2, end, seg.Line);
        }
        #endregion

        #region Wave painting
        private void PaintAllWave(PaintEventArgs e)
        {
            Point a = Begin.GetDockingLocation(this);
            Point b = End.GetDockingLocation(this);

            bool horizontal = Math.Abs(End.Location.X - Begin.Location.X) > Math.Abs(End.Location.Y - Begin.Location.Y);

            Point c1 = horizontal ? new Point((int)MiddlePointA.X, Begin.Location.Y) : new Point(Begin.Location.X, (int)MiddlePointA.Y);
            Point c2 = horizontal ? new Point((int)MiddlePointA.X, End.Location.Y) : new Point(End.Location.X, (int)MiddlePointA.Y);

            var angle = (new Vector3D(b) - new Vector3D(a)).Angle();
            var switch_offset = angle > Math.PI / 4 && angle < 5 * Math.PI / 4;

            BezierCurve base_curve = new BezierCurve(new PointF[] { a, c1, c2, b });

            int offset;
            if (switch_offset)
                offset = _cached_width / 2 - (Style.Margin.Left + SubSegments[0].Line.Width / 2);
            else
                offset = -_cached_width / 2 + (Style.Margin.Left + SubSegments[0].Line.Width / 2);

            foreach (var seg in SubSegments)
            {
                GraphicsPath pa;

                if (seg.CachedCurvedPath == null)
                    seg.RecalcBakedCurvedPath(base_curve, offset);
                pa = seg.CachedBakedCurvedPath;

                if (IsSelected)
                    e.Graphics.DrawPath(new Pen(Map.SelectionColor, Map.SELECTED_LINE_WIDTH), pa);
                else
                    e.Graphics.DrawPath(new Pen(seg.Line.c1, seg.Line.Width), pa);

                if (switch_offset)
                    offset -= Style.Margin.Left * 2 + seg.Line.Width;
                else
                    offset += Style.Margin.Left * 2 + seg.Line.Width;
            }

            if (Program.Config.DisplayDebugInfo)
            {
                e.Graphics.DrawPath(new Pen(Color.FromArgb(0xFF / 2, Color.Red), Width), base_curve.BakePath(10));
            }

            if (IsSelected)
            {
                PaintSegmentMiddlePoint(e.Graphics);
            }
        }

        private void PaintWave(PaintEventArgs e, Line l, Point begin, Point end)
        {
            bool horizontal = Math.Abs(end.X - begin.X) > Math.Abs(end.Y - begin.Y);

            Point c1 = horizontal ? new Point((int)MiddlePointA.X, begin.Y) : new Point(begin.X, (int)MiddlePointA.Y);
            Point c2 = horizontal ? new Point((int)MiddlePointA.X, end.Y) : new Point(end.X, (int)MiddlePointA.Y);

            var ge = new System.Drawing.Extended.ExtendedGraphics(e.Graphics);

            if (!IsSelected)
            {
                if (l.IsAlternating)
                    ge.DrawTwoToneBezier(l.c1, l.c2, l.Width, Map.LINE_DASH_LENGTH, begin, c1, c2, end);
                else
                    e.Graphics.DrawBezier(new Pen(l.c1, l.Width), begin, c1, c2, end);
            }
            else
            {
                e.Graphics.DrawBezier(new Pen(Map.SelectionColor, Map.SELECTED_LINE_WIDTH), begin, c1, c2, end);

                int radius = 5;
                if (IsMiddlePointHover)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), MiddlePointA.X - radius, MiddlePointA.Y - radius, 2 * radius, 2 * radius);
                else
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 1), MiddlePointA.X - radius, MiddlePointA.Y - radius, 2 * radius, 2 * radius);
            }
        }
        #endregion

        private void PaintSegmentMiddlePoint(Graphics g)
        {
            int radius = 5;
            if (IsMiddlePointHover)
                g.FillEllipse(new SolidBrush(Color.Black), MiddlePointA.X - radius, MiddlePointA.Y - radius, 2 * radius, 2 * radius);
            else
                g.DrawEllipse(new Pen(Color.Black, 1), MiddlePointA.X - radius, MiddlePointA.Y - radius, 2 * radius, 2 * radius);
        }

        private void PaintSegmentDebugInfo(Graphics g)
        {
            g.DrawString("MiddlePoint: " + MiddlePoint, Map.DefaultFont, new SolidBrush(Color.Black), 5, 25);
            g.DrawString("MiddlePointA: " + MiddlePointA, Map.DefaultFont, new SolidBrush(Color.Black), 5, 40);
            g.DrawString("Width: " + Width, Map.DefaultFont, new SolidBrush(Color.Black), 5, 55);
            g.DrawString("DisplayLineLabel: " + DisplayLineLabel, Map.DefaultFont, new SolidBrush(Color.Black), 5, 70);
            g.DrawString("dx: " + _dx, Map.DefaultFont, new SolidBrush(Color.Black), 5, 85);
            g.DrawString("dy: " + _dy, Map.DefaultFont, new SolidBrush(Color.Black), 5, 100);
            g.DrawString("Begin: " + Begin.Name, Map.DefaultFont, new SolidBrush(Color.Black), 5, 120);
            g.DrawString("End: " + End.Name, Map.DefaultFont, new SolidBrush(Color.Black), 5, 135);
            var angle = (new Vector3D(End.Location) - new Vector3D(Begin.Location)).Angle();
            g.DrawString("Angle: " + angle / Math.PI * 180 + "°", Map.DefaultFont, new SolidBrush(Color.Black), 5, 150);

            if (LineMode == SegmentLineMode.Curved)
                g.DrawString("Length: " + SubSegments[0]?.CachedCurvedPath?.GetLength(), Map.DefaultFont, new SolidBrush(Color.Black), 5, 165);
        }

        private void DrawLabelOnSegment(PaintEventArgs e, Point a, Point b, Line l)
        {
            int length = (int)new Vector3(a).Distance(new Vector3(b));
            if ((length > Map.SEGMENT_DISPLAY_LINE_NAME_MIN_LENGTH || DisplayLineLabel == LineLabelDisplayMode.Yes) && DisplayLineLabel != LineLabelDisplayMode.No)
            {
                /* draw the line name in the middle of the segment, accordingly rotated */
                var g = e.Graphics;
                int dx = b.X - a.X;
                int dy = b.Y - a.Y;
                double alpha = Math.Atan2(dx, dy);
                float deg = -(float)(alpha * 180 / Math.PI) + 90f;
                float textwpx = g.MeasureString(l.Name, Map.LineFont).Width;
                float texthpx = g.MeasureString(l.Name, Map.LineFont).Height;

                /* if the text would not fit onto the segment, we do not draw it */
                if (length < textwpx)
                    return;

                Rectangle LabelBg = new Rectangle((int)(length / 2 - textwpx / 2), -6, (int)textwpx, (int)texthpx - 2);

                if (Math.Abs(deg) > 90)
                {
                    Station t = Begin;
                    Begin = End;
                    End = t;
                    return;
                }

                g.TranslateTransform(a.X, a.Y);
                g.RotateTransform(deg);

                g.FillRectangle(new SolidBrush(Color.White), LabelBg);

                if (l.IsBright)
                    g.DrawString(l.Name, Map.LineFont, new SolidBrush(Color.Black), new Point((int)(length / 2 - textwpx / 2), -6));
                else
                    g.DrawString(l.Name, Map.LineFont, new SolidBrush(l.c1), new Point((int)(length / 2 - textwpx / 2), -6));

                g.ResetTransform();
            }
        }

        #region ASCII and binary saving
        public XmlElement CreateXml(Map m, XmlDocument doc, List<Station> StationsToSave)
        {
            XmlElement ret = doc.CreateElement(string.Empty, "segment", string.Empty);

            if (MiddlePoint.X != 0.5f)
                ret.SetAttribute("middlepoint_x", MiddlePoint.X + "");
            if (MiddlePoint.Y != 0.5f)
                ret.SetAttribute("middlepoint_y", MiddlePoint.Y + "");

            if (DisplayLineLabel != LineLabelDisplayMode.Default)
                ret.SetAttribute("displaylinelabel", DisplayLineLabel + "");

            if (LineMode != SegmentLineMode.Straight)
                ret.SetAttribute("mode", LineMode + "");

            for (int i = 0; i < StationsToSave.Count; ++i)
            {
                if (StationsToSave[i] == Begin)
                    ret.SetAttribute("begin", i + "");
                else if (StationsToSave[i] == End)
                    ret.SetAttribute("end", i + "");
            }

            foreach (var subseg in SubSegments)
                ret.AppendChild(subseg.CreateXml(Map, doc));

            return ret;
        }

        public byte[] CreateBinary(Map m, List<Station> stations)
        {
            var data = new List<byte>();

            short begin = 0;
            short end = 0;
            short lineid = 0;

            for (short i = 0; i < stations.Count; ++i)
            {
                if (stations[i] == Begin)
                    begin = i;
                else if (stations[i] == End)
                    end = i;
            }

            data.AddRange(BitConverter.GetBytes(begin));
            data.AddRange(BitConverter.GetBytes(end));
            data.AddRange(BitConverter.GetBytes(MiddlePoint.X));
            data.AddRange(BitConverter.GetBytes(MiddlePoint.Y));
            data.AddRange(BitConverter.GetBytes((short)DisplayLineLabel));
            data.AddRange(BitConverter.GetBytes((short)LineMode));

            for (short i = 0; i < m.Lines.Count; ++i)
                if (m.Lines[i] == Line)
                    lineid = i;

            data.AddRange(BitConverter.GetBytes(lineid));

            return data.ToArray();
        }
        #endregion
    }
}
