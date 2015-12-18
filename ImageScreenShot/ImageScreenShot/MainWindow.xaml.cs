using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string fileScreenShotFull = @"c:\temp\Print.jpg";
        static string fileResized = @"c:\temp\PrintResized.jpg";
        static int x;
        static int y;

        static int width;
        static int height;


        public MainWindow()
        {
            InitializeComponent();
        }

        public object Screen { get; private set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Faz um screenshot da tela inteira e salva como imagem
            int totalWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int totalHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            Image newImage = ImageHelper.CaptureScreen(0, 0, 0, 0, new System.Drawing.Size(totalWidth, totalHeight));
            newImage.Save(fileScreenShotFull);
            imgTarget.Source = new BitmapImage(new Uri(fileScreenShotFull));

            //Pega as coordenadas do controle original onde a imagem é mostrada
            System.Windows.Point p = imgSource.PointToScreen(new System.Windows.Point(0d, 0d));

            x = (int)p.X;
            y = (int)p.Y;

            width = (int)imgSource.Width - 1;
            height = (int)imgSource.Height;

            //Faz um crop da imagem criada acima usando as dimensões do controle original e salva esta nova imagem
            Rectangle cloneRect = new Rectangle(x, y, width, height);
            Bitmap bmpImage = new Bitmap(fileScreenShotFull);
            Bitmap clonedBitMap = bmpImage.Clone(cloneRect, bmpImage.PixelFormat);
            clonedBitMap.Save(fileResized);
            clonedBitMap.Dispose();
            imgFinal.Source = new BitmapImage(new Uri(fileResized));

        }

    }
}