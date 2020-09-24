using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkMapCreator.FileSavers.ASCII
{
    public class ASCIISaver
    {
        public static int Version = 7;

        public static bool Save(Map m, string filename)
        {
            /* List of stations, that have not been deleted */
            List<Station> StationsToSave = new List<Station>();
            foreach (var s in m.Stations)
                if (!s.Deleted)
                    StationsToSave.Add(s);

            try
            {
                var doc = new XmlDocument();

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement content = doc.CreateElement(string.Empty, "transport_network_map", string.Empty);
                content.SetAttribute("version", Version + "");
                doc.AppendChild(content);

                XmlElement grid = doc.CreateElement(string.Empty, "grid", string.Empty);
                content.AppendChild(grid);

                grid.SetAttribute("offset_x", m.grid_offset.X + "");
                grid.SetAttribute("offset_y", m.grid_offset.Y + "");
                grid.SetAttribute("mode", Program.GridMode + "");

                XmlElement stations = doc.CreateElement(string.Empty, "stations", string.Empty);
                content.AppendChild(stations);

                for (int i = 0; i < StationsToSave.Count; ++i)
                {
                    XmlElement st = StationsToSave[i].CreateXml(doc);
                    st.SetAttribute("id", i + "");
                    stations.AppendChild(st);
                }

                XmlElement segments = doc.CreateElement(string.Empty, "segments", string.Empty);
                content.AppendChild(segments);

                m.ForEachSegment(new Action<Segment>((s) =>
                {
                    if (s.Deleted)
                        return;

                    XmlElement sg = s.CreateXml(m, doc, StationsToSave);
                    segments.AppendChild(sg);
                }));

                XmlElement lines = doc.CreateElement(string.Empty, "lines", string.Empty);
                content.AppendChild(lines);

                for (int i = 0; i < m.Lines.Count; ++i)
                {
                    XmlElement sl = m.Lines[i].CreateXml(doc);
                    sl.SetAttribute("id", i + "");
                    lines.AppendChild(sl);
                }

                XmlElement stickers = doc.CreateElement(string.Empty, "stickers", string.Empty);
                content.AppendChild(stickers);

                for (int i = 0; i < m.Stickers.Count; ++i)
                {
                    XmlElement sl = m.Stickers[i].CreateXml(doc);
                    sl.SetAttribute("id", i + "");
                    stickers.AppendChild(sl);
                }

                doc.Save(filename);
            }
            catch (Exception e)
            {
                return false;
            }

            m.FullName = filename;
            return true;
        }
    }
}
