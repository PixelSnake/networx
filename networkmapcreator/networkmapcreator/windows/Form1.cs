using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;
using NetworkMapCreator.EditorElements;

namespace NetworkMapCreator
{
    public partial class Form1 : Form
    {
        public static DrawPanel ActivePanel
        {
            get { return _activepanel; }
            set
            {
                _activepanel = value;
                ActivePanelChanged?.Invoke(value);
            }
        }
        private static DrawPanel _activepanel;
        public static Map ActiveMap { get { return ActivePanel?.Map; } }

        public static List<DrawPanel> Files = new List<DrawPanel>();
        public delegate void ActivePanelChangedEventHandler(DrawPanel p);
        public static event ActivePanelChangedEventHandler ActivePanelChanged;

        private static VS2015ThemeBase lightTheme = new VS2015LightTheme();


        private StationDockingPointEditor StationDockingPointEditor;
        private SegmentEditor SegmentEditor;
        private IconsBrowser IconsBrowser;
        private LinesOverview LineOverview;
        private StationsOverview StationsOverview;
        private SegmentsOverview SegmentsOverview;
        private LineEditor LineEditor;

        public Form1(string[] args)
        {
            InitializeComponent();

            DockPanel.Theme = lightTheme;

            ActivePanelChanged += Form1_ActivePanelChanged;

            if (args.Length > 0)
            {
                foreach (var f in args)
                    if (System.IO.File.Exists(f))
                        AddFile(new DrawPanel(IO.Load(f)));
                ActivePanel = Files.LastOrDefault();
            }
            else
            {
                var wp = new WelcomePage(this);
                wp.Show(DockPanel, DockState.Document);

                //AddFile(new DrawPanel(new Map()));
                ActivePanel = Files.LastOrDefault();

                wp.Activate();
            }

            LoadShortcuts();

            StationDockingPointEditor = new StationDockingPointEditor(null);
            SegmentEditor = new SegmentEditor();
            IconsBrowser = new IconsBrowser();
            LineOverview = new LinesOverview();
            StationsOverview = new StationsOverview();
            SegmentsOverview = new SegmentsOverview();
            LineEditor = new LineEditor();

            StationDockingPointEditor.Show(DockPanel, DockState.DockLeftAutoHide);
            SegmentEditor.Show(DockPanel, DockState.DockLeftAutoHide);
            IconsBrowser.Show(DockPanel, DockState.DockRightAutoHide);

            Program.CheckUpdates();
        }

        private void Form1_ActivePanelChanged(DrawPanel p)
        {
            if (p == null)
            {
                Text = "NetworX";
                return;
            }

            FillLinesIntoComboBox();
            Text = p.Map.FullName + " - NetworX";
        }

