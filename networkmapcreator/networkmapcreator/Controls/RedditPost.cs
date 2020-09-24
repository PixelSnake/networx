using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator.Controls
{
    public partial class RedditPost : UserControl
    {
        public delegate void OnClickedEventArgs(object sender, EventArgs e);
        new public event OnClickedEventArgs Click;

        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                lblContent.Text = value.Substring(0, Math.Min(value.Length, 200)) + "...";
            }
        }
        private string _content;

        public RedditPost()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Click?.Invoke(sender, e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            Click?.Invoke(sender, e);
        }

        private void lblContent_Click(object sender, EventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
