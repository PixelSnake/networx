using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using NetworkMapCreator.EditorElements;

namespace NetworkMapCreator
{
    public enum PlacementMode
    {
        None,
        Segment,
        Station,
        Sticker
    }

    public enum GridMode
    {
        None,
        Normal,
        X,
        Y,
        Stations,
        StationsX,
        StationsY
    }

    public class Map
    {
        public class MPen
        {
            public Color c1, c2;
            public Pen Pen;

            public MPen(Color c)
            {
                c1 = c;
                Pen = new Pen(c, DEFAULT_LINE_WIDTH);
            }
            public MPen(Color c1, Color c2)
            {
                this.c1 = c1;
                this.c2 = c2;
                Pen = new Pen(c1, DEFAULT_LINE_WIDTH);
            }
        }

        /* VERSION NUMBER INCREMENTING BY ONE */
        public static readonly byte TNBVersion = 0;
        /* ++++++++++++++++++++++++++++++++++ */

        public static ColorDialog ColorDialog = new ColorDialog();

        public static PrivateFontCollection fonts = new PrivateFontCollection();
        public static Font DefaultFont;
        public static Font DefaultFontB;
        public static Font LineFont;
        public static Font[] Fonts;

        public static float BRIGHTNESS_LIMIT = Color.Yellow.GetBrightness();

        public static int DEFAULT_LINE_WIDTH = 4;
        public static int SELECTED_LINE_WIDTH = 6;
        public static int LINE_DASH_LENGTH = 5;
        public static int STATION_MOUSE_SNAP_DIST = 20;
        public static int SEGMENT_MIDDLE_POINT_SNAP_DIST = 10;
        public static int GRID_SIZE = 30;
        public static int SEGMENT_DISPLAY_LINE_NAME_MIN_LENGTH = 150;
        public static int DEFAULT_CORNER_RADIUS = 5;

        public static Color default_color = Color.DarkGray;
        public static MPen default_pen = new MPen(default_color);

        public static Color SelectionColor = Color.FromArgb(0xFF, 0x00, 0xA2, 0xFF);
        public static Color SelectionColor1 = Color.FromArgb(0xFF, 0x00, 0xA2, 0xFF);
        public static Color SelectionColor2 = Color.FromArgb(0xFF, 0xFF, 0x5D, 0x00);


        public static StyleManager StyleManager = new StyleManager();

        public ObservableCollection<EditorElement> Selection = new ObservableCollection<EditorElement>();

        private Dictionary<Station, Dictionary<Station, Segment>> SegmentsMatrix = new Dictionary<Station, Dictionary<Station, Segment>>();
        public int SegmentsCount { get { return SegmentsMatrix.Count; } }
        public ObservableCollection<Station> Stations = new ObservableCollection<Station>();
        public ObservableCollection<Sticker> Stickers = new ObservableCollection<Sticker>();
        public ObservableCollection<Line> Lines = new ObservableCollection<Line>();
        public UndoManager UndoManager;

        public Point grid_offset = new Point(0, 0);
        public bool bend_node_mode = false;

        public Line current_line = null;

