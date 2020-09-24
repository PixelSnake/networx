using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    public partial class UpdateSummary : Form
    {
        string url = "";

        public UpdateSummary(JObject info)
        {
            InitializeComponent();

            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var date = dtDateTime.AddSeconds(int.Parse(info["date"].ToString())).ToLocalTime();

            lblInfoSmall.Text = "Version " + info["version"] + " as from " + date.Day + "." + date.Month + "." + date.Year;
            txtChangelog.Text = info["changeLog"].ToString();
            url = info["url"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DownloadWindow(url, open: true).ShowDialog();
        }
    }
}
