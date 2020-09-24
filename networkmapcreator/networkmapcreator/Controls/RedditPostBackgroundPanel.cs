using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator.Controls
{
    public partial class RedditPostBackgroundPanel : Panel
    {
        public RedditPostBackgroundPanel()
        {
            InitializeComponent();

            DoubleBuffered = true;
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var g = pe.Graphics;

            g.DrawRectangle(new Pen(Color.Gray, 2), new Rectangle(0, 0, Width, Height));
        }
    }
}
