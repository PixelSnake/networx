using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator
{
    public partial class ExceptionInfo : Form
    {
        Exception exception;
        string AutosaveFile;

        public ExceptionInfo(Exception e, string autosave_file)
        {
            InitializeComponent();
            exception = e;
            infoTextBox.Text = e + "";
            AutosaveFile = autosave_file;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location, "\"" + AutosaveFile + "\"");
            Environment.Exit(0);
        }

        private void btnRestartAndSend_Click(object sender, EventArgs e)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://api.pxsnake.de/nmc/exception.php");

                var postData = "exception=" + exception + ";\n\nLast actions: " + textBox1.Text;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception) { }

            btnRestartAndSend.Enabled = false;
            btnRestartAndSend.Text = "Thanks!";
        }
    }
}
