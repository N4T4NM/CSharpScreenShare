using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace ScreenShare.Client
{
    class ScreenShareClient
    {
        public PictureBox _pic;
        Socket client;
        public NetworkStream stream;

        Thread recvThread;

        public delegate void ClientDisconnectedEvent();
        public event ClientDisconnectedEvent ClientDisconnected;
        public ScreenShareClient(PictureBox SharePanel)
        {
            //get picture box
            _pic = SharePanel;
        }

        public void Connect(IPAddress ip)
        {
            //create socket and connect to remote server
            client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            client.Connect(new IPEndPoint(ip, 7075));

            //get network stream
            stream = new NetworkStream(client);

            //start receiving remote desktop
            recvThread = new Thread(new ThreadStart(ReceiveRemoteData)) { IsBackground = true };
            recvThread.Start();
        }

        public void Close()
        {
            //close connection
            client.Close();
            ClientDisconnected();
        }
        private void ReceiveRemoteData()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    //get remote desktop image
                    var img = (Image)formatter.Deserialize(stream);
                    _pic.Invoke(new Action(() => { _pic.Image = img; }));
                }
            } catch (Exception ex)
            {
                //log errors and close connection
                Debug.WriteLine(ex.Message);
                Close();
            }
        }
    }
}
