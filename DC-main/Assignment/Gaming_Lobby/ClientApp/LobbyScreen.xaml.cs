﻿using System;
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
    /// Interaction logic for LobbyScreen.xaml
    /// </summary>
    public partial class LobbyScreen : Window
    {
        public LobbyScreen(ILobbyService client, string username)
        {
            InitializeComponent();
        }

        private void CreateRoomButton_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void JoinRoomButton_Click(Object sender, RoutedEventArgs e)
        {

        }
    }
}
