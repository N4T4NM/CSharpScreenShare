using ScreenShare.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace ScreenShare.Server
{
    class ScreenShareConnection
    {
        Socket socket;
        NetworkStream stream;
        Thread sendScreen;
        Thread receiveInput;

        public delegate void ClosedConnectionEvent();
        public event ClosedConnectionEvent ClosedConnection;
        public ScreenShareConnection(Socket socket)
        {
            //get connection stream
            this.socket = socket;
            stream = new NetworkStream(socket);

            //start sending screen
            sendScreen = new Thread(new ThreadStart(SendScreen)) { IsBackground = true };
            sendScreen.Start();

            //start receiving input
            receiveInput = new Thread(new ThreadStart(ReceiveInput)) { IsBackground = true };
            receiveInput.Start();
        }
        public void Close()
        {
            //close connection
            ClosedConnection();
            socket.Close();
        }
        private void SendScreen()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    //get screenshot and send
                    formatter.Serialize(stream, ScreenUtils.GetScreen());
                    Thread.Sleep(5);
                }
            } catch (Exception ex)
            {
                //log errors and close
                Debug.WriteLine(ex.Message);
                Close();
            }
        }
        private void ReceiveInput()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    //receive and handle user input
                    InputData input = (InputData)formatter.Deserialize(stream);
                    switch(input.InputType)
                    {
                        case InputType.Mouse:
                            HandleMouseInput(input, input.MouseAction);
                            break;
                        case InputType.Keyboard:
                            HandleKeyboardInput(input, input.KeyboardAction);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Close();
            }
        }
        InputSimulator inputSimulator = new InputSimulator();
        #region MouseActions
        private void HandleMouseInput(InputData input, ActionType ActionType)
        {
            //convert position between resolutions
            Point parsed = ScreenUtils.TranslatePosition(input.MouseX, input.MouseY, input.CurrentSize);
            //handle mouse input
            switch(ActionType)
            {
                case ActionType.MouseButtonDown:
                    HandleMouseDown(parsed, input.MouseButton);
                    break;
                case ActionType.MouseButtonUp:
                    HandleMouseUp(input.MouseButton);
                    break;
                case ActionType.MouseDrag:
                    if (!holding)
                        break;
                    Cursor.Position = parsed;
                    break;
            }
        }
        bool holding = false;
        private void HandleMouseDown(Point Loc, MouseButtons Butt)
        {
            //handle mouse down
            Cursor.Position = Loc;
            Thread.Sleep(100);
            switch(Butt)
            {
                case MouseButtons.Left:
                    inputSimulator.Mouse.LeftButtonDown();
                    break;
                case MouseButtons.Right:
                    inputSimulator.Mouse.RightButtonDown();
                    break;
            }
            holding = true;
        }
        private void HandleMouseUp(MouseButtons Butt)
        {
            //handle mouse up
            switch (Butt)
            {
                case MouseButtons.Left:
                    inputSimulator.Mouse.LeftButtonUp();
                    break;
                case MouseButtons.Right:
                    inputSimulator.Mouse.RightButtonUp();
                    break;
            }
            holding = false;
        }
        #endregion
        #region KeyboardActions
        private void HandleKeyboardInput(InputData input, ActionType ActionType)
        {
            //handle key down and keyup
            switch (ActionType)
            {
                case ActionType.KeyDown:
                    inputSimulator.Keyboard.KeyDown((VirtualKeyCode)input.KeyCode);
                    break;
                case ActionType.KeyUp:
                    inputSimulator.Keyboard.KeyUp((VirtualKeyCode)input.KeyCode);
                    break;
            }
        }
        #endregion
    }
}
