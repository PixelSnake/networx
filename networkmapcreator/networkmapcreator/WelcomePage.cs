using NetworkMapCreator.Controls;
using RedditSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NetworkMapCreator
{
    public partial class WelcomePage: DockContent
    {
        private bool reddit_loaded = false;
        private bool recent_loaded = false;
        new private Form1 Owner;

        public WelcomePage(Form1 o)
        {
            InitializeComponent();

            lblVersion.Text = Program.VERSION;
            Owner = o;
            Text = "Welcome";
            Icon = Properties.Resources.nmc;
        }

        private void WelcomePage_Activated(object sender, EventArgs e)
        {
            LoadRecent();
            LoadReddit();
        }

        private void LoadRecent()
        {
            if (recent_loaded)
                return;
            recent_loaded = true;

            var recent = IO.LoadRecent();

            foreach (var f in recent)
            {
                var o = Owner;
                var link = new LinkLabel()
                {
                    Text = Path.GetFileName(f),
                    ActiveLinkColor = Color.Gray,
                    BackColor = Color.Gainsboro,
                    DisabledLinkColor = Color.LightGray,
                    LinkColor = Color.Black,
                    VisitedLinkColor = Color.Black,
                    Tag = f,
                    Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    Dock = DockStyle.Fill
                };
                link.LinkClicked += (s, evt) => {
                    if (File.Exists((string)((LinkLabel)s).Tag))
                    {
                        var m = IO.Load((string)((LinkLabel)s).Tag);
                        if (m != null)
                            o.AddFile(new DrawPanel(m));
                    }
                    else
                    {
                        MessageBox.Show("This file does not exist. It will be removed from the recent list", "NetworX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        recentContainer.Controls.Remove((LinkLabel)s);
                    }
                };
                toolTip.SetToolTip(link, f);

                recentContainer.RowCount++;
                recentContainer.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
                recentContainer.Controls.Add(link, 1, recentContainer.RowCount - 1);
            }

            recentContainer.RowCount++;
            recentContainer.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
            recentContainer.Controls.Add(new Label(), 1, recentContainer.RowCount - 1);
        }

        private void LoadReddit()
        {
            if (reddit_loaded)
                return;

            wpfSpinner.Invoke(new Action(() => { wpfSpinner.Visible = true; }));

            reddit_loaded = true;
            errorLabel.Invoke(new Action(() => { errorLabel.Visible = false; }));

            new Thread(() =>
            {
                try
                {
                    var reddit = new Reddit();
                    var sub = reddit.GetSubreddit("/r/networx");
                    string[] filter = { "INFORMATION", "IMPORTANT" };
                    int important_posts = 0;

                    foreach (var post in sub.New.TakeWhile(p => {
                        if (filter.Contains(p.LinkFlairText))
                            important_posts++;
                        return important_posts < 5;
                    }))
                    {
                        if (!filter.Contains(post.LinkFlairText))
                            continue;

                        var pcontrol = new Controls.RedditPost()
                        {
                            Title = post.Title,
                            Content = post.SelfText,
                            Dock = DockStyle.Fill
                        };
                        pcontrol.Click += (s, evt) => {
                            if (post.IsSelfPost)
                                System.Diagnostics.Process.Start("http://www.reddit.com" + post.Permalink.ToString());
                            else
                                System.Diagnostics.Process.Start(post.Url.ToString());
                        };
                        toolTip.SetToolTip(pcontrol, "Click to see more");

                        tableRedditPosts.Invoke(new Action(() =>
                        {
                            tableRedditPosts.RowCount++;
                            tableRedditPosts.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
                            tableRedditPosts.Controls.Add(pcontrol, 1, tableRedditPosts.RowCount - 1);
                        }));

                    }

                    tableRedditPosts.Invoke(new Action(() =>
                    {
                        tableRedditPosts.RowCount++;
                        tableRedditPosts.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));
                        tableRedditPosts.Controls.Add(new Label(), 1, tableRedditPosts.RowCount - 1);
                    }));

                    wpfSpinner.Invoke(new Action(() => { wpfSpinner.Visible = false; }));
                } catch (Exception)
                {
                    wpfSpinner.Invoke(new Action(() => { wpfSpinner.Visible = false; }));
                    errorLabel.Invoke(new Action(() => { errorLabel.Visible = true; }));
                }
            }).Start();
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner.AddFile(new DrawPanel(new Map()));
        }

        private void lnkOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var m = IO.Load();

            if (m == null)
                return;

            Owner.AddFile(new DrawPanel(m));
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
