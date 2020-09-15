using ScreenShare.Client;
using ScreenShare.Server;
using ScreenShare.Utils;
using System;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        ScreenShareServer server;
        ScreenShareClient client;
        private void ShareScreenButton_Click(object sender, EventArgs e)
        {
            //check if server is running
                if (server == null)
                {
                //try run server
                    try { 
                    //create server and listen
                    server = new ScreenShareServer();
                    server.StartListener();
                    
                    //change share button
                    ShareScreenButton.Text = "Stop";
                    }
                    catch (Exception ex)
                    {
                    //show error message and change share button
                    MessageBox.Show("Cannot share: " + ex.Message);
                    server = null;
                    ShareScreenButton.Text = "Share";
                    }
                }
                else
                {
                //stop server and change server button
                    server.StopListener();
                    server = null;
                    ShareScreenButton.Text = "Share";
                }
            
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            //check if client is connected
            if(client == null)
            {
                //create picturebox to receive remote screen
                PictureBox picture = new PictureBox();
                picture.Anchor = ImageHolderPanel.Anchor;
                picture.Size = ImageHolderPanel.Size;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                //add input handlers
                picture.MouseDown += HandleScreenClick;
                picture.MouseUp += HandleScreenUnclick;
                picture.MouseMove += HandleScreenMove;
                picture.MouseEnter += delegate { Cursor.Hide(); };
                picture.MouseLeave += delegate { Cursor.Show(); };
                
                //add picturebox to panel
                ImageHolderPanel.Controls.Clear();
                ImageHolderPanel.Controls.Add(picture);
                picture.Focus();

                try
                {
                    //create client and connect
                    client = new ScreenShareClient(picture);
                    client.Connect(IPAddress.Parse(IPBox.Text));
                } catch (Exception ex)
                {
                    //show error on screen and remove picture box
                    MessageBox.Show("Cannot connect: " + ex.Message);
                    client = null;
                    ImageHolderPanel.Controls.Clear();
                    return;
                }
                //add disconnect handler
                client.ClientDisconnected += HandleDisconnected;
                ConnectButton.Text = "Disconnect";
                IPBox.Enabled = false;
                ShareScreenButton.Enabled = false;
            } else
            {
                //close connection
                client.Close();
                client = null;
                //remove picture and change connect button
                ImageHolderPanel.Controls.Clear();
                ConnectButton.Text = "Connect";
                IPBox.Enabled = true;
                ShareScreenButton.Enabled = true;
            }
        }

        private void HandleDisconnected()
        {
            //remove picture and change connect button
            client = null;
            Invoke(new Action(() =>
            {
                ImageHolderPanel.Controls.Clear();
                ConnectButton.Text = "Connect";
                IPBox.Enabled = true;
                ShareScreenButton.Enabled = true;
            }));
        }

        private void HandleScreenMove(object sender, MouseEventArgs e)
        {
            //get move input data
            BinaryFormatter formatter = new BinaryFormatter();
            InputData data = new InputData();
            data.MouseAction = ActionType.MouseDrag;
            data.MouseX = e.X;
            data.MouseY = e.Y;
            data.InputType = InputType.Mouse;
            data.CurrentSize = ((PictureBox)sender).Size;

            //send serialized input
            formatter.Serialize(client.stream, data);
        }

        private void HandleScreenClick(object sender, MouseEventArgs e)
        {
            //get mouse down input data
            BinaryFormatter formatter = new BinaryFormatter();
            InputData data = new InputData();
            data.MouseAction = ActionType.MouseButtonDown;
            data.MouseButton = e.Button;
            data.MouseX = e.X;
            data.MouseY = e.Y;
            data.InputType = InputType.Mouse;
            data.CurrentSize = ((PictureBox)sender).Size;

            //send serialized input
            formatter.Serialize(client.stream, data);
        }
        private void HandleScreenUnclick(object sender, MouseEventArgs e)
        {
            //get mouse up input data
            BinaryFormatter formatter = new BinaryFormatter();
            InputData data = new InputData();
            data.MouseAction = ActionType.MouseButtonUp;
            data.MouseButton = e.Button;
            data.MouseX = e.X;
            data.MouseY = e.Y;
            data.InputType = InputType.Mouse;
            data.CurrentSize = ((PictureBox)sender).Size;

            //send serialized input
            formatter.Serialize(client.stream, data);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //avoid infinite input loops
            if (client == null || server != null)
                return;

            //avoid local window from receiving this input
            e.SuppressKeyPress = true;
            e.Handled = true;

            //get key down input data
            BinaryFormatter formatter = new BinaryFormatter();
            InputData data = new InputData();
            data.InputType = InputType.Keyboard;
            data.KeyboardAction = ActionType.KeyDown;
            data.KeyCode = e.KeyCode;
            data.CurrentSize = (client._pic).Size;

            //send serialized input
            formatter.Serialize(client.stream, data);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {

            //avoid infinite input loops
            if (client == null || server != null)
                return;

            //avoid local window from receiving this input
            e.SuppressKeyPress = true;
            e.Handled = true;

            //get key down input data
            BinaryFormatter formatter = new BinaryFormatter();
            InputData data = new InputData();
            data.InputType = InputType.Keyboard;
            data.KeyboardAction = ActionType.KeyUp;
            data.KeyCode = e.KeyCode;
            data.CurrentSize = (client._pic).Size;

            //send serialized input
            formatter.Serialize(client.stream, data);
        }

        private void ConnectButton_KeyUp(object sender, KeyEventArgs e)
        {
            //prevent user from selecting disconnect button using keyboard
            if (client != null)
                client._pic.Focus();
        }
    }
}
