using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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

namespace DigifortPlayerPOC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AxXDigiLiveCore.AxDigiLiveCore player;
        string connectionString = string.Empty;

        string serverName;
        string cameraName;

        int objectTypes;
        bool isConnected = false;

        byte OBJECTTYPE_NONE = 0x0;
        byte OBJECTTYPE_SCREENSTYLE = 0x1;
        byte OBJECTTYPE_USER_SCREENVIEW = 0x2;
        byte OBJECTTYPE_PUBLIC_SCREENVIEW = 0x4;
        byte OBJECTTYPE_CAMERA = 0x8;
        byte OBJECTTYPE_MAP = 0x10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            player = new AxXDigiLiveCore.AxDigiLiveCore();
            player.Width = 640;
            player.Height = 480;
            host.Child = player;

            this.spPlayer.Children.Add(host);
            player.OnConnectionStatus += Player_OnConnectionStatus;
            player.OnConnectionComplete += Player_OnConnectionComplete;

            LoadCamerasFromConfig();
     

            cboCameras.SelectedIndex = 0;
        }

        private void LoadCamerasFromConfig()
        {
            Hashtable table = new Hashtable((from key in System.Configuration.ConfigurationManager.AppSettings.Keys.Cast<string>()
                                             let value = System.Configuration.ConfigurationManager.AppSettings[key]
                                             select new { key, value }).ToDictionary(x => x.key, x => x.value));
            foreach (string name in table.Keys)
            {
                string line = string.Format("{0};{1}", name.ToString(), table[name].ToString());
                cboCameras.Items.Add(line);
            }



        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try {

                string username = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtUsername.Text));
                string password = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtPassword.Text));

                string item = (string) cboCameras.Text;      
                string[] vars = item.Split(';');

                cameraName = vars[0];
                serverName = vars[1];

                connectionString = string.Format("NA:server,AD:{2},PO:8600,US:{0},PW:{1},CM:2", username, password, serverName);

                objectTypes = (OBJECTTYPE_SCREENSTYLE | OBJECTTYPE_USER_SCREENVIEW |OBJECTTYPE_PUBLIC_SCREENVIEW | OBJECTTYPE_CAMERA | OBJECTTYPE_MAP);

                if (!isConnected)
                {                 
                    //Disable Show Description of Camera on Video
                    player.SetConfig(100, false);
                    //Connect
                    player.Connect(connectionString, objectTypes, true, false);
                }
            }
            catch (Exception error)
            {
                WriteMessage(error.Message);
            }
            finally
            {
                WriteMessage("Terminado");
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            string item = (string)cboCameras.Text;
            string[] vars = item.Split(';');

            cameraName = vars[0];

            player.MatrixScreenStyle = 0;
            player.MatrixAddObject(0x8, "server", cameraName, -1);
            isConnected = true;
            btnPlay.IsEnabled = false;
        }

        private void Player_OnConnectionComplete(object sender, EventArgs e)
        {
            WriteMessage("Connection OK!");
            btnConnect.Content = "Connected";
            btnConnect.IsEnabled = false;
        }

        private void Player_OnConnectionStatus(object sender, AxXDigiLiveCore.IDigiLiveCoreEvents_OnConnectionStatusEvent e)
        {
            WriteMessage("Connection Status: "+ e.status + "-"+ e.msg);
        }

        private void WriteMessage(string message)
        {
            logView.Text += logView.Text + System.Environment.NewLine + message;
        }

        private void cboCameras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnPlay.IsEnabled = true;
        }
    }
}
