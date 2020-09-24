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
    public partial class DownloadWindow : Form
    {
        WebClient wc = new WebClient();
        bool open_after_download = false;
        string Dest;

        public DownloadWindow(string url, string dest = "setup.exe", bool open = false)
        {
            InitializeComponent();
            
            wc.DownloadProgressChanged += UpdateProgressBar;
            wc.DownloadFileCompleted += DownloadFinished;

            open_after_download = open;
            Dest = Program.APPDATA + dest;
            wc.DownloadFileAsync(new Uri(url), Dest);
        }

        private void UpdateProgressBar(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DownloadFinished(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
                throw e.Error;

            if (open_after_download)
            {
                System.Diagnostics.Process.Start(Dest);
                Environment.Exit(0);
            }
            else
                Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wc.CancelAsync();
            Close();
        }
    }
}
