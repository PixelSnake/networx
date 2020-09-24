using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    public partial class ImageGrid : ListBox
    {
        public ImageGrid()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.ItemHeight = 32;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index <= -1)
                return;
            
            object item = this.Items[e.Index];
            if (item == null)
                return;

            var foreground = new SolidBrush(Color.Black);
            // Draw the background color depending on if the item is selected or not.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                foreground = new SolidBrush(Color.White);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }

            // Draw the item.
            if (item is IconsBrowserItem)
            {
                var i = (IconsBrowserItem)item;
                e.Graphics.DrawImage(i.Image, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height));
                string text = i.Description;
                SizeF stringSize = e.Graphics.MeasureString(text, this.Font);
                e.Graphics.DrawString(text, this.Font, foreground,
                    new PointF(e.Bounds.Height + 5, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2));
            }
            else
            {
                string text = item.ToString();
                SizeF stringSize = e.Graphics.MeasureString(text, this.Font);
                e.Graphics.DrawString(text, this.Font, foreground,
                    new PointF(5, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2));
            }
        }
    }
}
