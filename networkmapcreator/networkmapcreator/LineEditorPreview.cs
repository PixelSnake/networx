using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NetworkMapCreator
{
    class LineEditorPreview : Control
    {
        public string label = "";
        public int linewidth = Map.DEFAULT_LINE_WIDTH;
        public Color c1 = Color.Transparent;
        public Color c2 = Color.Transparent;

        public LineEditorPreview()
        {
            BackColor = Color.White;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            new System.Drawing.Extended.ExtendedGraphics(e.Graphics).DrawTwoToneLine(c1, c2, linewidth, Map.LINE_DASH_LENGTH, new Point(13, 13), new Point(Width - 13, 13));
            g.FillEllipse(new SolidBrush(c1), 5, 5, 15, 15);
            g.FillEllipse(new SolidBrush(c1), Width - 20, 5, 15, 15);
            int tw = (int)g.MeasureString(label, Map.LineFont).Width;
            g.FillRectangle(new SolidBrush(Color.White), (Width - 10) / 2 - tw / 2 - 3, 0, tw + 6, Height);
            g.DrawString(label, Map.LineFont, new SolidBrush(c1), (Width - 10) / 2 - tw / 2 - 1, 7);
        }
    }
}
