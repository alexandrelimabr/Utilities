using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vlc.DotNet.Core.Interops;

namespace VlcFormTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Vlc.DotNet.Forms.VlcControl player;
        public MainWindow()
        {
            InitializeComponent();

            player = new Vlc.DotNet.Forms.VlcControl();

            winformsHost.Child = player;
            player.Visible = true;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Vlc.DotNet.Core.VlcMediaPlayer player2 = new Vlc.DotNet.Core.VlcMediaPlayer();

            player.Play(new Uri(txtURI.Text));
        }
    }
}
