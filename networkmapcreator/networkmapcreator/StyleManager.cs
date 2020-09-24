using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExCSS;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net;

namespace NetworkMapCreator
{
    public class StyleManager
    {
        public delegate void StyleChangedEventHandler();
        public event StyleChangedEventHandler StyleChanged;

        FileSystemWatcher Watcher;
        public Dictionary<string, StyleSet> Styles { get; } = new Dictionary<string, StyleSet>();
        public Dictionary<string, Font> Fonts { get; } = new Dictionary<string, Font>();

        public StyleManager()
        {
            Watcher = new FileSystemWatcher();
            Watcher.Changed += Stylesheet_Changed;
        }

        public void SetStylesheet(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show("File '" + filename + "' not found");
                return;
            }

            InitDefault();

            string css_content;
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                css_content = reader.ReadToEnd();
            }
            Parse(css_content);

            if (Program.Config.Stylesheets_AutoReloadChanges)
                AttachWatcher(filename);
        }

        public void AttachWatcher(string filename)
        {
            Watcher.Path = Path.GetDirectoryName(filename);
            Watcher.Filter = Path.GetFileName(filename);
            Watcher.EnableRaisingEvents = true;
        }

        private void Stylesheet_Changed(object sender, FileSystemEventArgs e)
        {
            SetStylesheet(e.FullPath);
            StyleChanged?.Invoke();
        }

        public void Parse(string content)
        {
            var p = new ExCSS.Parser();
            var sheet = p.Parse(content);

            foreach (var e in sheet.Errors)
                MessageBox.Show("Invalid CSS in line " + e.Line + ": " + e.Message, "CSS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            foreach (var imp in sheet.ImportDirectives)
            {
                string html = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imp.Href);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                Parse(html);
            }

            foreach (var s in sheet.StyleRules)
            {
                Styles[s.Selector.ToString()] = CSSParser.CompleteParse(s);
            }

            foreach (var f in sheet.FontFaceDirectives)
            {
                var filename = "";
                var family = f.FontFamily;
                var _style = f.FontStyle;

                Match m;
                foreach (var source in f.Src.Split(new char[] { ' ', ',' }))
                {
                    if ((m = Regex.Match(source, @"url\((.*?)\)")).Success)
                    {
                        var url = m.Groups[1].Value;
                        var uri = new Uri(url);

                        //MessageBox.Show(url);

                        Directory.CreateDirectory(Program.APPDATA + "temp");

                        new DownloadWindow(url, Program.APPDATA + @"temp\" + Path.GetFileName(url)).ShowDialog();
                        filename = Program.APPDATA + @"temp\" + Path.GetFileName(url);
                    }
                }

                if (filename.Equals(""))
                    return;
            }
        }

        public void AddFont(string filename, string family)
        {
            Map.fonts.AddFontFile(filename);
        }

        public Font GetFont(string family, int size)
        {
            // TODO
            //return new Font(Backend.fonts.Families.Contains
            return null;
        }

        public void InitDefault()
        {
            Styles["station"] = StyleSet.Default;
            Styles["station.multiple"] = StyleSet.Default;
            Styles["line"] = StyleSet.Default;
            Styles["line.steps"] = StyleSet.Default;
        }
    }
}