        public void LoadShortcuts()
        {
            try
            {
                var doc = new XmlDocument();

                doc.Load(Program.APPDATA + "shortcuts.xml");
                var shortcuts = doc["shortcuts"];

                newToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScFileNew"].GetAttribute("shortcut"));
                openToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScFileOpen"].GetAttribute("shortcut"));
                saveToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScFileSave"].GetAttribute("shortcut"));
                saveAsToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScFileSaveAs"].GetAttribute("shortcut"));
                exportImageToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScFileExportImage"].GetAttribute("shortcut"));
                exportSVGToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScFileExportSVG"].GetAttribute("shortcut"));

                undoToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScEditUndo"].GetAttribute("shortcut"));
                redoToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScEditRedo"].GetAttribute("shortcut"));
                openTrackEditorToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScEditTrackEditor"].GetAttribute("shortcut"));
                openStationEditorToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScEditStationEditor"].GetAttribute("shortcut"));
                openConnectionEditorToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScConnectionEditor"].GetAttribute("shortcut"));
                selectStylesheetToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScEditSelectStylesheet"].GetAttribute("shortcut"));
                settingsToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScEditSettings"].GetAttribute("shortcut"));

                linesToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScViewLinesOverview"].GetAttribute("shortcut"));
                segmentsOverviewToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScViewSegmentsOverview"].GetAttribute("shortcut"));
                stationsToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScViewStationsOverview"].GetAttribute("shortcut"));

                selectToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScToolsSelect"].GetAttribute("shortcut"));
                createToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScToolsCreate"].GetAttribute("shortcut"));
                connectToolStripMenuItem.ShortcutKeys = (Keys)int.Parse(shortcuts["ScToolsConnect"].GetAttribute("shortcut"));
            }
            catch (InvalidEnumArgumentException)
            {
                MessageBox.Show("Invalid shortcut: Shortcuts must contain Ctrl, Alt or an F-key", "NetworX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new frmSettings().ShowDialog(this);
            }
            catch (Exception)
            {

            }
        }

        private void SetPlacementMode(PlacementMode m)
        {
            Program.PlacementMode = m;

            switch (m)
            {
                case PlacementMode.None:
                    toolSelect.BackColor = Color.LightSteelBlue;
                    toolStation.BackColor = Color.Transparent;
                    toolConnect.BackColor = Color.Transparent;
                    return;

                case PlacementMode.Station:
                    toolStation.BackColor = Color.LightSteelBlue;
                    toolSelect.BackColor = Color.Transparent;
                    toolConnect.BackColor = Color.Transparent;
                    return;

                case PlacementMode.Segment:
                    toolConnect.BackColor = Color.LightSteelBlue;
                    toolSelect.BackColor = Color.Transparent;
                    toolStation.BackColor = Color.Transparent;
                    return;
            }
        }

        private void LoadRecentFiles()
        {
            var list = IO.LoadRecent();
            recentFilesToolStripMenuItem.DropDownItems.Clear();

            if (list.Count == 0)
            {
                noRecentFilesToolStripMenuItem.Visible = true;
                return;
            }

            for (int i = 0; i < 10 && i < list.Count; ++i)
            {
                var ddi = new ToolStripMenuItem(list[i]);
                recentFilesToolStripMenuItem.DropDownItems.Add(ddi);
                ddi.Click += (sender, e) => { AddFile(new DrawPanel(IO.Load(((ToolStripMenuItem)sender).Text))); };
                noRecentFilesToolStripMenuItem.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboLines_SelectedIndexChanged(sender, e);
        }

        private void btnNewStation_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.Station);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.None);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (ModifierKeys.HasFlag(Keys.Control))
                        ActivePanel.Close();
                    break;

                case Keys.Tab:
                    if (ModifierKeys.HasFlag(Keys.Control))
                    {
                        var list = DockPanel.Documents.ToList();
                        var index = list.IndexOf(ActivePanel);
                        if (ModifierKeys.HasFlag(Keys.Shift))
                            ((DockContent)list[(index + 1) % list.Count]).Activate();
                        else
                            ((DockContent)list[(index - 1) % list.Count]).Activate();
                    }
                    break;

                case Keys.G:
                    Program.GridMode = Program.GridMode == GridMode.None ? GridMode.Normal : GridMode.None;
                    ActivePanel.Refresh();
                    break;

                case Keys.X:
                    if (Program.GridMode == GridMode.Normal)
                        Program.GridMode = GridMode.X;
                    else if (Program.GridMode == GridMode.X)
                        Program.GridMode = GridMode.Normal;

                    ActivePanel.Refresh();
                    break;

                case Keys.Y:
                    if (Program.GridMode == GridMode.Normal)
                        Program.GridMode = GridMode.Y;
                    else if (Program.GridMode == GridMode.Y)
                        Program.GridMode = GridMode.Normal;

                    ActivePanel.Refresh();
                    break;

                case Keys.Delete:
                    List<Station> selected_stations = new List<Station>();
                    foreach (var s in ActiveMap.Stations)
                        if (s.IsSelected)
                            selected_stations.Add(s);

                    if (selected_stations.Count > 0)
                    {
                        var segs_to_delete = new List<Segment>();
                        var actions = new List<UndoAction>();

                        foreach (var s in selected_stations)
                        {
                            s.Delete(false);
                            segs_to_delete.AddRange(s.SegmentsLeft);
                            segs_to_delete.AddRange(s.SegmentsTop);
                            segs_to_delete.AddRange(s.SegmentsRight);
                            segs_to_delete.AddRange(s.SegmentsBottom);

                            actions.Add(new UndoAction(UndoActionType.Delete, s));
                        }

                        foreach (var seg in segs_to_delete)
                        {
                            seg.Delete(false);
                            actions.Add(new UndoAction(UndoActionType.Delete, seg));
                        }

                        ActiveMap.UndoManager.Push(new UndoAction(UndoActionType.Multiple, null, null, actions));
                    }

