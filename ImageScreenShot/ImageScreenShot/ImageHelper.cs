using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    static class ImageHelper
    {

        public static Image CaptureScreen(int sourceX, int sourceY, int destX, int destY,
            System.Drawing.Size regionSize)
        {
            Bitmap bmp = new Bitmap(regionSize.Width, regionSize.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(sourceX, sourceY, destX, destY, regionSize);

            Bitmap result = cropAtRect(bmp, new Rectangle(sourceX, sourceY, regionSize.Width, regionSize.Height));

            return result;
        }

        private static Bitmap cropAtRect(this Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b, -r.X, -r.Y);
            return nb;
        }

    }
}
