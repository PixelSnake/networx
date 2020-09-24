using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    public partial class StationEditor : Form
    {
        bool rotation_changed = false;
        bool pivot_changed = false;
        public Station[] Stations;
        public Station[] Original;

        public StationEditor(Station s)
        {
            Stations = new Station[] { s };
            Station o = new Station(s.Map, s.Name, s.Location);
            o.LabelOffset = s.LabelOffset;
            o.RotationAngle = s.RotationAngle;
            o.Pivot = s.Pivot;
            Original = new Station[] { o };

            InitializeComponent();

            rdoAnkerLU.Checked = s.Pivot == Station.LabelPivot.TopLeft;
            rdoAnkerMU.Checked = s.Pivot == Station.LabelPivot.TopCenter;
            rdoAnkerRU.Checked = s.Pivot == Station.LabelPivot.TopRight;

            rdoAnkerLM.Checked = s.Pivot == Station.LabelPivot.CenterLeft;
            rdoAnkerMM.Checked = s.Pivot == Station.LabelPivot.Center;
            rdoAnkerRM.Checked = s.Pivot == Station.LabelPivot.CenterRight;

            rdoAnkerLB.Checked = s.Pivot == Station.LabelPivot.BottomLeft;
            rdoAnkerMB.Checked = s.Pivot == Station.LabelPivot.BottomCenter;
            rdoAnkerRB.Checked = s.Pivot == Station.LabelPivot.BottomRight;

            RotationTrackBar.Value = (int)s.RotationAngle;
            RotationNumber.Value = (int)s.RotationAngle;
            txtName.Text = EscapeName(s.Name);

            panel1.OnOffsetChanged += OnOffsetChange;
            comboProminence.SelectedIndex = (int)s.prominence;
        }

        public StationEditor(Station[] stat)
        {
            Stations = stat;

            var orig = new List<Station>();
            foreach (var s in stat)
            {
                Station o = new Station(s.Map, s.Name, s.Location);
                o.LabelOffset = s.LabelOffset;
                o.RotationAngle = s.RotationAngle;
                o.Pivot = s.Pivot;
                orig.Add(o);
            }
            Original = orig.ToArray();

            InitializeComponent();

            RotationNumber.Value = 0;
            txtName.Text = "<don't change>";

            panel1.OnOffsetChanged += OnOffsetChange;

            if (stat.Length == 1)
                comboProminence.SelectedIndex = (int)stat[0].prominence;
        }

        private string EscapeName(string n)
        {
            return n.Replace("\n", "\\n");
        }

        private string UnescapeName(string n)
        {
            return n.Replace("\\n", "\n");
        }

        private void RotationNumber_ValueChanged(object sender, EventArgs e)
        {
            RotationTrackBar.Value = (int)RotationNumber.Value;
            rotation_changed = true;
        }

        private void RotationTrackBar_ValueChanged(object sender, EventArgs e)
        {
            RotationNumber.Value = RotationTrackBar.Value;
            foreach (var s in Stations)
                s.RotationAngle = RotationTrackBar.Value;
            Form1.ActivePanel.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Stations.Count(); ++i)
            {
                Stations[i].Name = Original[i].Name;
                Stations[i].RotationAngle = Original[i].RotationAngle;
                Stations[i].Pivot = Original[i].Pivot;
                Stations[i].LabelOffset = Original[i].LabelOffset;
                Stations[i].prominence = Original[i].prominence;
            }
                
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("<don't change>"))
            {
                for (int i = 0; i < Stations.Count(); ++i)
                    Stations[i].Name = Original[i].Name;
            }
            else
            {
                foreach (var s in Stations)
                    s.Name = UnescapeName(txtName.Text);
            }

            Form1.ActivePanel.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName.Equals("<don't change>"))
                for (int i = 0; i < Stations.Count(); ++i)
                    Stations[i].Name = Original[i].Name;
            if (!pivot_changed)
                for (int i = 0; i < Stations.Count(); ++i)
                    Stations[i].Pivot = Original[i].Pivot;
            if (!rotation_changed)
                for (int i = 0; i < Stations.Count(); ++i)
                    Stations[i].RotationAngle = Original[i].RotationAngle;

            DialogResult = DialogResult.OK;
            Close();
        }

        public void OnOffsetChange(object sender, EventArgs e)
        {
            foreach (var s in Stations)
                s.LabelOffset = panel1.LabelOffset;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerLU_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnkerLU.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.TopLeft;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerMU_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerMU.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.TopCenter;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerRU_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerRU.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.TopRight;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerLM_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerLM.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.CenterLeft;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerMM_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerMM.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.Center;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerRM_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerRM.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.CenterRight;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerLB_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerLB.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.BottomLeft;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerMB_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerMB.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.BottomCenter;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void rdoAnkerRB_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAnkerRB.Checked)
                foreach (var s in Stations)
                    s.Pivot = Station.LabelPivot.BottomRight;
            pivot_changed = true;
            Form1.ActivePanel.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new StationDockingPointEditor(Stations[0]).Show();
        }

        private void comboProminence_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var s in Stations)
                s.prominence = (Station.Prominence)comboProminence.SelectedIndex;
            Form1.ActivePanel.Refresh();
        }
    }
}
