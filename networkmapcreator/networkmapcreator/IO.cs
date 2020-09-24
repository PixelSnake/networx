using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NetworkMapCreator
{
    public class IO
    {
        public static bool Save(Map m)
        {
            return SaveAs(m, m.FullName);
        }

        public static bool SaveAs(Map m, string filename = null)
        {
            if (filename == null || m.FullName == "Untitled")
            {
                var d = new SaveFileDialog();
                d.Filter = "Transportation Network Map (*.tnm)|*.tnm|Transportation Network Map Binary (*.tnb)|*.tnb|All files (*.*)|*.*";
                var r = d.ShowDialog();

                if (r == DialogResult.OK)
                    filename = d.FileName;
                else
                    return false;
            }
            else
                filename = m.FullName;

            if (filename.EndsWith(".tnm"))
            {
                if (FileSavers.ASCII.ASCIISaver.Save(m, filename))
                {
                    AddRecent(filename);
                    return true;
                }

                return false;
            }
            else if (filename.EndsWith(".tnb"))
            {
                if (FileSavers.Binary.BinarySaver.Save(m, filename))
                {
                    AddRecent(filename);
                    return true;
                }

                return false;
            }
            else
                return false;
        }

        public static Map Load(string filename = "")
        {
            var m = new Map();

            if (filename == "" || filename == null)
            {
                var d = new OpenFileDialog();
                d.Filter = "Transportation Network Map (*.tnm, *.tnb)|*.tnm;*.tnb";
                var r = d.ShowDialog();

                if (r == DialogResult.OK)
                    filename = d.FileName;
                else
                    return null;
            }

            if (filename.EndsWith(".tnm"))
                m = LoadASCII(filename);
            else if (filename.EndsWith(".tnb"))
                m = LoadBinary(filename);
            else
                MessageBox.Show("Unsupported file format", "NetworX", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (m != null)
                m.UndoManager.Reset();

            return m;
        }

        public static Map LoadASCII(string filename)
        {
            try
            {
                AddRecent(filename);

                var doc = new XmlDocument();
                doc.Load(filename);

                var loader = FileLoaders.ASCII.ASCIILoader.CreateSuitableLoader(doc);
                if (loader == null)
                {
                    MessageBox.Show("This file is either not a transport network map file or it was created with a future version of NetworX. If you are using an older version or NetworX, you should consider installing the newest update.", "NetworX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                if (loader.IsDeprecated)
                    if (MessageBox.Show("This file has been created with an older version of NetworX. Loading it will convert it to the current version. Older versions of NetworX may then not be able to load this file anymore. Do you want to open and convert this file?", "NetworX", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return null;

                var m = loader.Load(doc);

                m.FullName = filename;
                m.AssignEvents();

                return m;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("'" + filename + "' is not a valid Transportation Network File.");
            }


            return null;
        }

        public static Map LoadBinary(string filename)
        {
            try
            {
                var m = new Map();
                m.Stations = new ObservableCollection<Station>();
                m.ClearSegments();
                m.Lines = new ObservableCollection<Line>();
                m.Stickers = new ObservableCollection<Sticker>();
                AddRecent(filename);

                var offset = 0;
                var data = System.IO.File.ReadAllBytes(filename);

                var header = Encoding.ASCII.GetString(data.SubArray(offset, 3));
                if (!header.Equals("TNB"))
                    throw new InvalidOperationException("The file is not a valid Transport Network Binary File.");
                offset += 3;

                var version = data[offset++];
                if (version != Map.TNBVersion)
                    throw new InvalidOperationException("The file is of an older version. Converting from older versions is not yet implemented.");

                while (offset < data.Length)
                {
                    switch (Encoding.ASCII.GetString(data.SubArray((offset += 4) - 4, 4)))
                    {
                        case "LINE":
                            var llines = new ObservableCollection<Line>();
                            var linesize = BitConverter.ToInt32(data, offset);
                            offset += 4;
                            var lineend = offset + linesize;

                            while (offset < lineend)
                            {
                                var id = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var NameSize = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var Name = "";
                                if (NameSize > 0)
                                    Name = Encoding.Unicode.GetString(data.SubArray(offset, NameSize));
                                offset += NameSize;

                                var CommentSize = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var Comment = "";
                                if (CommentSize > 0)
                                    Comment = Encoding.Unicode.GetString(data.SubArray(offset, CommentSize));
                                offset += CommentSize;

                                var Color1 = BitConverter.ToUInt32(data, offset);
                                offset += 4;
                                var Color2 = BitConverter.ToUInt32(data, offset);
                                offset += 4;

                                var Width = BitConverter.ToUInt16(data, offset);
                                offset += 2;

                                Color c1 = Color.FromArgb((int)Color1);
                                Color c2 = Color.FromArgb((int)Color2);
                                Line ll = new Line(Name, c1, c2, Comment);
                                ll.Width = Width;
                                llines.Add(ll);
                            }
                            m.Lines = llines;
                            break;

                        case "STAT":
                            var lstations = new ObservableCollection<Station>();
                            var statsize = BitConverter.ToInt32(data, offset);
                            offset += 4;
                            var statend = offset + statsize;

                            while (offset < statend)
                            {
                                var id = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var NameSize = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var Name = Encoding.Unicode.GetString(data.SubArray(offset, NameSize));
                                offset += NameSize;

                                var X = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var Y = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var Rotation = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var LabelX = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var LabelY = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var Pivot = (Station.LabelPivot)data[offset];
                                offset += 1;

                                var Prominence = (Station.Prominence)data[offset];
                                offset += 1;

                                var ns = new Station(m, Name, new Point(X, Y));
                                ns.RotationAngle = Rotation;
                                ns.LabelOffset.X = LabelX;
                                ns.LabelOffset.Y = LabelY;
                                ns.Pivot = Pivot;
                                ns.prominence = Prominence;

                                lstations.Add(ns);
                            }

                            m.Stations = lstations;
                            break;

                        case "SEGM":
                            var lsegments = new ObservableCollection<Segment>();
                            var segsize = BitConverter.ToInt32(data, offset);
                            offset += 4;
                            var segend = offset + segsize;

                            while (offset < segend)
                            {
                                var id = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var BeginID = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var EndID = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var MiddlepointX = BitConverter.ToSingle(data, offset);
                                offset += 4;

                                var MiddlepointY = BitConverter.ToSingle(data, offset);
                                offset += 4;

                                var DisplayLineLabel = (LineLabelDisplayMode)BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var LineMode = (SegmentLineMode)BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var LineID = BitConverter.ToInt16(data, offset);
                                offset += 2;

                                var a = m.Stations[BeginID];
                                var b = m.Stations[EndID];
                                var s = m.AddSegment(a, b, m.Lines[LineID]);
                                s.MiddlePoint = new PointF(MiddlepointX, MiddlepointY);
                                s.DisplayLineLabel = DisplayLineLabel;
                                s.LineMode = LineMode;

                                lsegments.Add(s);
                            }
                            break;

                        case "STKR":
                            var lstickers = new ObservableCollection<Sticker>();
                            var sticksize = BitConverter.ToInt32(data, offset);
                            offset += 4;
                            var stickend = offset + sticksize;

                            while (offset < stickend)
                            {
                                var x = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var y = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var w = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var h = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var angle = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var data_size = BitConverter.ToInt32(data, offset);
                                offset += 4;

                                var data_bytes = new List<byte>();
                                for (int i = 0; i < data_size; ++i)
                                    data_bytes.Add(data[offset + i]);
                                Image sticker_data;
                                using (var ms = new MemoryStream(data_bytes.ToArray()))
                                    sticker_data = Image.FromStream(ms);

                                offset += data_size;

                                var s = new Sticker(sticker_data, m);
                                s.Bounds = new Rectangle(x, y, w, h);
                                s.Angle = angle;

                                lstickers.Add(s);
                            }
                            m.Stickers = lstickers;
                            break;
                    }

                }

                return m;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("'" + filename + "' is not a valid Transportation Network File.");
            }

            return null;
        }

        public static void ExportToImage(Map m, DrawPanel p, string filename)
        {
            if (m.Stations.Count <= 0)
                return;

            var b = new Bitmap(1, 1);
            var g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int xmin = m.Stations[0].Location.X;
            int ymin = m.Stations[0].Location.Y;
            int xmax = xmin;
            int ymax = ymin;
            int margin = 20;

            foreach (var s in m.Stations)
            {
                var _s = g.MeasureString(s.Name, Map.DefaultFont);
                float tw = _s.Width;
                float th = _s.Height;
                PointF pivot = Station.Pivot2Point(s.Pivot);

                // without height and width
                int lx_ = (int)(s.Location.X + s.LabelOffset.X - pivot.X * tw) - margin;
                int ly_ = (int)(s.Location.Y + s.LabelOffset.Y - pivot.Y * th) - margin;
                // x and y with height and width
                int lxw = (int)(s.Location.X + s.LabelOffset.X + (pivot.X * tw + tw)) + margin * 2;
                int lyh = (int)(s.Location.Y + s.LabelOffset.Y + (pivot.Y * th + th)) + margin * 2;

                int x_ = Math.Max(lxw, s.Location.X);
                int y_ = Math.Max(lyh, s.Location.Y);
                int _x = Math.Min(lx_, s.Location.X);
                int _y = Math.Min(ly_, s.Location.Y);

                if (_x < xmin)
                    xmin = _x;
                if (_y < ymin)
                    ymin = _y;
                if (x_ > xmax)
                    xmax = x_;
                if (y_ > ymax)
                    ymax = y_;
            }

            foreach (var s in m.Stickers)
            {
                if (s.Bounds.X < xmin)
                    xmin = s.Bounds.X;
                if (s.Bounds.Y < ymin)
                    ymin = s.Bounds.Y;
                if (s.Bounds.X + s.Bounds.Width > xmax)
                    xmax = s.Bounds.X + s.Bounds.Width;
                if (s.Bounds.Y + s.Bounds.Height > ymax)
                    ymax = s.Bounds.Y + s.Bounds.Height;
            }


            foreach (var s in m.Stations)
            {
                s.Location = new Point(s.Location.X - xmin + margin, s.Location.Y - ymin + margin);
            }

            foreach (var s in m.Stickers)
            {
                s.Bounds.X -= xmin - margin;
                s.Bounds.Y -= ymin - margin;
            }

            int width = xmax - xmin + 2 * margin;
            int height = ymax - ymin + 2 * margin;

            b = new Bitmap(width, height);
            g = Graphics.FromImage(b);

            g.FillRectangle(new SolidBrush(Color.White), new RectangleF(0, 0, width, height));

            p.PaintTarget = g;
            p.Refresh();

            b.Save(filename);
            System.Diagnostics.Process.Start(filename);
        }

        public static List<string> LoadRecent()
        {
            var ret = new List<string>();

            if (!File.Exists(Program.APPDATA + "recent"))
            {
                Directory.CreateDirectory(Program.APPDATA);
                File.CreateText(Program.APPDATA + "recent");
                File.AppendAllText(Program.APPDATA + "recent", "example.tnm\n");
                return ret;
            }

            var list = File.ReadAllLines(Program.APPDATA + "recent");

            if (list.Length < 1)
                return ret;

            for (int i = list.Length - 1; i >= 0 && i >= list.Length - 6; --i)
                if (!ret.Contains(list[i]) && File.Exists(list[i]))
                    ret.Add(list[i]);

            return ret;
        }

        public static void AddRecent(string path)
        {
            var list = LoadRecent();
            list.Add(path); /* Add it anyway, so that it appears on the top */
            File.WriteAllLines(Program.APPDATA + "recent", list);
        }
    }
}