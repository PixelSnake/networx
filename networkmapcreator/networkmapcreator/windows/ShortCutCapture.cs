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
    public partial class ShortCutCapture : Form
    {
        bool ctrl = false;
        bool alt = false;
        bool shift = false;
        Keys key = 0;
        public string ShortcutString = "";
        public Keys Shortcut = 0;

        public ShortCutCapture()
        {
            InitializeComponent();
        }

        private void ShortCutCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                DialogResult = DialogResult.Abort;
                Close();
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (e.Modifiers == Keys.ControlKey || e.KeyCode == Keys.ControlKey)
                ctrl = true;
            if (e.Modifiers == Keys.Menu || e.KeyCode == Keys.Menu)
                alt = true;
            if (e.Modifiers == Keys.ShiftKey || e.KeyCode == Keys.ShiftKey)
                shift = true;
            if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey)
                key = e.KeyCode;
            UpdateShortcut();
        }

        private void ShortCutCapture_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.ControlKey || e.KeyCode == Keys.ControlKey)
                ctrl = false;
            if (e.Modifiers == Keys.Menu || e.KeyCode == Keys.Menu)
                alt = false;
            if (e.Modifiers == Keys.ShiftKey || e.KeyCode == Keys.ShiftKey)
                shift = false;
            if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey)
                key = 0;
            UpdateShortcut();
        }

        private void UpdateShortcut()
        {
            ShortcutString = "";
            if (ctrl)
                ShortcutString += "Ctrl + ";
            if (shift)
                ShortcutString += "Shift + ";
            if (alt)
                ShortcutString += "Alt + ";

            if (key != 0)
            {
                ShortcutString += key;
                if (ctrl)
                    Shortcut |= Keys.Control;
                if (alt)
                    Shortcut |= Keys.Alt;
                if (shift)
                    Shortcut |= Keys.Shift;
                Shortcut |= key;

                DialogResult = DialogResult.OK;
                Close();
            }

            if (ShortcutString.Equals(""))
                ShortcutString = "None";
            ShortcutDisplay.Text = ShortcutString;
        }
    }
}
