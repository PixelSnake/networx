using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NetworkMapCreator
{
    class StationLabelOffsetEditorPanel : Control
    {
        public Point LabelOffset = new Point();
        bool dragmode = false;
        Point center = new Point();

        public EventHandler OnOffsetChanged;

        public StationLabelOffsetEditorPanel()
        {
            this.Resize += new EventHandler(OnResize);
        }

        private void OnResize(object sender, EventArgs e)
        {
            center = new Point(Width / 2, Height / 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            int center_rect_width = 4;

            g.FillRectangle(new SolidBrush(Color.DarkGray),
                center.X - center_rect_width / 2,
                center.Y - center_rect_width / 2,
                center_rect_width,
                center_rect_width);

            g.DrawRectangle(new Pen(Color.Black, 1), 0, 0, Width - 1, Height - 1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
                dragmode = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (dragmode)
            {
                LabelOffset.X = e.Location.X - center.X;
                LabelOffset.Y = e.Location.Y - center.Y;
                OnOffsetChanged?.Invoke(this, new EventArgs());
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            dragmode = false;
        }
    }
}
