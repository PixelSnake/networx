using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetworkMapCreator
{
    public partial class LoginBox : Form
    {
        public LoginBox()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Program.VERSION;
            try
            {
                string info = System.IO.File.ReadAllText("logininfo");
                var parts = info.Split('\n');
                if (parts.Length >= 2)
                    password.Text = parts.Last();
                if (parts.Length >= 1)
                    email.Text = parts.First();
            }
            catch (Exception) { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            return;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://api.pxsnake.de/nmc/auth.php?p=" + password.Text + "&mail=" + email.Text);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string correct = md5(md5(email.Text).Substring(3, 8));
                string ret_credentials = md5(md5("credentials").Substring(3, 8));
                string ret_expired = md5(md5("expired").Substring(3, 8));

                try
                {
                    System.IO.File.WriteAllText("logininfo", email.Text + "\n" + password.Text);
                }
                catch (Exception) { }

                if (responseString.Equals(correct))
                    DialogResult = DialogResult.OK;
                else
                {
                    if (responseString.Equals(ret_credentials))
                        MessageBox.Show("Username or password is incorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("It seems like the time for the closed beta has expired. Thank you for participating, I would love to see you again when the final version of the program has been released!",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (WebException)
            {
                MessageBox.Show("There is no internet connection available at the moment. It is required to check your closed alpha login information. Please reconnect to the internet to use this program.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string md5(string text)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(text);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.reddit.com/user/DixiZigeuner/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.youtube.com/user/homiesforthewin");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.pxsnake.de/");
        }
    }
}
