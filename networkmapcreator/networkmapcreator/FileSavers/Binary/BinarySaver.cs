using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMapCreator.EditorElements;

namespace NetworkMapCreator.FileSavers.Binary
{
    public class BinarySaver
    {
        public static bool Save(Map m, string filename)
        {
            try
            {
                var data = new List<byte>();

                var StationsToSave = new List<Station>();
                foreach (var s in m.Stations)
                    if (!s.Deleted)
                        StationsToSave.Add(s);
                var SegmentsToSave = new List<Segment>();
                m.ForEachSegment(new Action<Segment>((s) =>
                {
                    if (!s.Deleted)
                        SegmentsToSave.Add(s);
                }));
                var StickersToSave = new List<Sticker>();
                foreach (var s in m.Stickers)
                    if (!s.Deleted)
                        StickersToSave.Add(s);

                /* TNB Header */
                data.AddRange(Encoding.ASCII.GetBytes("TNB"));

                /* TNB Version */
                data.Add(Map.TNBVersion);

                /* Lines Chunk*/
                data.AddRange(Encoding.ASCII.GetBytes("LINE"));
                var line = new List<byte>();

                for (short i = 0; i < m.Lines.Count; ++i)
                {
                    line.AddRange(BitConverter.GetBytes(i));
                    line.AddRange(m.Lines[i].CreateBinary());
                }
                data.AddRange(BitConverter.GetBytes(line.Count));
                data.AddRange(line.ToArray());

                /* Stations Chunk*/
                data.AddRange(Encoding.ASCII.GetBytes("STAT"));
                var stat = new List<byte>();

                for (short i = 0; i < StationsToSave.Count; ++i)
                {
                    stat.AddRange(BitConverter.GetBytes(i));
                    stat.AddRange(StationsToSave[i].CreateBinary());
                }
                data.AddRange(BitConverter.GetBytes(stat.Count));
                data.AddRange(stat.ToArray());

                /* Segments Chunk*/
                data.AddRange(Encoding.ASCII.GetBytes("SEGM"));
                var segm = new List<byte>();

                for (short i = 0; i < SegmentsToSave.Count; ++i)
                {
                    segm.AddRange(BitConverter.GetBytes(i)); // id
                    segm.AddRange(SegmentsToSave[i].CreateBinary(m, StationsToSave));
                }
                data.AddRange(BitConverter.GetBytes(segm.Count));
                data.AddRange(segm.ToArray());

                /* Stickers Chunk */
                data.AddRange(Encoding.ASCII.GetBytes("STKR"));
                var stkr = new List<byte>();

                for (short i = 0; i < StickersToSave.Count; ++i)
                    stkr.AddRange(StickersToSave[i].CreateBinary());

                data.AddRange(BitConverter.GetBytes(stkr.Count));
                data.AddRange(stkr.ToArray());

                System.IO.File.WriteAllBytes(filename, data.ToArray());
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
