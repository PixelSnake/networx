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
    public partial class StationDockingPointEditor : DockContent
    {
        Station station;
        Map Map;

        public StationDockingPointEditor(Station s)
        {
            InitializeComponent();
            station = s;
            panel1.SetStation(station);

            Map = Form1.ActiveMap;
            Form1.ActivePanelChanged += ActivePanelChanged;

            if (Map == null)
                return;

            Map.Selection.CollectionChanged += Selection_Changed;
            ScanComplete();
        }

        private void ActivePanelChanged(DrawPanel p)
        {
            if (Map != null)
                Map.Selection.CollectionChanged -= Selection_Changed;

            Map = p.Map;
            Map.Selection.CollectionChanged += Selection_Changed;
        }

        private void Selection_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var x in e.NewItems)
                    {
                        if (x is Station)
                        {
                            SetStation(x as Station);
                            break;
                        }
                    }
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        ScanComplete();
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    SetStation(null);
                    break;
            }
        }

        private void ScanComplete()
        {
            SetStation(null);

            foreach (var x in Map.Selection)
            {
                if (x is Station)
                {
                    SetStation(x as Station);
                    break;
                }
            }

            panel1.Refresh();
        }

        private void SetStation(Station s)
        {
            panel1.SetStation(s);
            panel1.Refresh();
        }

        private void StationDockingPointEditor_Resize(object sender, EventArgs e)
        {
            panel1.Width = Width - 40;
            panel1.Height = Height - 62;
            panel1.Refresh();
        }
    }
}
