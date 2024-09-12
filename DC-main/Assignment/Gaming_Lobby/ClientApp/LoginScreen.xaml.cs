using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Game_Server;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private ILobbyService client;
        private ChannelFactory<ILobbyService> factoryConnector;
        public LoginScreen()
        {
            InitializeComponent();

            // factory for channels in server
            NetTcpBinding tcp = new NetTcpBinding();

            // set url and connection
            string URL = "net.tcp://localhost:8100/LobbyService";
            factoryConnector = new ChannelFactory<ILobbyService>(tcp, URL);
            client = factoryConnector.CreateChannel();

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            if (!string.IsNullOrEmpty(username))
            {
                bool isUnique = client.Login(username);
                if (isUnique)
                {
                    MessageBox.Show("Login was successful");
                    LobbyScreen lobby = new LobbyScreen(client, username);
                    lobby.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username is taken, choose different username");
                }
            }
            else
            {
                MessageBox.Show("Enter username");
            }
        }
    }
}
