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
        public Color PrimaryColor
        {
            get
            {
                return _color1;
            }
            set
            {
                _color1 = PrimaryColorButton.BackColor = PreviewPanel.c1 = value;
            }
        }
        public Color SecondaryColor
        {
            get
            {
                return _color2;
            }
            set
            {
                _color2 = SecondaryColorButton.BackColor = PreviewPanel.c2 = value;
            }
        }
        private Color _color1 = Color.Transparent;
        private Color _color2 = Color.Transparent;

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
                PrimaryColor = new Color();
                SecondaryColor = new Color();
                PrimaryColorButton.BackColor = Color.FromArgb(0xe1e1e1);
                SecondaryColorButton.BackColor = Color.FromArgb(0xe1e1e1);
                txtName.Text = "";
                trackBar1.Value = Map.DEFAULT_LINE_WIDTH;
                PreviewPanel.linewidth = Map.DEFAULT_LINE_WIDTH;
                PreviewPanel.Refresh();
                line = null;

                btnOk.Text = "Create";
            }
            else
            {
                PrimaryColor = l.c1;
                SecondaryColor = l.c2;
                txtName.Text = l.Name;
                trackBar1.Value = l.Width;
                PreviewPanel.linewidth = l.Width;
                PreviewPanel.Refresh();
                line = l;

                btnOk.Text = "Ok";
            }
        }

        private void LineEditor_Load(object sender, EventArgs e)
        {
            Height = 340;
        }

        private void PrimaryColorButton_Click(object sender, EventArgs e)
        {
            var c = Map.ColorDialog;
            c.AnyColor = true;
            var r = c.ShowDialog();

            if (r == DialogResult.OK)
            {
                PrimaryColorButton.BackColor = c.Color;
                PrimaryColor = c.Color;
                PreviewPanel.c1 = PrimaryColor;
                PreviewPanel.Refresh();
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
                SecondaryColorButton.BackColor = c.Color;
                SecondaryColor = c.Color;
                PreviewPanel.c2 = SecondaryColor;
                PreviewPanel.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SecondaryColorButton.BackColor = Color.FromKnownColor(KnownColor.Control);
            SecondaryColor = Color.Transparent;
            PreviewPanel.c2 = SecondaryColor;
            PreviewPanel.Refresh();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            PreviewPanel.label = txtName.Text;
            PreviewPanel.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PreviewPanel.linewidth = trackBar1.Value;
            PreviewPanel.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PrimaryColor == null || PrimaryColor == Color.Transparent)
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
                if (SecondaryColor == null || SecondaryColor == Color.Transparent)
                {
                    var l = new Line(txtName.Text, PrimaryColor);
                    l.Width = trackBar1.Value;
                    Form1.ActiveMap.Lines.Add(l);
                }
                else
                {
                    var l = new Line(txtName.Text, PrimaryColor, SecondaryColor);
                    l.Width = trackBar1.Value;
                    Form1.ActiveMap.Lines.Add(l);
                }
            }
            else
            {
                line.Name = txtName.Text;
                line.c1 = PrimaryColor;
                line.c2 = SecondaryColor;
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