                    List<Segment> selected_segments = new List<Segment>();
                    ActiveMap.ForEachSegment(new Action<Segment>((s) =>
                    {
                        if (s.IsSelected && !s.Deleted)
                            selected_segments.Add(s);
                    }));

                    if (selected_segments.Count > 0)
                    {
                        var actions = new List<UndoAction>();

                        foreach (var s in selected_segments)
                        {
                            s.Begin.RemoveSegment(s);
                            s.End.RemoveSegment(s);
                            s.Delete(false);
                            actions.Add(new UndoAction(UndoActionType.Delete, s));
                        }

                        ActiveMap.UndoManager.Push(new UndoAction(UndoActionType.Multiple, null, null, actions));
                    }

                    List<Sticker> selected_stickers = new List<Sticker>();
                    foreach (var s in ActiveMap.Stickers)
                        if (s.IsSelected && !s.Deleted)
                            selected_stickers.Add(s);

                    if (selected_stickers.Count > 0)
                    {
                        var actions = new List<UndoAction>();
                        foreach (var s in selected_stickers)
                        {
                            s.Delete();
                            actions.Add(new UndoAction(UndoActionType.Delete, s));
                        }

                        ActiveMap.UndoManager.Push(new UndoAction(UndoActionType.Multiple, null, null, actions));
                    }
                    break;
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var r = new LineEditor().ShowDialog();
        }

        private void LinesChanged()
        {
            FillLinesIntoComboBox();
        }

        public void FillLinesIntoComboBox()
        {
            if (ActiveMap == null)
                return;

            toolComboLines.Items.Clear();
            foreach (var l in ActiveMap.Lines)
                toolComboLines.Items.Add(l.Name);

            connectToolStripMenuItem.Enabled = toolConnect.Enabled = false;
        }

        private void comboLines_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (e.Index < 0
                || e.Index >= ((ComboBox)sender).Items.Count
                || e.Index >= ActiveMap.Lines.Count)
                return;

            string text = ((ComboBox)sender).Items[e.Index].ToString() + "(" + ActiveMap.Lines[e.Index].Comment + ")";

            var brush = new SolidBrush(ActiveMap.Lines[e.Index].c1);
            var brush2 = new SolidBrush(ActiveMap.Lines[e.Index].c2);
            var wbrush = new SolidBrush(Color.White);
            var bbrush = new SolidBrush(Color.Black);

            e.Graphics.FillRectangle(brush, e.Bounds);

            if (!ActiveMap.Lines[e.Index].c1.Equals(ActiveMap.Lines[e.Index].c2))
                e.Graphics.FillPolygon(brush2, new Point[] {
                    new Point(e.Bounds.X, e.Bounds.Y + e.Bounds.Height),
                    new Point(e.Bounds.X + e.Bounds.Width, e.Bounds.Y),
                    new Point(e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height)
                        });

