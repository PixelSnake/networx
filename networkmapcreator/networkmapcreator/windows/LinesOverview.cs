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
    public partial class LinesOverview : DockContent
    {
        Map Map;

        public LinesOverview()
        {
            InitializeComponent();

            Form1.ActivePanelChanged += Form1_ActivePanelChanged;
            Map = Form1.ActiveMap;

            if (Map == null)
                return;

            Map.LinesChanged += LinesChanged;

            UpdateList();
        }

        private void Form1_ActivePanelChanged(DrawPanel p)
        {
            if (Map != null)
                Map.LinesChanged -= LinesChanged;
            Map = p.Map;
            Map.LinesChanged += LinesChanged;
            UpdateList();
        }

        private void LinesChanged()
        {
            UpdateList();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateLine();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditLine();
        }

        private void EditLine()
        {
            if (list.SelectedIndex < 0)
                return;

            new LineEditor(Form1.ActiveMap.Lines[list.SelectedIndex]).ShowDialog();
        }

        private void CreateLine()
        {
            var r = new LineEditor().ShowDialog();
            if (r == DialogResult.OK)
            {
                UpdateList();
                ((Form1)Owner).FillLinesIntoComboBox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateLine();
        }

        private void UpdateList(bool force = false)
        {
            list.Items.Clear();
            foreach (var l in Form1.ActiveMap.Lines)
                list.Items.Add(l.Name);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void DeleteLine()
        {
            if (list.SelectedIndex < 0)
                return;

            if (MessageBox.Show("Are you sure you want to delete line '" + Form1.ActiveMap.Lines[list.SelectedIndex].Name + "'?", "Delete line", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Form1.ActiveMap.Lines.RemoveAt(list.SelectedIndex);
        }
    }
}