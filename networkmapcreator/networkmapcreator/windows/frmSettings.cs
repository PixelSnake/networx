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

namespace NetworkMapCreator
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            var conf = Program.Config;
            conf.Stylesheets_AutoReloadChanges = chkStylesheetAutoReloadChanges.Checked;
            conf.DisplayDebugInfo = chkDebugging.Checked;
            conf.DisplayFPS = chkFPS.Checked;

            Save();
            ((Form1)Owner).LoadShortcuts();

            Program.Config.Save();
        }

        private void Save()
        {
            var doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement shortcuts = doc.CreateElement(string.Empty, "shortcuts", string.Empty);
            doc.AppendChild(shortcuts);

            var sc = new List<ShortCutButton>();
            sc.Add(ScFileNew);
            sc.Add(ScFileOpen);
            sc.Add(ScFileSave);
            sc.Add(ScFileSaveAs);
            sc.Add(ScFileExportImage);
            sc.Add(ScFileExportSVG);

            sc.Add(ScEditUndo);
            sc.Add(ScEditRedo);
            sc.Add(ScEditTrackEditor);
            sc.Add(ScEditStationEditor);
            sc.Add(ScConnectionEditor);
            sc.Add(ScEditSelectStylesheet);
            sc.Add(ScEditSettings);

            sc.Add(ScViewLinesOverview);
            sc.Add(ScViewSegmentsOverview);
            sc.Add(ScViewStationsOverview);

            sc.Add(ScToolsSelect);
            sc.Add(ScToolsCreate);
            sc.Add(ScToolsConnect);

            foreach (var s in sc)
            {
                XmlElement e = doc.CreateElement(string.Empty, s.Name, string.Empty);
                e.SetAttribute("shortcut", (int)s.Shortcut + "");
                shortcuts.AppendChild(e);
            }

            doc.Save(Program.APPDATA + "shortcuts.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Apply();
            Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadShortcuts();
            LoadConfig();
        }

        public void LoadShortcuts()
        {
            try
            {
                var doc = new XmlDocument();

                doc.Load(Program.APPDATA + "shortcuts.xml");
                var shortcuts = doc["shortcuts"];

                {
                    ScFileNew.Shortcut = (Keys)int.Parse(shortcuts["ScFileNew"].GetAttribute("shortcut"));
                    ScFileOpen.Shortcut = (Keys)int.Parse(shortcuts["ScFileOpen"].GetAttribute("shortcut"));
                    ScFileSave.Shortcut = (Keys)int.Parse(shortcuts["ScFileSave"].GetAttribute("shortcut"));
                    ScFileSaveAs.Shortcut = (Keys)int.Parse(shortcuts["ScFileSaveAs"].GetAttribute("shortcut"));
                    ScFileExportImage.Shortcut = (Keys)int.Parse(shortcuts["ScFileExportImage"].GetAttribute("shortcut"));
                    ScFileExportSVG.Shortcut = (Keys)int.Parse(shortcuts["ScFileExportSVG"].GetAttribute("shortcut"));

                    ScEditUndo.Shortcut = (Keys)int.Parse(shortcuts["ScEditUndo"].GetAttribute("shortcut"));
                    ScEditRedo.Shortcut = (Keys)int.Parse(shortcuts["ScEditRedo"].GetAttribute("shortcut"));
                    ScEditTrackEditor.Shortcut = (Keys)int.Parse(shortcuts["ScEditTrackEditor"].GetAttribute("shortcut"));
                    ScConnectionEditor.Shortcut = (Keys)int.Parse(shortcuts["ScConnectionEditor"].GetAttribute("shortcut"));
                    ScEditStationEditor.Shortcut = (Keys)int.Parse(shortcuts["ScEditStationEditor"].GetAttribute("shortcut"));
                    ScEditSelectStylesheet.Shortcut = (Keys)int.Parse(shortcuts["ScEditSelectStylesheet"].GetAttribute("shortcut"));
                    ScEditSettings.Shortcut = (Keys)int.Parse(shortcuts["ScEditSettings"].GetAttribute("shortcut"));

                    ScViewLinesOverview.Shortcut = (Keys)int.Parse(shortcuts["ScViewLinesOverview"].GetAttribute("shortcut"));
                    ScViewSegmentsOverview.Shortcut = (Keys)int.Parse(shortcuts["ScViewSegmentsOverview"].GetAttribute("shortcut"));
                    ScViewStationsOverview.Shortcut = (Keys)int.Parse(shortcuts["ScViewStationsOverview"].GetAttribute("shortcut"));

                    ScToolsSelect.Shortcut = (Keys)int.Parse(shortcuts["ScToolsSelect"].GetAttribute("shortcut"));
                    ScToolsCreate.Shortcut = (Keys)int.Parse(shortcuts["ScToolsCreate"].GetAttribute("shortcut"));
                    ScToolsConnect.Shortcut = (Keys)int.Parse(shortcuts["ScToolsConnect"].GetAttribute("shortcut"));
                }
            }
            catch (Exception e) { }
        }

        public void LoadConfig()
        {
            var conf = Program.Config;

            chkStylesheetAutoReloadChanges.Checked = conf.Stylesheets_AutoReloadChanges;

            chkDebugging.Checked = conf.DisplayDebugInfo;
            chkFPS.Checked = conf.DisplayFPS;
        }
    }
}
