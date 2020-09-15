using System;
using System.Drawing;
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
            Graphics graph = Graphics.FromImage(bmp);
            //get screenshot and copy to bmp
            graph.CopyFromScreen(ScreenSize.X, ScreenSize.Y, 0, 0, ScreenSize.Size, CopyPixelOperation.SourceCopy);

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
    }
}
