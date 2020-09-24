using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMapCreator.Windows
{
    public partial class GameConnectionDialog : Form
    {
        private bool ServerRunning = true;

        public GameConnectionDialog()
        {
            InitializeComponent();

            new Thread(ConnectionAcception_Thread).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerRunning = false;
            Close();
        }
        
        private void ConnectionAcception_Thread()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ipAddress, 1414);
            listener.Start();
            
            while (ServerRunning)
            {
                Socket game = listener.AcceptSocket();

                new Thread(() =>
                {
                    var gamecon = new GameConnection.GameConnection();
                    gamecon.HeaderReceived += () =>
                    {
                        listBox1.Invoke(new Action(() => { listBox1.Items.Add(gamecon.ApplicationName); }));
                    };
                    gamecon.Initialize(game);
                }).Start();
            }
        }

        private void GameConnectionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ServerRunning = false;
        }
    }
}
