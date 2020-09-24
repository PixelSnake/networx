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
    public partial class StationsOverview : DockContent
    {
        string filter = "";
        Map Map;

        public StationsOverview()
        {
            InitializeComponent();

            Form1.ActivePanelChanged += ActivePanelChanged;
            Map = Form1.ActiveMap;

            if (Map == null)
                return;

            Map.StationsChanged += Backend_StationsChanged;
        }

        private void ActivePanelChanged(DrawPanel p)
        {
            if (Map != null)
                Map.StationsChanged -= Backend_StationsChanged;
            Map = p.Map;
            Map.StationsChanged += Backend_StationsChanged;
            UpdateList();
        }

        private void Backend_StationsChanged()
        {
            UpdateList();
        }

        public void UpdateList()
        {
            list.Items.Clear();
            foreach (var s in Map.Stations)
                if (filter.Equals("") || s.Name.ToLower().Contains(filter) || (s.Line != null && s.Line.Name.ToLower().Contains(filter)))
                    if (!s.Deleted)
                        list.Items.Add("[" + s.Line?.Name + "] " + s.Name);
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditCurrent();
        }

        private void EditCurrent()
        {
            try
            {
                if (list.SelectedItems.Count < 2)
                    new StationEditor(Map.Stations[list.SelectedIndex]).ShowDialog();
                else
                {
                    var selection = new List<Station>();
                    foreach (var i in list.SelectedIndices)
                        selection.Add(Map.Stations[(int)i]);

                    new StationEditor(selection.ToArray()).ShowDialog();
                }
            }
            catch (Exception) { }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Map.SelectNothing();

                for (int i = 0; i < Map.Stations.Count; ++i)
                    if (list.SelectedItems.Contains("[" + Map.Stations[i].Line?.Name + "] " + Map.Stations[i].Name))
                        Map.Select(Map.Stations[i]);
                Owner.Refresh();
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Station> selected_stations = new List<Station>();
            foreach (var s in Map.Stations)
                if (s.IsSelected)
                    selected_stations.Add(s);

            if (MessageBox.Show("Are you sure you want to delete these " + selected_stations.Count + " stations and all connections to them?",
                        "Delete stations", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (var s in selected_stations)
                {
                    Map.Stations.Remove(s);

                    foreach (var seg in s.SegmentsLeft)
                        try { Map.RemoveSegment(s, s.OtherEnd(seg)); } catch (Exception) { }
                    foreach (var seg in s.SegmentsTop)
                        try { Map.RemoveSegment(s, s.OtherEnd(seg)); } catch (Exception) { }
                    foreach (var seg in s.SegmentsRight)
                        try { Map.RemoveSegment(s, s.OtherEnd(seg)); } catch (Exception) { }
                    foreach (var seg in s.SegmentsBottom)
                        try { Map.RemoveSegment(s, s.OtherEnd(seg)); } catch (Exception) { }
                }
                Owner.Refresh();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetSearchFilter(btnSearch.Text);
        }

        private void SetSearchFilter(string filter)
        {
            this.filter = filter.ToLower();
            UpdateList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetSearchFilter(txtSearch.Text);
        }

        private void list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditCurrent();
        }
    }
}
