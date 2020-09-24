using NetworkMapCreator.EditorElements;
using NetworkMapCreator.Utilities;
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

namespace NetworkMapCreator.Windows
{
    public partial class AttributeEditor : DockContent
    {
        private Map Map;
        private List<EditorElement> Items;

        public AttributeEditor()
        {
            InitializeComponent();

            Items = new List<EditorElement>();

            Map = Form1.ActiveMap;
            Form1.ActivePanelChanged += Form1_ActivePanelChanged;

            panel1.OffsetChanged += Panel1_OffsetChanged;

            RefreshSelection();
        }

        private void RefreshSelection()
        {
            if (Map == null || Map.Selection.Count < 1)
            {
                RefreshEmptySelection();
                return;
            }

            Type type = null;

            foreach (var elem in Map.Selection)
            {
                if (type == null)
                    type = elem.GetType();

                /* if elements of different types (e.g. a station and a segment) are selected, the attribute editor will not operate */
                if (elem.GetType() != type)
                {
                    RefreshEmptySelection();
                    return;
                }
            }

            Items.Clear();
            foreach (var i in Map.Selection)
                Items.Add(i);

            if (type == typeof(Segment))
                RefreshSelectionForSegments(Items);
            else if (type == typeof(Station))
                RefreshSelectionForStations(Items);
        }

        private void RefreshEmptySelection()
        {
            SegmentAttributes.Visible = false;
            StationAttributes.Visible = false;
        }

        private void RefreshSelectionForSegments(List<EditorElement> items)
        {
            StationAttributes.Visible = false;

            SegmentAttributes.Visible = true;
            
            var linemode_eq = new EqualityCollector<SegmentLineMode>();

            foreach (Segment seg in items)
            {
                linemode_eq.Push(seg.LineMode);
            }

            if (linemode_eq.AllEqual)
                comboLineMode.SelectedItem = linemode_eq.Value.ToString();
            else
                comboLineMode.SelectedItem = "";

            if (items.Count == 1)
            {
                SegmentAttributes.RowStyles[1].Height = (items[0] as Segment).SubSegments.Count * 30;
                segmentOrderEditorPanel1.Source = items[0];
            }
            else
            {
                segmentOrderEditorPanel1.Source = null;
                segmentOrderEditorPanel1.Height = 0;
            }
        }

        private void RefreshSelectionForStations(List<EditorElement> items)
        {
            SegmentAttributes.Visible = false;

            StationAttributes.Visible = true;

            var name_eq = new EqualityCollector<string>();
            var prominence_eq = new EqualityCollector<Station.Prominence>();
            var rotation_eq = new EqualityCollector<float>();
            var pivot_eq = new EqualityCollector<Station.LabelPivot>();

            foreach (Station s in items)
            {
                name_eq.Push(s.Name);
                prominence_eq.Push(s.prominence);
                rotation_eq.Push(s.RotationAngle);
                pivot_eq.Push(s.Pivot);
            }

            txtName.Text = name_eq.AllEqual ? name_eq.Value.Replace("\n", "\\n") : "";
            comboProminence.SelectedItem = prominence_eq.AllEqual ? prominence_eq.Value.ToString() : "";
            RotationNumber.Value = RotationTrackBar.Value = (int)(rotation_eq.AllEqual ? rotation_eq.Value : 0);
            
            if (!pivot_eq.AllEqual)
            {
                rdoAnkerLB.Checked = false;
                rdoAnkerLM.Checked = false;
                rdoAnkerLU.Checked = false;

                rdoAnkerMB.Checked = false;
                rdoAnkerMM.Checked = false;
                rdoAnkerMU.Checked = false;

                rdoAnkerRB.Checked = false;
                rdoAnkerRM.Checked = false;
                rdoAnkerRU.Checked = false;
            }
            else
            {
                var val = pivot_eq.Value;

                rdoAnkerLB.Checked = val == Station.LabelPivot.BottomLeft;
                rdoAnkerLM.Checked = val == Station.LabelPivot.CenterLeft;
                rdoAnkerLU.Checked = val == Station.LabelPivot.TopLeft;

                rdoAnkerMB.Checked = val == Station.LabelPivot.BottomCenter;
                rdoAnkerMM.Checked = val == Station.LabelPivot.Center;
                rdoAnkerMU.Checked = val == Station.LabelPivot.TopCenter;

                rdoAnkerRB.Checked = val == Station.LabelPivot.BottomRight;
                rdoAnkerRM.Checked = val == Station.LabelPivot.CenterRight;
                rdoAnkerRU.Checked = val == Station.LabelPivot.TopRight;
            }
        }

        private void BindEvents(Map m)
        {
            if (m == null)
                return;

            m.Selection.CollectionChanged += Selection_CollectionChanged;
        }

        private void UnbindEvents(Map m)
        {
            if (m == null)
                return;

            m.Selection.CollectionChanged -= Selection_CollectionChanged;
        }

        #region Events
        private void Form1_ActivePanelChanged(DrawPanel p)
        {
            if (p == null)
                return;

            UnbindEvents(Map);
            Map = p.Map;
            BindEvents(Map);
        }

        private void Selection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshSelection();
        }

        private void comboLineMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLineMode.SelectedItem.ToString().Length < 1)
                return;

            foreach (Segment s in Items)
                s.LineMode = (SegmentLineMode)Enum.Parse(typeof(SegmentLineMode), comboLineMode.SelectedItem.ToString());
        }

        private void comboLineMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void Panel1_OffsetChanged(object sender, EventArgs e)
        {
            foreach (Station s in Items)
                s.LabelOffset = panel1.LabelOffset;
            Form1.ActivePanel.Refresh();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                return;

            foreach (Station s in Items)
                s.Name = txtName.Text;

            Form1.ActivePanel.Refresh();
        }

        private void comboProminence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProminence.SelectedItem.ToString().Length < 1)
                return;

            foreach (Station s in Items)
            {
                switch (comboProminence.SelectedItem.ToString())
                {
                    case "Default":
                        s.prominence = Station.Prominence.Default;
                        break;

                    case "None":
                        s.prominence = Station.Prominence.None;
                        break;

                    case "Ending Lines":
                        s.prominence = Station.Prominence.Ending;
                        break;

                    case "All":
                        s.prominence = Station.Prominence.All;
                        break;
                }
            }

            Form1.ActivePanel.Refresh();
        }

        private void RotationNumber_ValueChanged(object sender, EventArgs e)
        {
            RotationTrackBar.Value = (int)RotationNumber.Value;
            foreach (Station s in Items)
                s.RotationAngle = (float)RotationNumber.Value;
            Form1.ActivePanel.Refresh();
        }

        private void RotationTrackBar_ValueChanged(object sender, EventArgs e)
        {
            RotationNumber.Value = RotationTrackBar.Value;
        }

        private void rdoAnkerLU_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerLU.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.TopLeft;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerMU_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerMU.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.TopCenter;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerRU_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerRU.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.TopRight;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerLM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerLM.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.CenterLeft;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerMM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerMM.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.Center;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerRM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerRM.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.CenterRight;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerLB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerLB.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.BottomLeft;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerMB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerMB.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.BottomCenter;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerRB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerRB.Checked)
                foreach (Station s in Items)
                    s.Pivot = Station.LabelPivot.BottomRight;
            Form1.ActivePanel.Refresh();
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            foreach (Station s in Items)
                s.Comment = txtComment.Text;
            Form1.ActivePanel.Refresh();
        }
        #endregion
    }
}
