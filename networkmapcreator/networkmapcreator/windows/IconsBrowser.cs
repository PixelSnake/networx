using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace NetworkMapCreator
{
    public partial class IconsBrowser : DockContent
    {
        ObservableCollection<IconsBrowserItem> Icons;

        public IconsBrowser()
        {
            InitializeComponent();
            
            Icons = new ObservableCollection<IconsBrowserItem>();
            Icons.CollectionChanged += Icons_CollectionChanged;
        }

        private void Icons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (var i in e.NewItems)
                        {
                            listView1.BeginInvoke((Action)(() => { listView1.Items.Add(i); }));
                        }
                        break;

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (var i in e.NewItems)
                        {
                            listView1.BeginInvoke((Action)(() => { listView1.Items.Remove(i); }));
                        }
                        break;

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                        listView1.BeginInvoke((Action)(() => { listView1.Items.Clear(); }));
                        break;

                    default:

                        break;
                }
            }
            catch (Exception) { }
        }

        private void IconsBrowser_Load(object sender, EventArgs e)
        {
            new Thread(() => { LoadIcons("latest", "?amount=10"); }).Start();
        }

        private void LoadIcons(string method, string p)
        {
            Icons.Clear();

            loadProgress.BeginInvoke((Action)(() => { loadProgress.Style = ProgressBarStyle.Marquee; }));

            string url = "https://api.icons8.com/api/iconsets/" + method + p;
            string xml = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    xml = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }

            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var icons = new List<IconsBrowserItem>();
            var res = doc["icons8"]["result"][method];
            if (method == "latest")
            {
                var platforms = res.ChildNodes;
                foreach (XmlNode q in platforms)
                {
                    icons.AddRange(IterateIcons(q));
                }
            }
            else
            {
                icons.AddRange(IterateIcons(res));
            }

            foreach (var i in icons)
                Icons.Add(i);

            try
            {
                loadProgress.BeginInvoke((Action)(() => { loadProgress.Style = ProgressBarStyle.Blocks; }));
            }
            catch (Exception) { }
        }

        private List<IconsBrowserItem> IterateIcons(XmlNode platform)
        {
            var ret = new List<IconsBrowserItem>();

            foreach (XmlElement i in platform)
            {
                var name = i.GetAttribute("name");
                var link = ((XmlElement)(i["png"]?.LastChild))?.GetAttribute("link");

                if (link != null)
                    ret.Add(new IconsBrowserItem(LoadImage(link), name));
            }
            
            return ret;
        }

        private Image LoadImage(string link)
        {
            var request = WebRequest.Create(link);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return Bitmap.FromStream(stream);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search(searchBox.Text);
        }

        private void Search(string q)
        {
            Icons.Clear();
            new Thread(() => { LoadIcons("search", "?term=" + q + "&amount=50"); }).Start();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(searchBox.Text);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Form1.ActiveMap == null)
                return;

            var img = ((IconsBrowserItem)listView1.SelectedItem).Image;
            Form1.ActiveMap.Stickers.Add(new Sticker(img, Form1.ActiveMap));
        }
    }
}
