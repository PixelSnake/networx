using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NetworkMapCreator
{
    public class Sticker : Undoable, EditorElement
    {
        public Point Location
        {
            get
            {
                return Bounds.Location;
            }
            set
            {
                Bounds.Location = value;
            }
        }
        public Rectangle Bounds;
        
        public int Angle = 0;

        public bool IsHovered { get; private set; }
        public bool IsSelected { get; set; }

        public Image Image;

        public Sticker(Image img, Map m)
        {
            Map = m;
            Image = img;
            Init();
        }

        private void Init()
        {
            Bounds.Width = Image.Width;
            Bounds.Height = Image.Height;
            Angle = 0;
        }

        public bool MouseMove(MouseEventArgs e)
        {
            int padding = 5;
            IsHovered = new Rectangle(
                Bounds.X - padding,
                Bounds.Y - padding,
                Bounds.Width + 2 * padding,
                Bounds.Height + 2 * padding).Contains(e.Location);

            return IsHovered;
        }

        public void MouseDoubleClick(MouseEventArgs e)
        {
            if (IsHovered)
                new StickerEditor(this).ShowDialog();
        }

        public bool Select(Rectangle r)
        {
            return IsHovered;
        }

        public void SelectionModeChanged(bool selected)
        {
            IsSelected = selected;
        }

        public void Paint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var p = new Pen(Map.SelectionColor1, 3);
            var sb = new SolidBrush(Color.WhiteSmoke);
            int w = Bounds.Width;  int xo = w / 2;
            int h = Bounds.Height; int yo = h / 2;

            g.TranslateTransform(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2);
            g.RotateTransform(Angle);

            g.DrawImage(Image, -xo, -yo, Bounds.Width, Bounds.Height);

            if (IsSelected ||IsHovered)
            {
                g.DrawRectangle(p, -xo, -yo, w, h);
            }

            g.ResetTransform();
        }


        public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement ret = doc.CreateElement(string.Empty, "sticker", string.Empty);
            ret.SetAttribute("x", Bounds.X + "");
            ret.SetAttribute("y", Bounds.Y + "");
            ret.SetAttribute("width", Bounds.Width + "");
            ret.SetAttribute("height", Bounds.Height + "");
            ret.SetAttribute("angle", Angle + "");

            MemoryStream ms = new MemoryStream();
            Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = ms.ToArray();
            ret.SetAttribute("data", Convert.ToBase64String(bytes));

            return ret;
        }

        public byte[] CreateBinary()
        {
            var data = new List<byte>();

            data.AddRange(BitConverter.GetBytes(Bounds.X));
            data.AddRange(BitConverter.GetBytes(Bounds.Y));
            data.AddRange(BitConverter.GetBytes(Bounds.Width));
            data.AddRange(BitConverter.GetBytes(Bounds.Height));
            data.AddRange(BitConverter.GetBytes(Angle));

            MemoryStream ms = new MemoryStream();
            Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = ms.ToArray();
            data.AddRange(BitConverter.GetBytes(bytes.Count()));
            data.AddRange(bytes);

            return data.ToArray();
        }
    }
}
