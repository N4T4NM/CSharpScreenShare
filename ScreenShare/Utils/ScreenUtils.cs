using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenShare.Utils
{
    class ScreenUtils
    {
        public static Image GetScreen()
        {
            //get screen size and create bmp object
            Rectangle ScreenSize = Screen.PrimaryScreen.Bounds;
            Bitmap bmp = new Bitmap(ScreenSize.Width, ScreenSize.Height, 
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //create graphics object from bmp
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                //get screenshot and copy to bmp
                graph.CopyFromScreen(ScreenSize.X, ScreenSize.Y, 0, 0, ScreenSize.Size, CopyPixelOperation.SourceCopy);

                //create cursor info object
                CURSORINFO pci;
                pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                if(GetCursorInfo(out pci))
                {
                    //check if cursor is visible
                    if(pci.flags == CURSOR_SHOWING)
                    {
                        //draw cursor into bmp
                        DrawIcon(graph.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                        graph.ReleaseHdc();
                    }
                }
            }
            //return bmp
            return bmp;
        }

        public static Point TranslatePosition(int MouseX, int MouseY, Size RemoteSize)
        {
            //get local screen resolution
            Rectangle CurrentScreen = Screen.PrimaryScreen.Bounds;

            //transform sender mouse input and resolution into local coords
            int newX = MouseX * CurrentScreen.Width / RemoteSize.Width;
            int newY = MouseY * CurrentScreen.Height / RemoteSize.Height;

            //return local coords
            return new Point(newX, newY);
        }

        #region CursorUtils
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;
        #endregion
    }
}