        public delegate void FilenameChangedEventHandler(string filename);
        public event FilenameChangedEventHandler FilenameChanged;
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;
                FilenameChanged?.Invoke(value);
            }
        }
        public string Filename { get { return Path.GetFileName(FullName); } }
        private string _fullname = "Untitled";

        public delegate void ColletionChangedEvent();
        public event ColletionChangedEvent SegmentsChanged;
        public event ColletionChangedEvent StationsChanged;
        public event ColletionChangedEvent StickersChanged;
        public event ColletionChangedEvent LinesChanged;

        static Map()
        {
            StyleManager.SetStylesheet(Program.APPDATA + "style/default.css");

            Directory.CreateDirectory(Program.APPDATA + "fonts");

            if (!File.Exists(Program.APPDATA + "fonts/font.ttf"))
                File.WriteAllBytes(Program.APPDATA + "fonts/font.ttf", Properties.Resources.Roboto_Regular);
            fonts.AddFontFile(Program.APPDATA + "fonts/font.ttf");
            DefaultFont = new Font(fonts.Families[0], 12f);
            LineFont = new Font(fonts.Families[0], 8f);

            if (!File.Exists(Program.APPDATA + "fonts/fontb.ttf"))
                File.WriteAllBytes(Program.APPDATA + "fonts/fontb.ttf", Properties.Resources.Roboto_Bold);
            fonts.AddFontFile(Program.APPDATA + "fonts/fontb.ttf");
            DefaultFontB = new Font(fonts.Families[0], 12f, FontStyle.Bold);
        }

        public Map()
        {
            Init();
        }

        public void Init()
        {
            UndoManager = new UndoManager();

            var flist = new List<Font>();
            for (int i = 0; i < 8; ++i)
                flist.Add(new Font(fonts.Families[0], (float)(8 + 1 + i)));
            Fonts = flist.ToArray();

            SegmentsMatrix = new Dictionary<Station, Dictionary<Station, Segment>>();
            Stations = new ObservableCollection<Station>();
            Stickers = new ObservableCollection<Sticker>();
            Lines = new ObservableCollection<Line>();
            AssignEvents();

            grid_offset = new Point(0, 0);
            bend_node_mode = false;
            current_line = null;
        }

        public void AssignEvents()
        {
            Stations.CollectionChanged += Stations_CollectionChanged;
            Stickers.CollectionChanged += Stickers_CollectionChanged;
            Lines.CollectionChanged += Lines_CollectionChanged;
        }

        private void Lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            LinesChanged?.Invoke();
        }

        private void Stickers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            StickersChanged?.Invoke();
        }

        private void Stations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            StationsChanged?.Invoke();
        }

        public void AllChanged()
        {
            SegmentsChanged?.Invoke();
            StationsChanged?.Invoke();
            StickersChanged?.Invoke();
            LinesChanged?.Invoke();
        }


        public void SelectNothing()
        {
            foreach (var e in Selection)
                e.SelectionModeChanged(false);
            Selection.Clear();
        }

        /* if selected: unselect, otherwise select */
        public void Select(EditorElement e)
        {
            if (Selection.Contains(e))
            {
                Selection.Remove(e);
                e.SelectionModeChanged(false);
            }
            else
            {
                Selection.Add(e);
                e.SelectionModeChanged(true);
            }
        }

        public void ForceSelect(EditorElement e)
        {
            if (!Selection.Contains(e))
            {
                Selection.Add(e);
                e.SelectionModeChanged(true);
            }
        }

        public Segment AddSegment(Station start, Station end)
        {
            if (start.ID < end.ID)
            {
                var t = end;
                end = start;
                start = t;
            }

            if (!SegmentsMatrix.ContainsKey(start))
                SegmentsMatrix.Add(start, new Dictionary<Station, Segment>());

            Segment segment;
            var column = SegmentsMatrix[start];

            if (!column.ContainsKey(end))
            {
                column.Add(end, (segment = new Segment(start, end, this)));
            }
            else
            {
                segment = column[end];
            }

            SegmentsChanged?.Invoke();
            return segment;
        }

        public Segment AddSegment(Station start, Station end, Line line)
        {
            var segment = AddSegment(start, end);
            segment.SubSegments.Add(new SubSegment(line));
            return segment;
        }

        public void ForEachSegment(Action<Segment> a)
        {
            foreach (var s in SegmentsMatrix.Values)
                foreach (var t in s.Values)
                    a(t);
        }

        public void ForEachSegmentWhile(Action<Segment> a, ref bool condition)
        {
            foreach (var s in SegmentsMatrix.Values)
                foreach (var t in s.Values)
                {
                    if (!condition)
                        return;

                    a(t);
                }
        }

        public void RemoveSegment(Segment s)
        {
            throw new NotImplementedException();
        }

        public void RemoveSegment(Station start, Station end)
        {
            if (start.ID < end.ID)
            {
                var t = end;
                end = start;
                start = t;
            }

            if (!SegmentsMatrix.ContainsKey(start))
                return;

            var column = SegmentsMatrix[start];

            if (!column.ContainsKey(end))
                return;

            column.Remove(end);
            SegmentsChanged?.Invoke();
        }

        public void ClearSegments()
        {
            SegmentsMatrix = new Dictionary<Station, Dictionary<Station, Segment>>();
        }
    }
}
