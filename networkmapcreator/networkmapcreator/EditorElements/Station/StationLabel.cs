using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetworkMapCreator.Station;

namespace NetworkMapCreator.EditorElements.Station
{
    public class StationLabel : AbstractStationLabel
    {
        public Font Font;
        public Color AutoColor = Color.Black;
        public StyleSet Style;
        public LabelPivot Pivot;

        public override Point Location { get; set; }
        public override string Content { get; set; }

        public override void Paint(Graphics g)
        {
            if (Font == null)
                return;

            /* Calculate label bounds */
            var _m = g.MeasureString(Content, Font);
            float txtw = _m.Width;
            float txth = _m.Height;

            Color cssTextColor, cssBackground;
            
            cssTextColor = Style.Color.GetColorAuto(AutoColor);
            cssBackground = Style.BackgroundColor.GetColorAuto(AutoColor);

            var cssBorder = Style.Border;

            /* Convert label pivot to actual coordinates */
            var p = Tools.Pivot2Point(Pivot);
            var textloc = new Point((int)(-p.X * txtw + Style.Padding.Left + Style.Margin.Left), (int)(-p.Y * txth + Style.Padding.Top + Style.Margin.Top));

            var _offset_x = 0;
            var _offset_y = 0;

            /* Calculate offset */
            switch (Style.Position)
            {
                case CSSPosition.Absolute:
                    if (Style.X.SizeMode == CSSSizeMode.Pixel)
                        _offset_x = Style.X.Value;
                    else
                        _offset_x = (int)Location.X;
                    if (Style.X.SizeMode == CSSSizeMode.Pixel)
                        _offset_y = Style.Y.Value;
                    break;

                case CSSPosition.Relative:
                    _offset_x = Location.X;
                    _offset_y = Location.Y;

                    if (Style.X.SizeMode == CSSSizeMode.Pixel)
                        _offset_x += Style.X.Value;
                    if (Style.Y.SizeMode == CSSSizeMode.Pixel)
                        _offset_y += Style.Y.Value;
                    break;
            }

            /* We move the label to its position */
            g.TranslateTransform(_offset_x, _offset_y);

            /* One line ends here */
            if (Line != null && prominence == Prominence.Default && seg_count == 1)
            {
                int line_x = textloc.X + (int)txtw + Style.Padding.Right + Style.Margin.Right;
                int line_y = textloc.Y - Style.Padding.Top - Style.Margin.Top; // restore original text location
                var cssBorderWidth = cssBorder.Width.SizeMode == CSSSizeMode.Pixel ? cssBorder.Width.Value : 1;
                var cssBorderColor = cssBorder.Color.GetColorAuto(AutoColor);

                g.FillRectangle(new SolidBrush(cssBackground), textloc.X - Style.Padding.Left, textloc.Y - Style.Padding.Top, txtw + Style.Padding.Left + Style.Padding.Right, txth + Style.Padding.Top + Style.Padding.Bottom);
                g.DrawRectangle(new Pen(cssBorderColor, cssBorderWidth), textloc.X - Style.Padding.Left, textloc.Y - Style.Padding.Top, txtw + Style.Padding.Left + Style.Padding.Right, txth + Style.Padding.Top + Style.Padding.Bottom);

                g.DrawString(Content, Font, new SolidBrush(cssTextColor), textloc);

                if (Line != null)
                    DrawLine(g, Line, (int)line_x, (int)line_y - 2, Font);
            }
            /* User wants to draw all ending lines or all lines */
            else if (Line != null && prominence == Prominence.Ending || prominence == Prominence.All)
            {
                /* recalc text bounds because we use the bold font here */
                _m = g.MeasureString(Content, Font);
                txtw = _m.Width;
                txth = _m.Height;
                textloc = new Point((int)(-Pivot2Point(Pivot).X * txtw), (int)(-Pivot2Point(Pivot).Y * txth));
                var trect = new RectangleF(-Pivot2Point(Pivot).X * txtw, -Pivot2Point(Pivot).Y * txth, txtw, txth);

                g.DrawString(Content, Font, new SolidBrush(cssTextColor), textloc);

                /* Draw the line labels */
                if (prominence == Prominence.Ending)
                    DrawLinesOnAnkerSide(g, lines_ending.ToArray(), trect);
                else
                    DrawLinesOnAnkerSide(g, Lines.ToArray(), trect);
            }
            else
                g.DrawString(Content, Font, new SolidBrush(cssTextColor), textloc);
        }
    }
}
