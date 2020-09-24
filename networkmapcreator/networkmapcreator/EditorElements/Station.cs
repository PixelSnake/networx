using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using System.Collections.ObjectModel;
using NetworkMapCreator.EditorElements;
using NetworkMapCreator.Utilities;

namespace NetworkMapCreator
{
    public class Station : Undoable, EditorElement
    {
        public enum Direction
        {
            None,
            Left,
            Top,
            Right,
            Bottom
        }

        public enum Prominence
        {
            Default,
            None,
            Ending,
            All
        }

        public enum LabelPivot
        {
            TopLeft,
            TopCenter,
            TopRight,
            CenterLeft,
            Center,
            CenterRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        public static int Count = 0;
        public int ID { get; private set; }

        public StyleSet Style;

        public Point label_offset = new Point(0, 0);
        public LabelPivot Pivot = LabelPivot.Center;

        private bool hover = false;
        public bool IsHovered { get { return hover; } }

        private bool selected = false;
        public bool IsSelected { get { return selected; } set { selected = value; } }

        public string Name;

        public Point Location
        {
            get
            {
                return new Point(ObservableLocation.X, ObservableLocation.Y);
            }
            set
            {
                ObservableLocation.Set(value.X, value.Y);
            }
        }
        public ObservablePoint ObservableLocation { get; private set; }

        public float RotationAngle = 0;

        public ObservableCollection<Segment> SegmentsLeft = new ObservableCollection<Segment>();
        public ObservableCollection<Segment> SegmentsTop = new ObservableCollection<Segment>();
        public ObservableCollection<Segment> SegmentsRight = new ObservableCollection<Segment>();
        public ObservableCollection<Segment> SegmentsBottom = new ObservableCollection<Segment>();

        public int Width
        {
            get
            {
                return Math.Max(_cached_width_top, _cached_width_bottom);
            }
        }
        private int _cached_width_top = 0;
        private int _cached_width_bottom = 0;
        public int Height
        {
            get
            {
                return Math.Max(_cached_height_left, _cached_height_right);
            }
        }
        private int _cached_height_left = 0;
        private int _cached_height_right = 0;

        public Prominence prominence = Prominence.Default;
        private int count_lines = 0;
        private List<Line> lines_ending = new List<Line>();
        private List<Line> Lines = new List<Line>();

        bool multiple { get { return seg_count > 2 || count_lines > 1; } }
        int seg_count { get { return left + top + bottom + right; } }
        int left
        {
            get
            {
                var sum = 0;
                foreach (var seg in SegmentsLeft)
                    sum += seg.SubSegments.Count;
                return sum;
            }
        }
        int top
        {
            get
            {
                var sum = 0;
                foreach (var seg in SegmentsTop)
                    sum += seg.SubSegments.Count;
                return sum;
            }
        }
        int bottom
        {
            get
            {
                var sum = 0;
                foreach (var seg in SegmentsBottom)
                    sum += seg.SubSegments.Count;
                return sum;
            }
        }
        int right
        {
            get
            {
                var sum = 0;
                foreach (var seg in SegmentsRight)
                    sum += seg.SubSegments.Count;
                return sum;
            }
        }
        int top_or_bottom { get { return bottom + top; } }
        int left_or_right { get { return left + right; } }

        /* takes the color of the last added line, if connections is greater than 1, becomes white */
        public Line Line = null;

        public Station(Map m, string name, Point location)
        {
            ID = Count++;

            Map.StyleManager.StyleChanged += StyleManager_StyleChanged;
            ReloadStyle();

            SegmentsLeft.CollectionChanged   += Segments_CollectionChanged;
            SegmentsTop.CollectionChanged    += Segments_CollectionChanged;
            SegmentsRight.CollectionChanged  += Segments_CollectionChanged;
            SegmentsBottom.CollectionChanged += Segments_CollectionChanged;

            Map = m;
            Name = name;
            ObservableLocation = new ObservablePoint(location);

            Map.UndoManager.Push(new UndoAction(UndoActionType.Create, this));
        }

