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
    public partial class SegmentsOverview : DockContent
    {
        string filter = "";
        Map Map;

        public SegmentsOverview()
        {
            InitializeComponent();

            Form1.ActivePanelChanged += ActivePanelChanged;
            Map = Form1.ActiveMap;

            if (Map == null)
                return;

            Map.SegmentsChanged += SegmentsChanged;

            SegmentsChanged();
        }

        private void ActivePanelChanged(DrawPanel p)
        {
            if (Map != null)
                Map.SegmentsChanged -= SegmentsChanged;

            Map = p.Map;
            Map.SegmentsChanged += SegmentsChanged;
            SegmentsChanged();
        }

        public void SegmentsChanged()
        {
            list.Items.Clear();
            Map.ForEachSegment(new Action<Segment>((s) =>
            {
                if (filter.Equals("") || s.Begin.Name.ToLower().Contains(filter) || s.End.Name.ToLower().Contains(filter))
                    if (!s.Deleted)
                        list.Items.Add(s);
            }));
        }

        private void list_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Map.SelectNothing();

                Map.ForEachSegment(new Action<Segment>((s) =>
                {
                    if (list.SelectedItems.Contains("[" + s.Line?.Name + "] " + s.Begin.Name + " - " + s.End.Name))
                        Map.Select(s);
                }));
                Owner.Refresh();
            }
            catch (Exception) { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected_segments = new List<Segment>();
            Map.ForEachSegment(new Action<Segment>((s) =>
            {
                if (s.IsSelected)
                    selected_segments.Add(s);
            }));

            if (MessageBox.Show("Are you sure you want to delete these " + selected_segments.Count + " segments?",
                        "Delete segments", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                foreach (var seg in selected_segments)
                    seg.Delete();
                Owner.Refresh();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetSearchFilter(txtSearch.Text);
        }

        private void SetSearchFilter(string filter)
        {
            this.filter = filter.ToLower();
            SegmentsChanged();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetSearchFilter(txtSearch.Text);
        }
    }
}
