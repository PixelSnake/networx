using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator.Controls
{
    public partial class SegmentOrderEditorPanel : Control
    {
        private Point Mouse;
        private List<RectangleF> LineBounds, ArrowUpBounds, ArrowDownBounds, LineLabelBounds, DirectionBounds;

        public EditorElement Source
        {
            set
            {
                _source = value;
                SourceChanged?.Invoke(this, _source);
            }
            get
            {
                return _source;
            }
        }
        private EditorElement _source;

        private new int Margin = 2, Padding = 2;
        private float LineHeight, CircleRadius, LineLabelWidth = 32;

        public delegate void SourceChangedEventHandler(object sender, EditorElement e);
        public event SourceChangedEventHandler SourceChanged;

        public SegmentOrderEditorPanel()
        {
            InitializeComponent();

            LineBounds = new List<RectangleF>();
            DirectionBounds = new List<RectangleF>();
            ArrowUpBounds = new List<RectangleF>();
            ArrowDownBounds = new List<RectangleF>();
            LineLabelBounds = new List<RectangleF>();

            SourceChanged += this_SourceChanged;

            DoubleBuffered = true;
        }

        private void this_SourceChanged(object sender, EditorElement e)
        {
            Mouse = Point.Empty;

            if (e is Segment)
                CalculateSegmentParameters();
        }

        private void CalculateSegmentParameters()
        {
            var seg = Source as Segment;

            LineBounds.Clear();
            ArrowUpBounds.Clear();
            ArrowDownBounds.Clear();
            LineLabelBounds.Clear();
            DirectionBounds.Clear();

            LineHeight = (float)Bounds.Height / (float)seg.SubSegments.Count - Margin;
            CircleRadius = (LineHeight - Padding * 2) / 2;

            for (int i = 0; i < seg.SubSegments.Count; ++i)
            {
                var y = i * (LineHeight + Margin);

                LineBounds.Add(new RectangleF(0, y, Bounds.Width, LineHeight));
                ArrowUpBounds.Add(new RectangleF(Bounds.Width - Padding - 2 * CircleRadius, y + Padding, 2 * CircleRadius, 2 * CircleRadius));
                ArrowDownBounds.Add(new RectangleF(Bounds.Width - Padding * 2 - 4 * CircleRadius, y + Padding, 2 * CircleRadius, 2 * CircleRadius));
                LineLabelBounds.Add(new RectangleF(Padding, y + Padding, LineLabelWidth + 2 * Padding, LineHeight - 2 * Padding));
                DirectionBounds.Add(new RectangleF(LineLabelWidth + 4 * Padding, y + Padding, LineLabelWidth + 2 * Padding, LineHeight - 2 * Padding));
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (Source is Segment)
                OnSegmentMouseClick(e);

            Refresh();
        }

        protected void OnSegmentMouseClick(MouseEventArgs e)
        {
            var seg = Source as Segment;

            for (int i = 0; i < seg.SubSegments.Count; ++i)
            {
                if (!LineBounds[i].Contains(e.Location))
                    continue;

                var first = i == 0;
                var last = i == seg.SubSegments.Count - 1;

                if (ArrowUpBounds[i].Contains(e.Location) && !first)
                    seg.SubSegments.Move(i, i - 1);
                else if (ArrowDownBounds[i].Contains(e.Location) && !last)
                    seg.SubSegments.Move(i, i + 1);
                else if (LineLabelBounds[i].Contains(e.Location))
                    seg.SubSegments[i].LineLabelDisplay = seg.SubSegments[i].LineLabelDisplay.Next();
                else if (DirectionBounds[i].Contains(e.Location))
                    seg.SubSegments[i].Direction = seg.SubSegments[i].Direction.Next();

                CalculateSegmentParameters();
                Refresh();
                break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Mouse = e.Location;

            Refresh();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (Source == null)
                return;

            if (Source is Segment)
                PaintSegment(pe);
        }

        protected void PaintSegment(PaintEventArgs pe)
        {
            var seg = Source as Segment;
            
            var whitebrush = new SolidBrush(Color.White);
            var hoverbrush = new SolidBrush(Color.LightGray);
            var disabledbrush = new SolidBrush(Color.DarkGray);

            var down_arrow_path = new GraphicsPath();
            down_arrow_path.AddLine(-0.5f * CircleRadius, -0.25f * CircleRadius, 0.0f, 0.25f * CircleRadius);
            down_arrow_path.AddLine(0.5f * CircleRadius, -0.25f * CircleRadius, 0.0f, 0.25f * CircleRadius);

            var up_arrow_path = new GraphicsPath();
            up_arrow_path.AddLine(-0.5f * CircleRadius, 0.25f * CircleRadius, 0.0f, -0.25f * CircleRadius);
            up_arrow_path.AddLine(0.5f * CircleRadius, 0.25f * CircleRadius, 0.0f, -0.25f * CircleRadius);

            var left_arrow_path = new GraphicsPath();
            left_arrow_path.AddLine(0.25f * CircleRadius, 0.5f * CircleRadius, -0.25f * CircleRadius, 0.0f);
            left_arrow_path.AddLine(0.25f * CircleRadius, -0.5f * CircleRadius, -0.25f * CircleRadius, 0.0f);

            var right_arrow_path = new GraphicsPath();
            right_arrow_path.AddLine(-0.25f * CircleRadius, 0.5f * CircleRadius, 0.25f * CircleRadius, 0.0f);
            right_arrow_path.AddLine(-0.25f * CircleRadius, -0.5f * CircleRadius, 0.25f * CircleRadius, 0.0f);

            for (int i = 0; i < seg.SubSegments.Count; ++i)
            {
                var first = i == 0;
                var last = i == seg.SubSegments.Count - 1;

                var y = i * (LineHeight + Margin);

                var brush = new SolidBrush(seg.SubSegments[i].Line.c1);

                pe.Graphics.FillRectangle(brush, LineBounds[i]);

                #region Drawing Positioning Arrows
                if (!first)
                {
                    pe.Graphics.FillEllipse(ArrowUpBounds[i].Contains(Mouse) ? hoverbrush : whitebrush, ArrowUpBounds[i]);
                    pe.Graphics.TranslateTransform(Bounds.Width - Padding - CircleRadius, y + Padding + CircleRadius);
                    pe.Graphics.DrawPath(new Pen(brush, 2), up_arrow_path);
                    pe.Graphics.ResetTransform();
                }

                if (!last)
                {
                    pe.Graphics.FillEllipse(ArrowDownBounds[i].Contains(Mouse) ? hoverbrush : whitebrush, ArrowDownBounds[i]);
                    pe.Graphics.TranslateTransform(Bounds.Width - 2 * Padding - 3 * CircleRadius, y + Padding + CircleRadius);
                    pe.Graphics.DrawPath(new Pen(brush, 2), down_arrow_path);
                    pe.Graphics.ResetTransform();
                }
                #endregion

                #region Drawing Line Label
                pe.Graphics.FillRectangle(LineLabelBounds[i].Contains(Mouse) ? hoverbrush : whitebrush, LineLabelBounds[i]);

                var shortened = false;
                var label = seg.SubSegments[i].Line.Name;
                var label_bounds = pe.Graphics.MeasureString(label, Map.DefaultFont);

                while (label_bounds.Width > LineLabelWidth)
                {
                    shortened = true;
                    label = label.Substring(0, label.Length - 1);
                    label_bounds = pe.Graphics.MeasureString(label + "...", Map.DefaultFont);
                }

                pe.Graphics.DrawString(label + (shortened ? "..." : ""), Map.DefaultFont, seg.SubSegments[i].LineLabelDisplay == LineLabelDisplayMode.Visible ? brush : disabledbrush, Padding * 2, y + Padding * 2);
                if (seg.SubSegments[i].LineLabelDisplay == LineLabelDisplayMode.Hidden)
                    pe.Graphics.DrawLine(new Pen(disabledbrush, 2), LineLabelBounds[i].X + Padding, LineLabelBounds[i].Y + Padding, LineLabelBounds[i].X + LineLabelBounds[i].Width - 2 * Padding, LineLabelBounds[i].Y + LineLabelBounds[i].Height - 2 * Padding);
                #endregion

                #region Drawing Direction Arrows
                pe.Graphics.FillRectangle(DirectionBounds[i].Contains(Mouse) ? hoverbrush : whitebrush, DirectionBounds[i]);

                if (seg.SubSegments[i].Direction != SegmentDirection.Forward)
                {
                    pe.Graphics.TranslateTransform(DirectionBounds[i].X + CircleRadius, DirectionBounds[i].Y + CircleRadius);
                    pe.Graphics.DrawPath(new Pen(brush, 2), left_arrow_path);
                    pe.Graphics.ResetTransform();
                }

                if (seg.SubSegments[i].Direction != SegmentDirection.Backward)
                {
                    pe.Graphics.TranslateTransform(DirectionBounds[i].X + DirectionBounds[i].Width - CircleRadius, DirectionBounds[i].Y + CircleRadius);
                    pe.Graphics.DrawPath(new Pen(brush, 2), right_arrow_path);
                    pe.Graphics.ResetTransform();
                }

                pe.Graphics.DrawLine(new Pen(brush, 2), DirectionBounds[i].X + CircleRadius + Padding, DirectionBounds[i].Y + CircleRadius, DirectionBounds[i].X + DirectionBounds[i].Width - CircleRadius - Padding, DirectionBounds[i].Y + CircleRadius);
                #endregion
            }
        }
    }
}
