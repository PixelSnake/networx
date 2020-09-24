using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    class ShortCutButton : Button
    {
        public Keys Shortcut
        {
            get
            {
                return _shortcut;
            }
            set
            {
                _shortcut = value;
                Text = ParseShortcut(_shortcut);
            }
        }
        public Keys _shortcut = 0;

        public ShortCutButton()
        {
            
        }

        public ShortCutButton(Keys k)
        {
            Text = ParseShortcut(k);
        }

        private string ParseShortcut(Keys k)
        {
            string s = "";
            if ((k & Keys.Control) == Keys.Control)
                s += "Ctrl + ";
            if ((k & Keys.Shift) == Keys.Shift)
                s += "Shift + ";
            if ((k & Keys.Alt) == Keys.Alt)
                s += "Alt + ";

            var _k = k & ~Keys.Control & ~Keys.Alt & ~Keys.Shift;
            s += _k;

            return s;
        }

        protected override void OnClick(EventArgs e)
        {
            var s = new ShortCutCapture();
            var r = s.ShowDialog();

            if (r == DialogResult.OK)
                Text = ParseShortcut(_shortcut = s.Shortcut);
            else if (r == DialogResult.Abort)
            {
                Text = "None";
                _shortcut = 0;
            }
        }
    }
}
