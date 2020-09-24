using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NetworkMapCreator
{
    public partial class LineEditor : DockContent
    {
        Line line;
        public Color color1 = Color.Transparent, color2 = Color.Transparent;

        public LineEditor()
        {
            InitializeComponent();
            Reset(null);
            this.Bounds = new Rectangle(0, 0, 800, 800);
        }

        public LineEditor(Line l)
        {
            InitializeComponent();
            Reset(l);
        }

        private void Reset(Line l)
        {
            trackBar1.Value = Map.DEFAULT_LINE_WIDTH;

            if (l == null)
            {
                color1 = new Color();
                color2 = new Color();
                button3.BackColor = Color.FromArgb(0xe1e1e1);
                button4.BackColor = Color.FromArgb(0xe1e1e1);
                txtName.Text = "";
                trackBar1.Value = Map.DEFAULT_LINE_WIDTH;
                panel1.c1 = new Color();
                panel1.c2 = new Color();
                panel1.linewidth = Map.DEFAULT_LINE_WIDTH;
                panel1.Refresh();
                line = null;

                btnOk.Text = "Create";
            }
            else
            {
                color1 = l.c1;
                color2 = l.c2;
                button3.BackColor = color1;
                button4.BackColor = color2;
                txtName.Text = l.Name;
                trackBar1.Value = l.Width;
                panel1.c1 = l.c1;
                panel1.c2 = l.c2;
                panel1.linewidth = l.Width;
                panel1.Refresh();
                line = l;

                btnOk.Text = "Ok";
            }
        }

        private void LineEditor_Load(object sender, EventArgs e)
        {
            Height = 340;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var c = Map.ColorDialog;
            c.AnyColor = true;
            var r = c.ShowDialog();

            if (r == DialogResult.OK)
            {
                button3.BackColor = c.Color;
                color1 = c.Color;
                panel1.c1 = color1;
                panel1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var c = new ColorDialog();
            c.AnyColor = true;
            var r = c.ShowDialog();

            if (r == DialogResult.OK)
            {
                button4.BackColor = c.Color;
                color2 = c.Color;
                panel1.c2 = color2;
                panel1.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromKnownColor(KnownColor.Control);
            color2 = Color.Transparent;
            panel1.c2 = color2;
            panel1.Refresh();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            panel1.label = txtName.Text;
            panel1.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            panel1.linewidth = trackBar1.Value;
            panel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (color1 == null || color1 == Color.Transparent)
            {
                MessageBox.Show("Primary color must be set!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Name must be set!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (line == null)
            {
                if (color2 == null || color2 == Color.Transparent)
                {
                    var l = new Line(txtName.Text, color1);
                    l.Width = trackBar1.Value;
                    Form1.ActiveMap.Lines.Add(l);
                }
                else
                {
                    var l = new Line(txtName.Text, color1, color2);
                    l.Width = trackBar1.Value;
                    Form1.ActiveMap.Lines.Add(l);
                }
            }
            else
            {
                line.Name = txtName.Text;
                line.c1 = color1;
                line.c2 = color2;
                line.Width = trackBar1.Value;
            }

            if (DockState == DockState.Float)
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
                Reset(null);
        }
    }
}