        private void Segments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var delta = 0;
            var list = sender as Collection<Segment>;

            if (list == null)
                return;

            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (Segment i in e.NewItems)
                    {
                        delta += i.Width;
                        delta += 2 * i.Style.Margin.Left;
                    }
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (Segment i in e.OldItems)
                    { 
                        delta -= i.Width;
                        delta -= 2 * i.Style.Margin.Left;
                    }
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (Segment i in e.OldItems)
                    { 
                        delta -= i.Width;
                        delta -= 2 * i.Style.Margin.Left;
                    }
                    foreach (Segment i in e.NewItems)
                    { 
                        delta += i.Width;
                        delta += 2 * i.Style.Margin.Left;
                    }
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    RecalcDimensions(list);
                    break;
            }

            if (list == SegmentsLeft)
                _cached_height_left += delta;
            else if (list == SegmentsTop)
                _cached_width_top += delta;
            else if (list == SegmentsRight)
                _cached_height_right += delta;
            else if (list == SegmentsBottom)
                _cached_width_bottom += delta;
        }

        private void StyleManager_StyleChanged()
        {
            ReloadStyle();
            RecalcDimensions();
        }

        private void ReloadStyle()
        {
            var selector = "station";
            if (multiple)
                selector = "station.multiple";
            else if (Line != null && Line.IsBright)
                selector = "station.bright";
            Style = Map.StyleManager.Styles[selector];
        }

        public bool MouseMove(MouseEventArgs e)
        {
            return hover = new Vector3(e.Location).Distance(new Vector3(Location)) < Map.STATION_MOUSE_SNAP_DIST;
        }

        public void MouseDoubleClick(MouseEventArgs e)
        {
            if (hover)
                new StationEditor(this).ShowDialog();
        }

        public void AddSegment(Segment n)
        {
            var l = GetCorrectList(n);
            if (l.Contains(n))
                return;
            InsertIntoListSorted(l, n, l == SegmentsLeft || l == SegmentsRight);

            n.SubSegments.CollectionChanged += Segment_SubSegments_Changed;
            
            RecalcParameters();
        }

        private void Segment_SubSegments_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var list = sender as Collection<SubSegment>;
            if (list == null)
                return;

