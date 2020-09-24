using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
using System.Diagnostics;
using NetworkMapCreator.EditorElements;

namespace NetworkMapCreator
{
    public class DrawPanel : DockContent
    {
        public Stopwatch Watch = new Stopwatch();
        public Point Mouse;
        public bool dragging = false;
        public Station drag_origin;
        public bool mouse_is_down = false;
        public bool moving_elements = false;
        public bool moving_view = false;
        public Point mouse_origin = new Point();
        public bool select_mode = false;
        public Graphics PaintTarget;
        public float zoom = 1.0f;

        public Map Map;

        public Dictionary<EditorElement, Point> OldLocation = new Dictionary<EditorElement, Point>();

        public DrawPanel(Map m)
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            Text = m.Filename;
            Map = m;

            this.GotFocus += DrawPanel_GotFocus;
            this.FormClosing += DrawPanel_FormClosing;
            Icon = Icon.FromHandle(Properties.Resources.file_16.GetHicon());

            Map.FilenameChanged += Map_FilenameChanged;
        }

        private void DrawPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Map.Stations.Count == 0 && Map.SegmentsCount == 0 && Map.Lines.Count == 0 && Map.Stickers.Count == 0)
                return;

            var r = new Windows.PanelClosingConfirmBox(Map.Filename).ShowDialog();

            switch (r)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;

                case DialogResult.Yes: /* save */
                    if (!IO.Save(Map))
                        e.Cancel = true;
                    break;
            }
        }

        private void Map_FilenameChanged(string filename)
        {
            Text = Map.Filename;
        }

        private void DrawPanel_GotFocus(object sender, EventArgs e)
        {
            Form1.ActivePanel = this;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Graphics g;
            if (PaintTarget == null)
            {
                g = e.Graphics;
            }
            else
            {
                g = PaintTarget;
                zoom = 1.0f;
                PaintTarget = null;
            }

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (Program.GridMode != GridMode.None)
                DrawGrid(g);

            Map.ForEachSegment(new Action<Segment>((s) =>
            {
                if (!s.Deleted)
                    s.Paint(new PaintEventArgs(g, e.ClipRectangle));
            }));
            foreach (var s in Map.Stations)
            {
                if (!s.Deleted)
                    s.Paint(new PaintEventArgs(g, e.ClipRectangle));
            }
            foreach (var s in Map.Stickers)
            {
                if (!s.Deleted)
                    s.Paint(new PaintEventArgs(g, e.ClipRectangle));
            }

            if (dragging && Program.PlacementMode == PlacementMode.Segment)
                g.DrawLine(new Pen(Map.SelectionColor1, Map.DEFAULT_LINE_WIDTH), drag_origin.Location, Mouse);

            if (select_mode)
            {
                int x = Math.Min(Mouse.X, mouse_origin.X);
                int y = Math.Min(Mouse.Y, mouse_origin.Y);
                int w = Math.Abs(Mouse.X - mouse_origin.X);
                int h = Math.Abs(Mouse.Y - mouse_origin.Y);
                
                g.FillRectangle(new SolidBrush(Color.FromArgb(0x7F, Map.SelectionColor1)), x, y, w, h);
                g.DrawRectangle(new Pen(Map.SelectionColor1, 1), x, y, w, h);
            }

            watch.Stop();

            if (Program.Config.DisplayFPS)
                g.DrawString((1000 / Math.Max(1, watch.ElapsedMilliseconds)) + " fps", Map.DefaultFont, new SolidBrush(Color.Black), 5, 5);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            Point location = e.Location;
            Station station = null;

            station = SnapToNearestStation(e.Location);
            if (Program.GridMode != GridMode.None)
                if (station != null)
                    location = station.Location;
            else
                location = SnapToGrid(e.Location);

            if (Program.PlacementMode == PlacementMode.Station && (moving_elements || select_mode || station != null))
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    /* if not shift pressed: select nothing */
                    var multiple = ModifierKeys == Keys.Shift;
                    if (!multiple)
                        Map.SelectNothing();

                    switch (Program.PlacementMode)
                    {
                        case PlacementMode.None:
                            int rect_r = 5;
                            var r = new Rectangle(new Point(e.Location.X - rect_r, e.Location.Y - rect_r), new Size(2 * rect_r, 2 * rect_r));

                            var elems = new List<EditorElement>();
                            elems.AddRange(Map.Stations);
                            Map.ForEachSegment(new Action<Segment>((s) => { elems.Add(s); }));
                            elems.AddRange(Map.Stickers);

                            foreach (var elem in elems)
                            {
                                if (elem is Station)
                                {
                                    var s = elem as Station;

                                    if (!s.Deleted)
                                        if (s.Select())
                                        {
                                            Map.ForceSelect(s);
                                            if (!multiple)
                                                break;
                                        }
                                }
                                else if (elem is Segment)
                                {
                                    var s = elem as Segment;

                                    if (!s.Deleted)
                                        if (s.Select(r))
                                        {
                                            Map.Select(s);
                                            if (!multiple)
                                                break;
                                        }
                                }
                                else if (elem is Sticker)
                                {
                                    var s = elem as Sticker;

                                    if (!s.Deleted)
                                        if (s.Select(r))
                                        {
                                            Map.Select(s);
                                            if (!multiple)
                                                break;
                                        }
                                }
                            }
                            break;

                        case PlacementMode.Segment:
                            if (drag_origin != null && station == null && Map.current_line != null)
                            {
                                var s = new Station(Map, "Station " + Map.Stations.Count, location);
                                Map.Stations.Add(s);
                                station = s;
                            }
                            else if (station == null)
                                return;

                            if (drag_origin != null && Map.current_line != null)
                                Map.AddSegment(drag_origin, station, Map.current_line);

                            dragging = true;
                            drag_origin = station;                            
                            break;

                        case PlacementMode.Station:
                            Map.Stations.Add(new Station(Map, "Station " + Map.Stations.Count, location));
                            break;
                    }
                    break;

                case MouseButtons.Right:
                    OldLocation.Clear();
                    moving_elements = false;
                    dragging = false;
                    drag_origin = null;
                    break;
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            foreach (var x in Map.Stations)
                if (!x.Deleted)
                    x.MouseDoubleClick(e);
            foreach (var s in Map.Stickers)
                if (!s.Deleted)
                    s.MouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Watch.Restart();

            var multiple = ModifierKeys == Keys.Shift;
            mouse_is_down = true;
            Station s = FindNearestStation(e.Location);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (Program.PlacementMode == PlacementMode.None || Program.PlacementMode == PlacementMode.Station)
                    {
                        bool on_station = false;
                        if (s != null)
                        {
                            if (new Vector3(s.Location).Distance(new Vector3(e.Location)) < Map.STATION_MOUSE_SNAP_DIST)
                            {
                                if (!s.IsSelected && !multiple)
                                    Map.SelectNothing();

                                Map.ForceSelect(s);
                                break;
                            }
                        }

                        bool on_sticker = false;
                        foreach (var x in Map.Stickers)
                        {
                            if (x.Deleted)
                                continue;

                            if (x.IsHovered)
                            {
                                on_sticker = true;
                                Map.ForceSelect(x);
                                break;
                            }
                        }

                        bool not_on_segment = true;
                        Map.ForEachSegmentWhile(new Action<Segment>((x) =>
                        {
                            if (x.Deleted)
                                return;

                            if (x.IsMiddlePointHover)
                            {
                                not_on_segment = false;
                                Map.ForceSelect(x);
                                x.MouseDown(e);
                                return;
                            }
                        }), ref not_on_segment);

                        if (!not_on_segment)
                            break;

                        if (!on_station && !on_sticker && not_on_segment && Program.PlacementMode == PlacementMode.None)
                        {
                            Map.SelectNothing();

                            select_mode = true;
                            mouse_origin = e.Location;
                        }
                    }                        
                    break;

                case MouseButtons.Right:
                    moving_view = true;
                    Cursor = Cursors.SizeAll;
                    break;
            }

            mouse_origin = e.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point location = e.Location;
            if (Program.GridMode != GridMode.None)
                location = SnapToGrid(e.Location);
            Mouse = location;

            switch (e.Button)
            {
                case MouseButtons.None:
                    /* if an element is hovered, break here */
                    if (ElementsDistributeMouseMove(e))
                        break;
                    break;

                case MouseButtons.Left:
                    /* if an element is hovered, break here */
                    if (ElementsDistributeMouseMove(e) && !moving_elements)
                        break;



                    if (!moving_elements
                        && mouse_is_down
                        && Map.Selection.Count > 0
                        && Watch.ElapsedMilliseconds > 75) /* wait a short amount of time (75ms) before starting to drag
                        the object around. Otherwise the object would accidently get dragged when performing a double click */
                    {
                        foreach (var x in Map.Selection)
                            OldLocation.Add(x, x.Location);
                        var nearest = FindNearestElement(location, Map.Selection.ToList());
                        var dx = location.X - nearest.Location.X;
                        var dy = location.Y - nearest.Location.Y;

                        foreach (var x in Map.Selection)
                            x.Location = new Point(x.Location.X + dx, x.Location.Y + dy);

                        moving_elements = true;
                        Cursor = Cursors.SizeAll;
                    }

                    if (moving_elements)
                    {
                        int dx = location.X - mouse_origin.X;
                        int dy = location.Y - mouse_origin.Y;

                        if (Map.Selection.Count == 1)
                            Map.Selection[0].Location = location;
                        else
                            foreach (var elem in Map.Selection)
                                elem.Location = new Point(elem.Location.X + dx, elem.Location.Y + dy);

                        mouse_origin = location;
                    }
                    break;

                case MouseButtons.Right:
                    if (moving_view)
                    {
                        int dx = e.Location.X - mouse_origin.X;
                        int dy = e.Location.Y - mouse_origin.Y;

                        Map.grid_offset.X += dx;
                        Map.grid_offset.Y += dy;

                        foreach (var s in Map.Stations)
                        {
                            if (s.Deleted)
                                continue;

                            s.Location = new Point(s.Location.X + dx, s.Location.Y + dy);
                        }
                        foreach (var s in Map.Stickers)
                        {
                            if (s.Deleted)
                                continue;

                            s.Bounds.X += dx;
                            s.Bounds.Y += dy;
                        }
                        mouse_origin = e.Location;
                    }
                    break;
            }

            Refresh();
        }

        private bool ElementsDistributeMouseMove(MouseEventArgs e)
        {
            bool not_segment_found;

            switch (Program.PlacementMode)
            {
                case PlacementMode.None:
                    foreach (var x in Map.Stickers)
                        if (!x.Deleted)
                            if (x.MouseMove(e))
                                return true;
                    foreach (var x in Map.Stations)
                        if (!x.Deleted)
                            if (x.MouseMove(e))
                                return true;
                    not_segment_found = true;
                    Map.ForEachSegmentWhile(new Action<Segment>((x) =>
                    {
                        if (!x.Deleted)
                            if (x.MouseMove(e))
                                not_segment_found = false;
                    }), ref not_segment_found);
                    if (!not_segment_found)
                        return true;
                    break;

                case PlacementMode.Segment:
                case PlacementMode.Station:
                    foreach (var x in Map.Stations)
                        if (!x.Deleted)
                            if (x.MouseMove(e))
                                return true;
                    not_segment_found = true;
                    Map.ForEachSegmentWhile(new Action<Segment>((x) =>
                    {
                        if (!x.Deleted)
                            if (x.MouseMove(e))
                                not_segment_found = false;
                    }), ref not_segment_found);
                    if (!not_segment_found)
                        return true;
                    break;

                case PlacementMode.Sticker:
                    foreach (var x in Map.Stickers)
                        if (!x.Deleted)
                            if (x.MouseMove(e))
                                return true;
                    break;
            }

            return false;
        }
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            /* In case you are here, searching for the bug, that causes all but one station to be unselected after moving of multiple stations:
             The selection is already empty at this point. The search continues... */

            base.OnMouseUp(e);

            mouse_is_down = false;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    /* if not shift pressed */
                    var multiple = ModifierKeys == Keys.Shift;
                    var moved_elements = moving_elements;

                    Map.ForEachSegment(new Action<Segment>((s) =>
                    {
                        s.MouseUp(e); /* needed, so that the middlepoint can be released again */
                    }));

                    if (moving_elements)
                    {
                        foreach (var x in Map.Selection)
                        {
                            if (x is Station)
                            {
                                Map.UndoManager.Push(new UndoAction(UndoActionType.Modify, (Station)x, new UndoActionDataStation()
                                {
                                    Location = OldLocation[x]
                                }));
                                ((Station)x).LocationChanged(null);
                                Cursor = Cursors.Default;
                            }
                            else if (x is Sticker)
                            {
                                Map.UndoManager.Push(new UndoAction(UndoActionType.Modify, (Sticker)x, new UndoActionDataSticker()
                                {
                                    Location = OldLocation[x],
                                    Bounds = ((Sticker)x).Bounds
                                }));
                                Cursor = Cursors.Default;
                            }
                        }

                        moving_elements = false;
                        OldLocation.Clear();
                        Cursor = Cursors.Default;
                    }

                    if (select_mode)
                    {
                        /* if not multiple, then clear selection */
                        /* If moved elements were just released in this step, dont unselect them */
                        if (!multiple && !moved_elements)
                            Map.SelectNothing();

                        var selection = new Rectangle(Math.Min(Mouse.X, mouse_origin.X),
                                                       Math.Min(Mouse.Y, mouse_origin.Y),
                                                       Math.Abs(Mouse.X - mouse_origin.X),
                                                       Math.Abs(Mouse.Y - mouse_origin.Y));

                        foreach (var s in Map.Stations)
                            if (!s.Deleted)
                                if (s.InRect(selection))
                                    Map.Select(s);

                        Map.ForEachSegment(new Action<Segment>((s) =>
                        {
                            if (!s.Deleted)
                                if (s.Select(selection))
                                    Map.Select(s);
                        }));
                    }

                    select_mode = false;
                    break;

                case MouseButtons.Right:
                    moving_view = false;
                    Cursor = Cursors.Default;
                    break;
            }
        }

        public void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) /* up */
            {
                zoom += 0.1f;
            }
            else /* down */
            {
                zoom -= 0.1f;
            }

            Refresh();
        }

        private Station SnapToNearestStation(Point p)
        {
            /* snap to stations */
            var nearest_station = FindNearestStation(p);

            if (nearest_station != null)
                if (new Vector3(nearest_station.Location).Distance(new Vector3(p)) >= Map.STATION_MOUSE_SNAP_DIST)
                    nearest_station = null;

            return nearest_station;
        }

        private Station FindNearestStation(Point p)
        {
            int c = Map.Stations.Count;
            var loc = new Vector3(p);

            if (c == 0)
                return null;
            if (c == 1)
                return Map.Stations[0];

            Station nearest = Map.Stations[0];
            double ndist = loc.Distance(new Vector3(nearest.Location));

            foreach (var s in Map.Stations)
            {
                if (s.Deleted)
                    continue;

                double dist = loc.Distance(new Vector3(s.Location));

                if (dist < ndist)
                {
                    nearest = s;
                    ndist = dist;
                }
            }

            return nearest;
        }

        private EditorElement FindNearestElement(Point p, List<EditorElement> list)
        {
            int c = list.Count;
            var loc = new Vector3(p);

            if (c == 0)
                return null;
            if (c == 1)
                return list[0];

            var nearest = list[0];
            var ndist = loc.Distance(new Vector3(nearest.Location));

            foreach (var s in list)
            {
                if (s is Undoable && (s as Undoable).Deleted)
                    continue;

                double dist = loc.Distance(new Vector3(s.Location));

                if (dist < ndist)
                {
                    nearest = s;
                    ndist = dist;
                }
            }

            return nearest;
        }
        
        private Point SnapToGrid(Point p)
        {
            int x = p.X;
            int y = p.Y;
            int ox = 0;
            int oy = 0;

            switch (Program.GridMode)
            {
                case GridMode.Normal:
                    x = (p.X / Map.GRID_SIZE * Map.GRID_SIZE);
                    y = (p.Y / Map.GRID_SIZE * Map.GRID_SIZE);
                    ox = Map.grid_offset.X % Map.GRID_SIZE;
                    oy = Map.grid_offset.Y % Map.GRID_SIZE;
                    break;

                case GridMode.X:
                    y = (p.Y / Map.GRID_SIZE * Map.GRID_SIZE);
                    ox = Map.grid_offset.X % Map.GRID_SIZE;
                    oy = Map.grid_offset.Y % Map.GRID_SIZE;
                    break;

                case GridMode.Y:
                    x = (p.X / Map.GRID_SIZE * Map.GRID_SIZE);
                    ox = Map.grid_offset.X % Map.GRID_SIZE;
                    oy = Map.grid_offset.Y % Map.GRID_SIZE;
                    break;
            }
            
            return new Point(x + ox, y + oy);
        }

        private void DrawGrid(Graphics g)
        {
            if (Program.GridMode != GridMode.Y)
                for (int h = Map.grid_offset.Y % Map.GRID_SIZE; h < Height; h += Map.GRID_SIZE)
                    g.DrawLine(new Pen(Color.LightGray, 1), new Point(0, h), new Point(Width, h));

            if (Program.GridMode != GridMode.X)
                for (int w = Map.grid_offset.X % Map.GRID_SIZE; w < Width; w += Map.GRID_SIZE)
                    g.DrawLine(new Pen(Color.LightGray, 1), new Point(w, 0), new Point(w, Height));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawPanel
            // 
            this.ClientSize = new System.Drawing.Size(489, 275);
            this.Name = "DrawPanel";
            this.ResumeLayout(false);

        }
    }
}
