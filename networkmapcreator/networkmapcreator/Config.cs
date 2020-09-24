using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace NetworkMapCreator
{
    public class Config
    {
        private string Filename = "";
        private bool IsOpen = false;

        #region Appearance
        public string Theme = "light";
        #endregion

        #region Stylesheets
        public bool Stylesheets_AutoReloadChanges = true;
        #endregion

        #region Debugging
        public bool DisplayDebugInfo = false;
        public bool DisplayFPS = false;
        #endregion

        public Config(string file)
        {
            IsOpen = true;
            Filename = file;
            var doc = new XmlDocument();

            try
            {
                doc.Load(file);
            }
            catch (Exception)
            {
                /* if the file doesnt exist, we write a new one with the default values */
                Save();
            }

            try
            {
                var layout = doc["settings"]["layout"];

                bool.TryParse(layout["autoreloadchanges"].GetAttribute("value"), out Stylesheets_AutoReloadChanges);
            }
            catch (Exception) { }

            try
            {
                var appearance = doc["settings"]["appearance"];

                Theme = appearance["theme"].GetAttribute("value");
            }
            catch (Exception) { }

            try
            {
                var debugging = doc["settings"]["debugging"];

                bool.TryParse(debugging["showinfo"].GetAttribute("value"), out DisplayDebugInfo);
                bool.TryParse(debugging["showfps"].GetAttribute("value"), out DisplayFPS);
            }
            catch (Exception) { }
        }

        public void Save()
        {
            if (!IsOpen)
                return;

            var doc = new XmlDocument();

            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));

            var root = doc.CreateElement("settings");
            doc.AppendChild(root);

            #region Appearance
            var appearance = doc.CreateElement("appearance");
            root.AppendChild(appearance);

            var theme = doc.CreateElement("theme");
            theme.SetAttribute("value", Theme);
            appearance.AppendChild(theme);
            #endregion

            #region Stylesheets
            var stylesheets = doc.CreateElement("stylesheets");
            root.AppendChild(stylesheets);

            var autoreloadchanges = doc.CreateElement("autoreloadchanges");
            autoreloadchanges.SetAttribute("value", Stylesheets_AutoReloadChanges + "");
            stylesheets.AppendChild(autoreloadchanges);
            #endregion

            #region Debugging
            var debugging = doc.CreateElement("debugging");
            root.AppendChild(debugging);

            var showinfo = doc.CreateElement("showinfo");
            showinfo.SetAttribute("value", DisplayDebugInfo + "");
            debugging.AppendChild(showinfo);

            var showfps = doc.CreateElement("showfps");
            showfps.SetAttribute("value", DisplayFPS + "");
            debugging.AppendChild(showfps);
            #endregion

            doc.Save(Filename);
        }
    }
}
