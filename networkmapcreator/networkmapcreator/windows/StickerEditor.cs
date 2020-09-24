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
    public partial class StickerEditor : Form
    {
        List<Sticker> Stickers = new List<Sticker>();
        List<Sticker> Originals = new List<Sticker>();

        public StickerEditor(Sticker s)
        {
            InitializeComponent();
            var scopy = new Sticker(s.Image, null);
            scopy.Angle = s.Angle;
            scopy.Bounds = new Rectangle(s.Bounds.X, s.Bounds.Y, s.Bounds.Width, s.Bounds.Height);
            Originals.Add(scopy);

            Stickers.Add(s);
            RotationNumber.Value = RotationTrackBar.Value = s.Angle;
            WidthNumber.Value = s.Bounds.Width;
            HeightNumber.Value = s.Bounds.Height;
        }

        public StickerEditor(Sticker[] stickers)
        {
            foreach (var s in stickers)
            {
                var scopy = new Sticker(s.Image, null);
                scopy.Angle = s.Angle;
                scopy.Bounds = new Rectangle(s.Bounds.X, s.Bounds.Y, s.Bounds.Width, s.Bounds.Height);
                Originals.Add(scopy);
                Stickers.Add(s);
            }
        }

        private void RotationTrackBar_ValueChanged(object sender, EventArgs e)
        {
            RotationNumber.Value = RotationTrackBar.Value;
            RotationChanged(RotationTrackBar.Value);
        }

        private void RotationNumber_ValueChanged(object sender, EventArgs e)
        {
            RotationTrackBar.Value = (int)RotationNumber.Value;
            RotationChanged(RotationTrackBar.Value);
        }

        private void RotationChanged(int rotation)
        {
            foreach (var s in Stickers)
                s.Angle = rotation;
            Form1.ActivePanel.Refresh();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Originals.Count; ++i)
            {
                Stickers[i].Angle = Originals[i].Angle;
                Stickers[i].Image = Originals[i].Image;
                Stickers[i].Bounds = Originals[i].Bounds;
            }

            DialogResult = DialogResult.Abort;
            Close();
        }

        private void buttonImageBrowse_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.ico)|*.jpg;*.jpeg;*.png;*.ico";

            if (fd.ShowDialog() == DialogResult.OK)
                foreach (var s in Stickers)
                {
                    var img = Image.FromFile(fd.FileName);

                    if ((double)s.Bounds.Width / s.Bounds.Height != (double)img.Width / img.Height)
                    {
                        var res = MessageBox.Show("The new image has a different aspect ration than the old image. Do you want to change the aspect ratio?", "NetworX", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            s.Image = img;
                            s.Bounds = new Rectangle(s.Bounds.X, s.Bounds.Y, s.Image.Width, s.Image.Height);
                        }
                        else if (res == DialogResult.No)
                            s.Image = img;
                    }
                    else
                        s.Image = img;
                }
        }

        private void WidthNumber_ValueChanged(object sender, EventArgs e)
        {
            foreach (var s in Stickers)
            {
                var ratio = (double)s.Bounds.Height / (double)s.Bounds.Width;
                s.Bounds.Width = (int)WidthNumber.Value;
                if (AspectToggle.Checked)
                    HeightNumber.Value = s.Bounds.Height = (int)(ratio * s.Bounds.Width);
            }
            Form1.ActivePanel.Refresh();
        }

        private void HeightNumber_ValueChanged(object sender, EventArgs e)
        {
            foreach (var s in Stickers)
            {
                var ratio = (double)s.Bounds.Width / (double)s.Bounds.Height;
                s.Bounds.Height = (int)HeightNumber.Value;
                if (AspectToggle.Checked)
                    WidthNumber.Value = s.Bounds.Width = (int)(ratio * s.Bounds.Height);
            }
            Form1.ActivePanel.Refresh();
        }
    }
}
