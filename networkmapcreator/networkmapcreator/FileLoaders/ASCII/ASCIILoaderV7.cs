using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkMapCreator.FileLoaders.ASCII
{
    public class ASCIILoaderV7 : ASCIILoader
    {
        public override bool IsDeprecated
        {
            get
            {
                return false;
            }
        }

        public override Map Load(XmlDocument doc)
        {
            var m = new Map();
            var content = doc["transport_network_map"];
            var grid = content["grid"];

            if (grid.GetAttribute("mode").Equals("False"))
                Program.GridMode = GridMode.None;
            else if (grid.GetAttribute("mode").Equals("True"))
                Program.GridMode = GridMode.Normal;
            else
                Program.GridMode = (GridMode)Enum.Parse(typeof(GridMode), grid.GetAttribute("mode"));

            m.grid_offset.X = int.Parse(grid.GetAttribute("offset_x"));
            m.grid_offset.Y = int.Parse(grid.GetAttribute("offset_y"));

            #region Lines Loading
            var lines = content["lines"];
            var llines = new ObservableCollection<Line>();
            foreach (var n in lines.ChildNodes)
            {
                var l = (XmlElement)n;

                string name = l.GetAttribute("name");
                string comment = l.GetAttribute("comment");
                int linewidth = Map.DEFAULT_LINE_WIDTH;
                try
                {
                    linewidth = int.Parse(l.GetAttribute("width"));
                }
                catch (FormatException) { }

                Color c1 = Color.FromArgb(int.Parse(l.GetAttribute("c1")));
                Color c2 = Color.FromArgb(int.Parse(l.GetAttribute("c2")));
                Line ll = new Line(name, c1, c2, comment);
                ll.Width = linewidth;
                llines.Add(ll);
            }
            m.Lines = llines;
            #endregion

            #region Stations Loading
            var stations = content["stations"];
            var lstations = new ObservableCollection<Station>();
            foreach (var n in stations.ChildNodes)
            {
                var s = (XmlElement)n;

                string name = s.GetAttribute("name");
                var p = new Point();
                p.X = int.Parse(s.GetAttribute("x"));
                p.Y = int.Parse(s.GetAttribute("y"));
                var ns = new Station(m, name, p);
                ns.RotationAngle = int.Parse(s.GetAttribute("rotation"));
                ns.label_offset.X = int.Parse(s.GetAttribute("label_x"));
                ns.label_offset.Y = int.Parse(s.GetAttribute("label_y"));
                try
                {
                    var X = float.Parse(s.GetAttribute("pivot_x"));
                    var Y = float.Parse(s.GetAttribute("pivot_y"));
                    ns.Pivot = Station.Point2Pivot(new PointF(X, Y));
                }
                catch (FormatException)
                {
                    ns.Pivot = (Station.LabelPivot)Enum.Parse(typeof(Station.LabelPivot), s.GetAttribute("pivot"));
                }

                string pro = s.GetAttribute("prominence");
                ns.prominence = pro.Equals("") ? Station.Prominence.Default : (Station.Prominence)Enum.Parse(typeof(Station.Prominence), pro);

                lstations.Add(ns);
            }
            m.Stations = lstations;
            #endregion

            #region Segments Loading
            m.ClearSegments();
            var segments = content["segments"];
            foreach (var _s in segments)
            {
                var seg = (XmlElement)_s;

                /* if a segment does not contain any subsegments it is empty and therefore invisible, so we skip this segment conpletely */
                if (!seg.HasChildNodes)
                    continue;


                int begin_id = int.Parse(seg.GetAttribute("begin"));
                int end_id = int.Parse(seg.GetAttribute("end"));

                Station a = lstations[begin_id];
                Station b = lstations[end_id];

                float mpx, mpy;
                if (!float.TryParse(seg.GetAttribute("middlepoint_x"), out mpx) ||
                    !float.TryParse(seg.GetAttribute("middlepoint_y"), out mpy))
                    mpx = mpy = 0.5f;

                LineLabelDisplayMode displaymode = LineLabelDisplayMode.Default;
                if (seg.HasAttribute("displaylinelabel"))
                    displaymode = (LineLabelDisplayMode)Enum.Parse(typeof(LineLabelDisplayMode), seg.GetAttribute("displaylinelabel"));

                SegmentLineMode linemode = SegmentLineMode.Straight;
                if (seg.HasAttribute("mode"))
                    linemode = (SegmentLineMode)Enum.Parse(typeof(SegmentLineMode), seg.GetAttribute("mode"));

                var segment = m.AddSegment(a, b);

                foreach (XmlElement subseg in seg.ChildNodes)
                {
                    int lineid;
                    if (!int.TryParse(subseg.GetAttribute("line"), out lineid))
                        return null;

                    SegmentDirection direction = SegmentDirection.Default;
                    if (subseg.HasAttribute("direction"))
                        direction = (SegmentDirection)Enum.Parse(typeof(SegmentDirection), subseg.GetAttribute("direction"));

                    var _sub = new SubSegment(llines[lineid]);

                    _sub.Direction = direction;

                    segment.SubSegments.Add(_sub);
                }

                segment.MiddlePoint = new PointF(mpx, mpy);
                segment.DisplayLineLabel = displaymode;
                segment.LineMode = linemode;
            }
            #endregion

            #region Loading Stickers
            m.Stickers = new ObservableCollection<Sticker>();
            try
            {
                var stickers = content["stickers"];
                var lstickers = new ObservableCollection<Sticker>();
                foreach (var _s in stickers)
                {
                    var stkr = (XmlElement)_s;

                    int sticker_x = int.Parse(stkr.GetAttribute("x"));
                    int sticker_y = int.Parse(stkr.GetAttribute("y"));
                    int sticker_width = int.Parse(stkr.GetAttribute("width"));
                    int sticker_height = int.Parse(stkr.GetAttribute("height"));
                    int sticker_angle = int.Parse(stkr.GetAttribute("angle"));
                    Image sticker_data;
                    using (var ms = new MemoryStream(Convert.FromBase64String(stkr.GetAttribute("data"))))
                        sticker_data = Image.FromStream(ms);

                    var s = new Sticker(sticker_data, m);
                    s.Bounds = new Rectangle(sticker_x, sticker_y, sticker_width, sticker_height);
                    s.Angle = sticker_angle;

                    lstickers.Add(s);
                }
                m.Stickers = lstickers;
            }
            catch (Exception) { }
            #endregion

            return m;
        }
    }
}
