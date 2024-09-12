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
using Client;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LobbyServiceClient client = new LobbyServiceClient();
        string currentUsername;
        string currentRoom;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Handle Login Button Click
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            currentUsername = UsernameTextBox.Text;
            if (!string.IsNullOrEmpty(currentUsername))
            {
                bool loginSuccess = client.Login(currentUsername);
                if (loginSuccess)
                {
                    MessageBox.Show("Login successful!");
                }
                else
                {
                    MessageBox.Show("Username is already taken!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a username!");
            }
        }

        // Handle Create Room Button Click
        private void CreateRoomButton_Click(object sender, RoutedEventArgs e)
        {
            string roomName = RoomTextBox.Text;
            if (!string.IsNullOrEmpty(roomName))
            {
                bool roomCreated = client.CreateRoom(roomName);
                if (roomCreated)
                {
                    MessageBox.Show("Room created successfully!");
                }
                else
                {
                    MessageBox.Show("Room name already exists!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a room name!");
            }
        }

        // Handle Join Room Button Click
        private void JoinRoomButton_Click(object sender, RoutedEventArgs e)
        {
            currentRoom = RoomTextBox.Text;
            if (!string.IsNullOrEmpty(currentRoom))
            {
                bool joined = client.JoinRoom(currentUsername, currentRoom);
                if (joined)
                {
                    MessageBox.Show($"Joined room: {currentRoom}");
                }
                else
                {
                    MessageBox.Show("Failed to join the room.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a room name!");
            }
        }

        // Handle Send Message Button Click
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            if (!string.IsNullOrEmpty(currentRoom) && !string.IsNullOrEmpty(message))
            {
                client.SendMessage(currentUsername, message, currentRoom);
                MessageTextBox.Clear();

                var messages = client.GetMessages(currentRoom);
                MessagesListBox.ItemsSource = messages;
            }
            else
            {
                MessageBox.Show("Please enter a message and join a room!");
            }
        }
    }
}
