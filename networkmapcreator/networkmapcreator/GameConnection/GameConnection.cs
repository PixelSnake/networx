using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace NetworkMapCreator.GameConnection
{
    public class GameConnection
    {
        private Socket Socket;

        public bool Authorized { get; private set; }

        public string Protocol { get; private set; }
        public string ProtocolVersion { get; private set; }
        public string ApplicationName { get; private set; }

        public delegate void HeaderReceivedEventHandler();
        public event HeaderReceivedEventHandler HeaderReceived;

        public void Initialize(Socket sock)
        {
            Socket = sock;

            if (AwaitHeader())
                Authorized = true;

            if (Authorized)
                new Thread(NIP_Thread).Start();
        }

        private bool AwaitHeader()
        {
            var req = ReceiveXml("header");

            System.Diagnostics.Debug.WriteLine(req);

            if (IsProtocolValid(req.GetAttribute("protocol")))
            {
                Protocol = req.GetAttribute("protocol");
                ProtocolVersion = req.GetAttribute("version");
                ApplicationName = req.GetAttribute("application");

                HeaderReceived?.Invoke();

                return true;
            }

            return false;
        }

        private void NIP_Thread()
        {
            while (true)
            {
                byte[] data = new byte[1024];
                try
                {
                    int size = Socket.Receive(data);

                    byte[] msg = new byte[size];
                    for (int i = 0; i < size; ++i)
                        msg[i] = data[i];
                }
                catch (Exception)
                {
                    Socket.Close();
                    return;
                }
            }
        }


        private bool IsProtocolValid(string p)
        {
            switch (p)
            {
                case "NIP":
                    return true;

                default:
                    return false;
            }
        }

        private XmlElement ReceiveXml(string type = "request")
        {
            byte[] data = new byte[1024];

            int size = Socket.Receive(data);

            byte[] msg = new byte[size];
            for (int i = 0; i < size; ++i)
                msg[i] = data[i];

            var str = Encoding.UTF8.GetString(msg);
            System.Diagnostics.Debug.WriteLine(str);
            var doc = new XmlDocument();
            doc.LoadXml(str);

            return doc[type];
        }
    }
}
