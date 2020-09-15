using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ScreenShare.Server
{
    public class ScreenShareServer
    {

        Socket listener;
        Thread listenThread;
        ScreenShareConnection connection;

        public ScreenShareServer()
        {

        }

        public void StartListener()
        {
            //create listener socket
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 7075));
            listener.Listen(1);

            //start waiting for connections
            listenThread = new Thread(new ThreadStart(WaitConnection)) { IsBackground = true };
            listenThread.Start();
        }

        public void StopListener()
        {
            //stop listening and sending
            listener.Close();
            if (listenThread != null)
            {
                listenThread.Abort();
                listenThread = null;
            }
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }

        private void WaitConnection()
        {
                try
                {
                    while(true)
                    {
                        //connection received
                        Socket screenConnection = listener.Accept();

                        //get connection ip data
                        string[] ipData = (screenConnection.RemoteEndPoint as IPEndPoint).Address.ToString().Split(':');

                        //check if user want accept this connection
                        if (MessageBox.Show($"Incoming connection from: {ipData[ipData.Length - 1]}\nAccept connection ?",
                            "Connection Request",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                        //create connection
                            connection = new ScreenShareConnection(screenConnection);
                            connection.ClosedConnection += OnClosedConnection;
                            break;
                        }
                        else
                        //close connection when refused
                            screenConnection.Close();
                    }
                    
                } catch (Exception ex)
                {
                //log errors
                    Debug.WriteLine(ex.Message);
                }
        }

        private void OnClosedConnection()
        {
            connection = null;
            //start waiting for connections again
            listenThread = new Thread(new ThreadStart(WaitConnection)) { IsBackground = true };
            listenThread.Start();
        }
    }
}
