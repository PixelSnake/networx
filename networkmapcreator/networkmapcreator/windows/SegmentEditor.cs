using NetworkMapCreator.EditorElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NetworkMapCreator
{
    public partial class SegmentEditor : DockContent
    {
        Map Map;
        Segment[] segments;

        public SegmentEditor()
        {
            InitializeComponent();

            Form1.ActivePanelChanged += ActivePanelChanged;
            Map = Form1.ActiveMap;

            if (Map == null)
                return;

            Map.UndoManager.UndoQueueChanged += UndoManager_UndoQueueChanged;
            Map.Selection.CollectionChanged += Selection_Changed;

            ScanComplete();
        }

        private void ActivePanelChanged(DrawPanel p)
        {
            if (Map != null)
                Map.Selection.CollectionChanged -= Selection_Changed;
            Map = p.Map;
            Map.Selection.CollectionChanged += Selection_Changed;
            ScanComplete();
        }

        public SegmentEditor(Segment s)
        {
            InitializeComponent();
            SetSegment(s);

            Map.UndoManager.UndoQueueChanged += UndoManager_UndoQueueChanged;
        }

        public SegmentEditor(Segment[] segs)
        {
            InitializeComponent();
            SetSegments(segs);

            Map.UndoManager.UndoQueueChanged += UndoManager_UndoQueueChanged;
        }

        private void UndoManager_UndoQueueChanged()
        {
            ScanComplete();
        }

        private void Selection_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ScanComplete();
        }

        private void ScanComplete()
        {
            List<Segment> segs = new List<Segment>();

            foreach (var s in Map.Selection)
                if (s is Segment)
                    segs.Add(s as Segment);

            if (segs.Count < 1)
                return;

            SetSegments(segs.ToArray());
        }

        private void SetSegment(Segment s)
        {
            segments = new Segment[] { s };

            if (s.DisplayLineLabel == LineLabelDisplayMode.No)
                checkLineLabel.CheckState = CheckState.Unchecked;
            else if (s.DisplayLineLabel == LineLabelDisplayMode.Yes)
                checkLineLabel.CheckState = CheckState.Checked;

            comboLineMode.SelectedIndex = (int)s.LineMode + 1;

            Layout.Enabled = true;
        }

        private void SetSegments(Segment[] segs)
        {
            if (segs.Count() < 1)
            {
                Layout.Enabled = false;
                return;
            }
            else if (segs.Count() == 1)
            {
                SetSegment(segs[0]);
                return;
            }

            segments = segs;
            if (segs.Length == 1)
            {
                if (segs[0].DisplayLineLabel == LineLabelDisplayMode.No)
                    checkLineLabel.CheckState = CheckState.Unchecked;
                else if (segs[0].DisplayLineLabel == LineLabelDisplayMode.Yes)
                    checkLineLabel.CheckState = CheckState.Checked;

                comboLineMode.SelectedIndex = (int)segs[0].LineMode + 1;
            }
            else
                comboLineMode.SelectedIndex = 0;

            Layout.Enabled = true;
        }

        private void comboLineMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var actions = new List<UndoAction>();

            if (segments == null)
                return;

            foreach (var s in segments)
            {
                if (comboLineMode.SelectedIndex == 0)
                    break;

                actions.Add(new UndoAction(
                    UndoActionType.Modify,
                    s, new UndoActionDataSegment() {
                        LineMode = s.LineMode,
                        LineLabelMode = s.DisplayLineLabel
                    }));

                s.LineMode = (SegmentLineMode)(comboLineMode.SelectedIndex - 1);
            }

            Map.UndoManager.Push(new UndoAction(UndoActionType.Multiple, null, null, actions));
        }

        private void checkLineLabel_CheckedChanged(object sender, EventArgs e)
        {
            var actions = new List<UndoAction>();

            if (segments == null)
                return;

            foreach (var s in segments)
            {
                actions.Add(new UndoAction(
                    UndoActionType.Modify, s,
                    new UndoActionDataSegment()
                    {
                        LineMode = s.LineMode,
                        LineLabelMode = s.DisplayLineLabel
                    }));

                if (checkLineLabel.CheckState == CheckState.Unchecked)
                    s.DisplayLineLabel = LineLabelDisplayMode.No;
                else if (checkLineLabel.CheckState == CheckState.Checked)
                    s.DisplayLineLabel = LineLabelDisplayMode.Yes;
                else
                    s.DisplayLineLabel = LineLabelDisplayMode.Default;
            }
        }
    }
}