            if (brush.Color.GetBrightness() < Color.Gray.GetBrightness())
                e.Graphics.DrawString(text, ((Control)sender).Font, wbrush, e.Bounds.X, e.Bounds.Y);
            else
                e.Graphics.DrawString(text, ((Control)sender).Font, bbrush, e.Bounds.X, e.Bounds.Y);
        }

        private void comboLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolComboLines.SelectedIndex < 0 || toolComboLines.SelectedIndex >= ActiveMap.Lines.Count)
                return;

            if (toolComboLines.Text.Equals(""))
            {
                connectToolStripMenuItem.Enabled =  toolConnect.Enabled = false;
                return;
            }
            else
                connectToolStripMenuItem.Enabled =  toolConnect.Enabled = true;

            Line current = ActiveMap.Lines[toolComboLines.SelectedIndex] ?? null;

            if (current == null)
            {
                connectToolStripMenuItem.Enabled =  toolConnect.Enabled = false;
                SetPlacementMode(PlacementMode.None);
                MessageBox.Show("Internal error, please try selecting another line");
            }
            else
            {
                ActiveMap.current_line = current;
            }

            SetPlacementMode(PlacementMode.Segment);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IO.Save(ActiveMap);
            LoadRecentFiles();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)    
        {
            File_Open();
        }

        public void AddFile(DrawPanel p)
        {
            Files.Add(p);
            p.Disposed += (s, e) => { Files.Remove(p); };
            p.Map.LinesChanged += LinesChanged;
            p.Show(DockPanel, DockState.Document);
        }

        private void File_Open()
        {
            var m = IO.Load();

            if (m == null)
                return;

            AddFile(new DrawPanel(m));
            LoadRecentFiles();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_New();
        }

        private void File_New()
        {
            var p = new DrawPanel(new Map());
            AddFile(p);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IO.SaveAs(ActiveMap);
        }

        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineOverview.IsDisposed)
                LineOverview = new LinesOverview();
            LineOverview.Show(DockPanel, DockState.Float);
        }

        private void openTrackEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SegmentEditor.IsDisposed)
                SegmentEditor = new SegmentEditor();
            SegmentEditor.Show(DockPanel, DockState.Float);
        }

        private void openStationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stat = new List<Station>();
            foreach (var s in ActiveMap.Stations)
                if (s.IsSelected)
                    stat.Add(s);
            if (new StationEditor(stat.ToArray()).ShowDialog() == DialogResult.OK)
                Refresh();
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new SaveFileDialog();
            d.Filter = "PNG Images (*.png)|*.png|JPG Images (*.jpg)|*.jpg|BMP Images (*.bmp)|*.bmp";
            d.FileName = ActiveMap.FullName.Split('\\').Last().Replace(".tnm", "").Replace(".tnb", "");
            if (d.ShowDialog() == DialogResult.OK)
                IO.ExportToImage(ActiveMap, ActivePanel, d.FileName);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void stationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StationsOverview.IsDisposed)
                StationsOverview = new StationsOverview();
            StationsOverview.Show(DockPanel, DockState.Float);
        }
        
        private void segmentsOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SegmentsOverview.IsDisposed)
                SegmentsOverview = new SegmentsOverview();
            SegmentsOverview.Show(DockPanel, DockState.Float);
        }

        private void SelectionAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (Map.SelectionColor.Equals(Map.SelectionColor1))
                Map.SelectionColor = Map.SelectionColor2;
            else
                Map.SelectionColor = Map.SelectionColor1;
            Refresh();
        }

        private void selectStylesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            Directory.CreateDirectory(Program.APPDATA + "style");
            f.Filter = "Cascading Stylesheet (*.css)|*.css";
            f.InitialDirectory = Program.APPDATA + "style";

            if (f.ShowDialog() == DialogResult.OK)
                Map.StyleManager.SetStylesheet(f.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            LoadRecentFiles();
        }

        private void recentFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.None);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.Station);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.Segment);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (LineEditor.IsDisposed)
                LineEditor = new LineEditor();
            LineEditor.Show(DockPanel, DockState.Float);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog(this);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMap.UndoManager.Undo();
            ActivePanel.Refresh();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMap.UndoManager.Redo();
            ActivePanel.Refresh();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            ActiveMap.UndoManager.Undo();
            ActivePanel.Refresh();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            ActiveMap.UndoManager.Redo();
            ActivePanel.Refresh();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            File_New();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            IO.Save(ActiveMap);
            LoadRecentFiles();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            File_Open();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.None);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.Station);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPlacementMode(PlacementMode.Segment);
        }

        private void addIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void searchOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IconsBrowser.IsDisposed)
                IconsBrowser = new IconsBrowser();
            IconsBrowser.Show(DockPanel, DockState.DockRight);
        }

        private void fromFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.ico)|*.jpg;*.jpeg;*.png;*.ico";

            if (fd.ShowDialog() == DialogResult.OK)
                ActiveMap.Stickers.Add(new Sticker(Image.FromFile(fd.FileName), ActiveMap));
        }

        private void openConnectionEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StationDockingPointEditor.IsDisposed)
                StationDockingPointEditor = new StationDockingPointEditor(null);
            StationDockingPointEditor.Show(DockPanel, DockState.Float);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reddit.com/r/networx/");
        }

        private void toolStripButton3_Click_2(object sender, EventArgs e)
        {
            if (Program.GridMode != GridMode.Normal)
                Program.GridMode = GridMode.Normal;
            else
                Program.GridMode = GridMode.None;

            if (ActivePanel != null)
                ActivePanel.Refresh();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (Program.GridMode != GridMode.X)
                Program.GridMode = GridMode.X;
            else
                Program.GridMode = GridMode.Normal;

            if (ActivePanel != null)
                ActivePanel.Refresh();
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            if (Program.GridMode != GridMode.Y)
                Program.GridMode = GridMode.Y;
            else
                Program.GridMode = GridMode.Normal;

            if (ActivePanel != null)
                ActivePanel.Refresh();
        }
    }
}
