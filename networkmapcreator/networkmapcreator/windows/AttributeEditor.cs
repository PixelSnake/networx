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
            LabelOffsetPanel.OnOffsetChanged += LabelOffsetChanged;
            segmentOrderEditorPanel1.Changed += (s, e) =>
            {
                Form1.ActivePanel.Refresh();
            };

            rdoAnkerBL.Click += AnkerChanged;
            rdoAnkerBC.Click += AnkerChanged;
            rdoAnkerBR.Click += AnkerChanged;
            rdoAnkerCL.Click += AnkerChanged;
            rdoAnkerC.Click  += AnkerChanged;
            rdoAnkerCR.Click += AnkerChanged;
            rdoAnkerTL.Click += AnkerChanged;
            rdoAnkerTC.Click += AnkerChanged;
            rdoAnkerTR.Click += AnkerChanged;

            RefreshSelection();
        }

        private void AnkerChanged(object sender, EventArgs e)
        {
            Station.LabelPivot pivot = Station.LabelPivot.BottomLeft;

            if (sender == rdoAnkerBL)
                pivot = Station.LabelPivot.BottomLeft;
            else if (sender == rdoAnkerBC)
                pivot = Station.LabelPivot.BottomCenter;
            else if (sender == rdoAnkerBR)
                pivot = Station.LabelPivot.BottomRight;
            else if (sender == rdoAnkerCL)
                pivot = Station.LabelPivot.CenterLeft;
            else if (sender == rdoAnkerC)
                pivot = Station.LabelPivot.Center;
            else if (sender == rdoAnkerCR)
                pivot = Station.LabelPivot.CenterRight;
            else if (sender == rdoAnkerTL)
                pivot = Station.LabelPivot.TopLeft;
            else if (sender == rdoAnkerTC)
                pivot = Station.LabelPivot.TopCenter;
            else if (sender == rdoAnkerTR)
                pivot = Station.LabelPivot.TopRight;

            foreach (var i in Items)
            {
                var station = i as Station;
                if (i == null)
                    continue;

                station.Pivot = pivot;
            }

            Form1.ActivePanel.Refresh();
        }

        private void LabelOffsetChanged(object sender, EventArgs e)
        {
            foreach (var i in Items)
            {
                if (i is Station station)
                {
                    station.label_offset = LabelOffsetPanel.LabelOffset;
                    Form1.ActivePanel.Refresh();
                }
            }
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
                rdoAnkerBL.Checked = false;
                rdoAnkerBC.Checked = false;
                rdoAnkerBR.Checked = false;

                rdoAnkerCL.Checked = false;
                rdoAnkerC.Checked = false;
                rdoAnkerCR.Checked = false;

                rdoAnkerTL.Checked = false;
                rdoAnkerTC.Checked = false;
                rdoAnkerTR.Checked = false;
            }
            else
            {
                var val = pivot_eq.Value;

                rdoAnkerBL.Checked = val == Station.LabelPivot.BottomLeft;
                rdoAnkerBC.Checked = val == Station.LabelPivot.CenterLeft;
                rdoAnkerBR.Checked = val == Station.LabelPivot.TopLeft;

                rdoAnkerCL.Checked = val == Station.LabelPivot.BottomCenter;
                rdoAnkerC.Checked = val == Station.LabelPivot.Center;
                rdoAnkerCR.Checked = val == Station.LabelPivot.TopCenter;

                rdoAnkerTL.Checked = val == Station.LabelPivot.BottomRight;
                rdoAnkerTC.Checked = val == Station.LabelPivot.CenterRight;
                rdoAnkerTR.Checked = val == Station.LabelPivot.TopRight;
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
        #endregion

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
    }
}