            RecalcParameters();
        }

        public void RemoveSegment(Segment n)
        {
            n.SubSegments.CollectionChanged -= Segment_SubSegments_Changed;

            SegmentsLeft.Remove(n);
            SegmentsTop.Remove(n);
            SegmentsRight.Remove(n);
            SegmentsBottom.Remove(n);

            foreach (var s in n.SubSegments)
                Lines.Remove(s.Line);
            Line = null;
            RecalcParameters();
        }

        /* Calls CalcStationDirections on every connected station */
        public void LocationChanged(Station sender)
        {
            Collection<Segment> corl;
            Collection<Segment>[] lists = { SegmentsLeft, SegmentsTop, SegmentsRight, SegmentsBottom };

            foreach (var l in lists)
            {
                List<Segment> del = new List<Segment>();
                List<Segment> resort = new List<Segment>();

                foreach (var s in l)
                {
                    if ((corl = GetCorrectList(s)) != l)
                    {
                        del.Add(s);
                        InsertIntoListSorted(corl, s, l == SegmentsLeft || l == SegmentsRight);
                        /* we can do this without an exception, because this is proven
                         * not to be the list we are currently iterating through */
                    }
                    else
                        resort.Add(s);

                    if (sender == null)
                        OtherEnd(s).LocationChanged(this);
                }
                foreach (var d in del)
                    l.Remove(d);
                foreach (var d in resort)
                {
                    l.Remove(d);
                    InsertIntoListSorted(l, d, l == SegmentsLeft || l == SegmentsRight);
                }

                ResortList(l, l == SegmentsLeft || l == SegmentsRight);
            }
        }

        private void InsertIntoListSorted(Collection<Segment> list, Segment s, bool vertical)
        {
            /* Insertion Sort: The beginning of the list is sorted ascending */
            for (int i = 0; i < list.Count; ++i)
            {
                var x = list[i];
                var k_x = vertical ? OtherEnd(x).Location.Y : OtherEnd(x).Location.X;
                var k_s = vertical ? OtherEnd(s).Location.Y : OtherEnd(s).Location.X;
                if (k_s < k_x)
                {
                    list.Insert(i, s);
                    return;
                }
            }
            list.Add(s);
        }

        private void ResortList(Collection<Segment> list, bool vertical)
        {
            Collection<Segment> n = new Collection<Segment>();
            foreach (var s in list)
                InsertIntoListSorted(n, s, vertical);
            list = n;
        }

        /* Returs the list, where the segment SHOULD be */
        public Collection<Segment> GetCorrectList(Segment s)
        {
            var dir = GetStationSide(OtherEnd(s));
            if (dir == Direction.None)
                return null;

            switch (dir)
            {
                case Direction.Left:
                    return SegmentsLeft;
                case Direction.Top:
                    return SegmentsTop;
                case Direction.Right:
                    return SegmentsRight;
                case Direction.Bottom:
                    return SegmentsBottom;
                default: /* just because the compiler complains otherwise, will never happen */
                    return null;
            }
        }

        private void RecalcParameters()
        {
            ReloadStyle();
            RecalcLines();
            RecalcDimensions();

            Collection<Segment>[] lists = { SegmentsLeft, SegmentsTop, SegmentsRight, SegmentsBottom };

            lines_ending.Clear();
            foreach (var line in Map.Lines)
            {
                int segcount = 0;
                foreach (var l in lists)
                    foreach (var seg in l)
                    {
                        foreach (var subseg in seg.SubSegments)
                            if (subseg.Line == line)
                                segcount++;
                    }
                if (segcount == 1)
                    lines_ending.Add(line);
            }
        }

        public void RecalcLines()
        {
            List<string> linenames = new List<string>();
            Collection<Segment>[] lists = { SegmentsLeft, SegmentsTop, SegmentsRight, SegmentsBottom };

            foreach (var l in lists)
                foreach (var s in l)
                {
                    foreach (var seg in s.SubSegments)
                    {
                        if (!linenames.Contains(seg.Line.Name))
                            linenames.Add(seg.Line.Name);
                        if (!Lines.Contains(seg.Line))
                        {
                            Lines.Add(seg.Line);
                            if (Line == null || s.Width > Line.Width)
                                Line = seg.Line;
                        }
                    }
                }
            count_lines = linenames.Count();
        }

        public void RecalcDimensions()
        {
            Collection<Segment>[] lists = { SegmentsLeft, SegmentsTop, SegmentsRight, SegmentsBottom };

            foreach (var list in lists)
                RecalcDimensions(list);
        }

        public void RecalcDimensions(Collection<Segment> list)
        {
            int delta = 0;

            foreach (Segment i in list)
            {
                delta += i.Width;
            }

            if (list == SegmentsLeft)
                _cached_height_left = delta;
            else if (list == SegmentsTop)
                _cached_width_top = delta;
            else if (list == SegmentsRight)
                _cached_height_right = delta;
            else if (list == SegmentsBottom)
                _cached_width_bottom = delta;
        }

        public Station OtherEnd(Segment s)
        {
            if (s.End == this)
                return s.Begin;
            else if (s.Begin == this)
                return s.End;
            return null; /* the segment is not even connected to this station */
        }

        public Direction GetStationSide(Station s)
        {
            if (s == null)
                return Direction.None;

            if (Math.Abs(Location.X - s.Location.X) > Math.Abs(Location.Y - s.Location.Y))
            {
                if (Location.X - s.Location.X > 0)
                    return Direction.Left;
                else
                    return Direction.Right;
            }
            else
            {
                if (Location.Y - s.Location.Y > 0)
                    return Direction.Top;
                else
                    return Direction.Bottom;
            }
        }
        
        public Point GetDockingLocation(Segment s)
        {
            Station other = OtherEnd(s);
            var dir = GetStationSide(other);

            if (dir == Direction.Left)
            {
                var list = SegmentsLeft;

                if (left < 2)
                    return Location;

                int y = -_cached_height_left / 2 + s.Width / 2;
                for (int i = 0; i < list.IndexOf(s); ++i)
                    y += list[i].Width;

                Point p = new Point(Location.X, Location.Y + y);
                return p;
            }
            else if (dir == Direction.Right)
            {
                var list = SegmentsRight;

                if (right < 2)
                    return Location;

                int y = -_cached_height_right / 2 + s.Width / 2;
                for (int i = 0; i < list.IndexOf(s); ++i)
                    y += list[i].Width;

                Point p = new Point(Location.X, Location.Y + y);
                return p;
            }
            else if (dir == Direction.Top)
            {
                var list = SegmentsTop;

                if (top < 2)
                    return Location;

                int x = -_cached_width_top / 2 + s.Width / 2;
                for (int i = 0; i < list.IndexOf(s); ++i)
                    x += list[i].Width;

                Point p = new Point(Location.X + x, Location.Y);
                return p;
            }
            else //if (dir == Direction.Bottom)
            {
                var list = SegmentsBottom;

                if (bottom < 2)
                    return Location;

                int x = -_cached_width_bottom / 2 + s.Width / 2;
                for (int i = 0; i < list.IndexOf(s); ++i)
                    x += list[i].Width;

                Point p = new Point(Location.X + x, Location.Y);
                return p;
            }
        }

        public bool Select()
        {
            return IsHovered;
        }

        public void SelectionModeChanged(bool selected)
        {
            IsSelected = selected;
        }

        public void Paint(PaintEventArgs e)
        {
            int width = Line == null ? Map.DEFAULT_LINE_WIDTH : Line.Width;
            var g = e.Graphics;
            
            Color background_color, border_color;

            if (Line == null)
            {
                background_color = Map.default_color;
                border_color = Map.default_color;
            }
            else
            {
                background_color = Style.BackgroundColor.GetColorAuto(Line.c1);
                border_color = Style.Border.Color.GetColorAuto(Line.c1);
            }

            g.TranslateTransform(Location.X, Location.Y);

            if (multiple)
            {
                int w = Width;
                int h = Height;
                var padding = Style.Padding;

                if (Style.Width.SizeMode == CSSSizeMode.Pixel)
                    w = Style.Width.Value;
                if (Style.Height.SizeMode == CSSSizeMode.Pixel)
                    h = Style.Height.Value;

                var ge = new System.Drawing.Extended.ExtendedGraphics(g);
                ge.FillRoundRectangle(new SolidBrush(background_color),
                    -w / 2 - padding.Left,
                    -h / 2 - padding.Top,
                    w + padding.Left + padding.Right,
                    h + padding.Top + padding.Bottom,
                    Style.Border.Radius.Left);
                ge.DrawRoundRectangle(new Pen(border_color, Style.Border.Width.Value),
                    -w / 2 - padding.Left,
                    -h / 2 - padding.Top,
                    w + padding.Left + padding.Right,
                    h + padding.Top + padding.Bottom,
                    Style.Border.Radius.Left);

                if (Program.Config.DisplayDebugInfo)
                {
                    var pen = new Pen(Color.Green, 1);

                    g.DrawRectangle(pen, -w / 2, -h / 2, w, h);

                    g.DrawLine(pen, -Width - 20, 0, Width + 20, 0);
                    g.DrawLine(pen, 0, -Height - 20, 0, Height + 20);
                }

                //g.DrawString(below_or_above + ", " + left_or_right, Font, new SolidBrush(Color.Black), new Point(15, 8));
            }
            else
            {
                int w =  Width;
                int h = Height;
                
                if (Style.Width.SizeMode == CSSSizeMode.Pixel)
                    w = Style.Width.Value;
                if (Style.Height.SizeMode == CSSSizeMode.Pixel)
                    h = Style.Height.Value;

                var ge = new System.Drawing.Extended.ExtendedGraphics(g);
                ge.FillRoundRectangle(new SolidBrush(background_color), -w / 2, -h / 2, w, h, Style.Border.Radius.Left);
                ge.DrawRoundRectangle(new Pen(border_color, Style.Border.Width.Value), -w / 2, -h / 2, w, h, Style.Border.Radius.Left);
            }

            if (hover || selected)
            {
                var s = Map.STATION_MOUSE_SNAP_DIST;

                if (hover)
                    g.FillEllipse(new SolidBrush(Color.FromArgb(0x7F, Map.SelectionColor1)), -s, -s, 2 * s, 2 * s);

                g.DrawEllipse(new Pen(Map.SelectionColor1, 2), -s, -s, 2 * s, 2 * s);
            }

            DrawLabel(e);

            g.ResetTransform();

            if (Program.Config.DisplayDebugInfo)
            {
                if (IsSelected)
                {
                    e.Graphics.DrawString("HeightLeft: " + _cached_height_left, Map.DefaultFont, new SolidBrush(Color.Black), 5, 25);
                    e.Graphics.DrawString("WidthTop: " + _cached_width_top, Map.DefaultFont, new SolidBrush(Color.Black), 5, 40);
                    e.Graphics.DrawString("HeightRight: " + _cached_height_right, Map.DefaultFont, new SolidBrush(Color.Black), 5, 55);
                    e.Graphics.DrawString("WidthBottom: " + _cached_width_bottom, Map.DefaultFont, new SolidBrush(Color.Black), 5, 70);
                    e.Graphics.DrawString("Line: " + Line?.Name, Map.DefaultFont, new SolidBrush(Color.Black), 5, 85);
                }
            }
        }

        public void DrawLabel(PaintEventArgs e)
        {
            var g = e.Graphics;

            /* Get font according to line (may have different size) */
            var Font = Line != null ? Map.Fonts[Line.Width - 1] : Map.DefaultFont;

            /* Calculate label bounds */
            var _m = g.MeasureString(Name, Font);
            float txtw = _m.Width;
            float txth = _m.Height;

            /* Get the css selector according to the circumstances */
            var selector = "station label";
            if (Line != null)
            {
                if (seg_count == 1 && prominence == Prominence.Default)
                    selector = "station.ending_default label";
                else if (prominence == Prominence.Ending)
                    selector = "station.ending label";
                else if (prominence == Prominence.All)
                    selector = "station.all label";
            }

            /* Load the style settings */
            var Style = Map.StyleManager.Styles[selector];
            var cssX = Style.X;
            var cssY = Style.Y;
            var cssWidth = Style.Width;
            var cssHeight = Style.Height;

            var cssPadding = Style.Padding;
            var cssPaddingL = cssPadding.Left;
            var cssPaddingT = cssPadding.Top;
            var cssPaddingR = cssPadding.Right;
            var cssPaddingB = cssPadding.Bottom;
            var cssMargin = Style.Margin;
            var cssMarginL = cssMargin.Left;
            var cssMarginT = cssMargin.Top;
            var cssMarginR = cssMargin.Right;
            var cssMarginB = cssMargin.Bottom;

            Color cssTextColor, cssBackground;

            if (Line != null)
            {
                cssTextColor = Style.Color.GetColorAuto(Line.c1);
                cssBackground = Style.BackgroundColor.GetColorAuto(Line.c1);
            }
            else
            {
                cssTextColor = Color.Black;
                cssBackground = Color.Black;
            }
            
            var cssBorder = Style.Border;

            /* Convert label pivot to actual coordinates */
            var p = Pivot2Point(Pivot);
            var textloc = new Point((int)(-p.X * txtw + cssPaddingL + cssMarginL), (int)(-p.Y * txth + cssPaddingT + cssMarginT));

            /* If this line color is considered "bright", we use different settings for the font color */
            if (Line != null && Line.IsBright)
                cssTextColor = Map.StyleManager.Styles["station label.bright"].Color.GetColorAuto(Line.c1);

            var _offset_x = 0;
            var _offset_y = 0;

            /* Calculate offset */
            switch (Style.Position)
            {
                case CSSPosition.Absolute:
                    if (cssX.SizeMode == CSSSizeMode.Pixel)
                        _offset_x = cssX.Value;
                    else
                        _offset_x = label_offset.X;
                    if (cssY.SizeMode == CSSSizeMode.Pixel)
                        _offset_y = cssY.Value;
                    break;

                case CSSPosition.Relative:
                    _offset_x = label_offset.X;
                    _offset_y = label_offset.Y;

                    if (cssX.SizeMode == CSSSizeMode.Pixel)
                        _offset_x += cssX.Value;
                    if (cssY.SizeMode == CSSSizeMode.Pixel)
                        _offset_y += cssY.Value;
                    break;
            }

            /* We move the label to its position */
            g.TranslateTransform(_offset_x, _offset_y);
            g.RotateTransform(RotationAngle);

            /* One line ends here */
            if (Line != null && prominence == Prominence.Default && seg_count == 1)
            {
                int line_x = textloc.X + (int)txtw + cssPaddingR + cssMarginR;
                int line_y = textloc.Y - cssPaddingT - cssMarginT; // restore original text location
                var cssBorderWidth = cssBorder.Width.SizeMode == CSSSizeMode.Pixel ? cssBorder.Width.Value : 1;
                var cssBorderColor = cssBorder.Color.GetColorAuto(Line.c1);

                g.FillRectangle(new SolidBrush(cssBackground),           textloc.X - cssPaddingL, textloc.Y - cssPaddingT, txtw + cssPaddingL + cssPaddingR, txth + cssPaddingT + cssPaddingB);
                g.DrawRectangle(new Pen(cssBorderColor, cssBorderWidth), textloc.X - cssPaddingL, textloc.Y - cssPaddingT, txtw + cssPaddingL + cssPaddingR, txth + cssPaddingT + cssPaddingB);

                g.DrawString(Name, Font, new SolidBrush(cssTextColor), textloc);

                if (Line != null)
                    DrawLine(g, Line, (int)line_x, (int)line_y - 2, Font);
            }
            /* User wants to draw all ending lines or all lines */
            else if (Line != null && prominence == Prominence.Ending || prominence == Prominence.All)
            {
                /* recalc text bounds because we use the bold font here */
                _m = g.MeasureString(Name, Font);
                txtw = _m.Width;
                txth = _m.Height;
                textloc = new Point((int)(-Pivot2Point(Pivot).X * txtw), (int)(-Pivot2Point(Pivot).Y * txth));
                var trect = new RectangleF(-Pivot2Point(Pivot).X * txtw, -Pivot2Point(Pivot).Y * txth, txtw, txth);

                g.DrawString(Name, Font, new SolidBrush(cssTextColor), textloc);

                /* Draw the line labels */
                if (prominence == Prominence.Ending)
                    DrawLinesOnAnkerSide(g, lines_ending.ToArray(), trect);
                else
                    DrawLinesOnAnkerSide(g, Lines.ToArray(), trect);
            }
            else
                g.DrawString(Name, Font, new SolidBrush(cssTextColor), textloc);
        }

        private static void DrawLine(Graphics g, Line l, int x, int y, Font f)
        {
            var _l = g.MeasureString(l.Name, f);

            var selector = "linelabel";
            if (l.c1.GetBrightness() > Map.BRIGHTNESS_LIMIT)
                selector = "linelabel.bright";

            var style = Map.StyleManager.Styles[selector];
            var padding = style.Padding;
            var margin = style.Margin;
            var lw = _l.Width + padding.Left + padding.Right;
            var lh = _l.Height + padding.Top + padding.Bottom;

            var bg = style.BackgroundColor.GetColorAuto(l.c1);
            var border = style.Border.Color.GetColorAuto(l.c1);
            var fg = style.Color.GetColorAuto(l.c1);

            var ge = new System.Drawing.Extended.ExtendedGraphics(g);
            ge.FillRoundRectangle(new SolidBrush(bg), margin.Left - padding.Left + x, margin.Top - padding.Top + y, lw, lh, style.Border.Radius.Left);

            if (style.Border.Width.Value > 0)
            {
                ge.DrawRoundRectangle(new Pen(border, style.Border.Width.Value), margin.Left - padding.Left + x, margin.Top - padding.Top + y, lw, lh, style.Border.Radius.Left);
            }

            g.DrawString(l.Name, f, new SolidBrush(fg), margin.Left + x, margin.Top + y + 1);
        }

        private void DrawLinesOnAnkerSide(Graphics g, Line[] lines, RectangleF textbounds)
        {
            if (lines.Length == 0)
                return;

            var Font = Line != null ? Map.Fonts[Line.Width - 1] : Map.DefaultFont;
            var totwidth = 0f;
            var totheight = 0f;
            var widths = new List<float>();
            var heights = new List<float>();

            for (int i = 0; i < lines.Length; ++i)
            {
                var selector = "linelabel";
                if (lines[i].c1.GetBrightness() > Map.BRIGHTNESS_LIMIT)
                    selector = "linelabel.bright";
                var style = Map.StyleManager.Styles[selector];

                var l = g.MeasureString(lines[i].Name, Font);
                widths.Add(l.Width +
                            style.Margin.Left + style.Padding.Left +
                            style.Padding.Right + style.Margin.Right);
                heights.Add(l.Height +
                            style.Margin.Top + style.Padding.Top +
                            style.Padding.Bottom + style.Margin.Bottom);

                switch (Pivot)
                {
                    case LabelPivot.BottomLeft:
                    case LabelPivot.BottomCenter:
                    case LabelPivot.BottomRight:
                    case LabelPivot.TopLeft:
                    case LabelPivot.TopCenter:
                    case LabelPivot.TopRight:
                        totwidth += l.Width +
                            style.Margin.Left + style.Padding.Left + 
                            style.Padding.Right + style.Margin.Right;
                        break;

                    default:
                        totheight += l.Height +
                            style.Margin.Top + style.Padding.Top +
                            style.Padding.Bottom + style.Margin.Bottom;
                        break;
                }
            }

            float margin = 0;
            float padding = 0;
            float posx = -totwidth / 2;
            float posy = -totheight / 2;

            switch (Pivot)
            {
                case LabelPivot.BottomLeft:
                case LabelPivot.BottomCenter:
                case LabelPivot.BottomRight:
                    posy -= heights.First() + margin + textbounds.Height;
                    break;

                case LabelPivot.TopLeft:
                case LabelPivot.TopCenter:
                case LabelPivot.TopRight:
                    posy += margin;
                    break;

                case LabelPivot.CenterLeft:
                    posx += textbounds.Width + margin + 5;
                    break;

                case LabelPivot.Center:
                    posx += margin + textbounds.Width / 2;
                    break;

                case LabelPivot.CenterRight:
                    posx -= margin + textbounds.Width + 5;
                    break;
            }

            for (int i = 0; i < lines.Length; ++i)
            {
                var l = lines[i];

                var lw = widths[i] + 2 * padding;
                var lh = heights[i] + padding;

                var x = posx;
                var y = posy;
                if (Pivot == LabelPivot.CenterRight)
                    x -= widths[i];

                DrawLine(g, l, (int)x, (int)y, Font);

                switch (Pivot)
                {
                    case LabelPivot.BottomLeft:
                    case LabelPivot.BottomCenter:
                    case LabelPivot.BottomRight:
                    case LabelPivot.TopLeft:
                    case LabelPivot.TopCenter:
                    case LabelPivot.TopRight:
                        posx += widths[i] + padding + margin;
                        break;

                    case LabelPivot.CenterLeft:
                    case LabelPivot.Center:
                    case LabelPivot.CenterRight:
                        posy += heights[i] + padding + margin;
                        break;
                }
            }
        }

        public static PointF Pivot2Point(LabelPivot p)
        {
            switch (p)
            {
                case LabelPivot.BottomCenter:
                    return new PointF(0.5f, 1.0f);

                case LabelPivot.BottomLeft:
                    return new PointF(0, 1.0f);

                case LabelPivot.BottomRight:
                    return new PointF(1.0f, 1.0f);

                case LabelPivot.Center:
                    return new PointF(0.5f, 0.5f);

                case LabelPivot.CenterLeft:
                    return new PointF(0, 0.5f);

                case LabelPivot.CenterRight:
                    return new PointF(1.0f, 0.5f);

                case LabelPivot.TopCenter:
                    return new PointF(0.5f, 0);

                case LabelPivot.TopLeft:
                    return new PointF(0, 0);

                case LabelPivot.TopRight:
                    return new PointF(1.0f, 0);

                default:
                    return new PointF(0.5f, 0.5f);
            }
        }

        public static LabelPivot Point2Pivot(PointF p)
        {
            if (p.Y == 0)
            {
                if (p.X == 0)
                    return LabelPivot.TopLeft;
                else if (p.X == 0.5f)
                    return LabelPivot.TopCenter;
                else
                    return LabelPivot.TopRight;
            }
            else if (p.Y == 0.5f)
            {
                if (p.X == 0)
                    return LabelPivot.CenterLeft;
                else if (p.X == 0.5f)
                    return LabelPivot.Center;
                else
                    return LabelPivot.CenterRight;
            }
            else
            {
                if (p.X == 0)
                    return LabelPivot.BottomLeft;
                else if (p.X == 0.5f)
                    return LabelPivot.BottomCenter;
                else
                    return LabelPivot.BottomRight;
            }
        }

        public bool InRect(Rectangle r)
        {
            return r.X < Location.X && r.Y < Location.Y && r.X + r.Width > Location.X && r.Y + r.Height > Location.Y;
        }

        /* Loading and Saving */

        public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement ret = doc.CreateElement(string.Empty, "station", string.Empty);
            ret.SetAttribute("name", Name);
            ret.SetAttribute("x", Location.X + "");
            ret.SetAttribute("y", Location.Y + "");
            ret.SetAttribute("rotation", RotationAngle + "");
            ret.SetAttribute("label_x", label_offset.X + "");
            ret.SetAttribute("label_y", label_offset.Y + "");
            ret.SetAttribute("pivot", Pivot + "");
            ret.SetAttribute("prominence", prominence + "");

            return ret;
        }

        public byte[] CreateBinary()
        {
            var data = new List<byte>();

            var namebytes = Encoding.Unicode.GetBytes(Name);
            var namelen = namebytes.Length;

            data.AddRange(BitConverter.GetBytes(namelen));
            data.AddRange(namebytes);

            data.AddRange(BitConverter.GetBytes(Location.X));
            data.AddRange(BitConverter.GetBytes(Location.Y));
            data.AddRange(BitConverter.GetBytes((short)RotationAngle));
            data.AddRange(BitConverter.GetBytes((short)label_offset.X));
            data.AddRange(BitConverter.GetBytes((short)label_offset.Y));
            data.Add((byte)Pivot);
            data.Add((byte)prominence);

            return data.ToArray();
        }
    }
}