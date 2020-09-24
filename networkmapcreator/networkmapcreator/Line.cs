using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NetworkMapCreator
{
    public class Line
    {
        public string Name;
        public string Comment;
        public Color c1;
        public Color c2;
        public bool IsAlternating { get { return c1 != Color.Transparent; } }

        public int Width { get { return _width; } set { _width = value; WidthChanged?.Invoke(this, value); } }
        private int _width = Map.DEFAULT_LINE_WIDTH;
        public delegate void WidthChangedEventHandler(Line sender, int Width);
        public event WidthChangedEventHandler WidthChanged;

        public bool IsBright { get { return c1.GetBrightness() >= Map.BRIGHTNESS_LIMIT; } }

        public Line(string name, Color c, string comment = "")
        {
            Name = name;
            Comment = comment;
            c1 = c;
        }

        public Line(string name, Color c1, Color c2, string comment = "")
        {
            Name = name;
            Comment = comment;
            this.c1 = c1;
            this.c2 = c2;
        }

        public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement ret = doc.CreateElement(string.Empty, "line", string.Empty);
            ret.SetAttribute("name", Name);
            ret.SetAttribute("comment", Comment);
            ret.SetAttribute("c1", c1.ToArgb() + "");
            ret.SetAttribute("c2", c2.ToArgb() + "");
            ret.SetAttribute("width", Width + "");
            return ret;
        }

        public byte[] CreateBinary()
        {
            var data = new List<byte>();

            var namebytes = Encoding.Unicode.GetBytes(Name);
            var namelen = namebytes.Length;

            data.AddRange(BitConverter.GetBytes(namelen));
            data.AddRange(namebytes);

            var commentbytes = Encoding.Unicode.GetBytes(Comment);
            var comentlen = commentbytes.Length;

            data.AddRange(BitConverter.GetBytes(comentlen));
            data.AddRange(commentbytes);

            data.AddRange(BitConverter.GetBytes(c1.ToArgb()));
            data.AddRange(BitConverter.GetBytes(c2.ToArgb()));

            data.AddRange(BitConverter.GetBytes((short)Width));

            return data.ToArray();
        }
    }
}
