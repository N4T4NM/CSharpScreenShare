using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShare.Utils
{
    //make class serializable
    [Serializable]
    class InputData
    {
        public InputType InputType { get; set; }

        public int MouseX { get; set; }
        public int MouseY { get; set; }
        public Size CurrentSize { get; set; }
        public MouseButtons MouseButton { get; set; }
        public ActionType MouseAction { get; set; }

        public ActionType KeyboardAction { get; set; }
        public Keys KeyCode { get; set; }
    }

    public enum InputType
    {
        Mouse,
        Keyboard
    }

    public enum ActionType
    {
        MouseButtonDown,
        MouseButtonUp,
        MouseDrag,
        KeyDown,
        KeyUp
    }
}
