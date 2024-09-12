using PlayerDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] // Ensuring a single instance for all clients
    public class LobbyService : ILobbyService
    {
        private static Dictionary<string, List<string>> rooms = new Dictionary<string, List<string>>();
        private static Dictionary<string, List<string>> roomMessages = new Dictionary<string, List<string>>();
        private static HashSet<string> activeUsers = new HashSet<string>();


        private static List<Player> activePlayers = PlayerList.Players();

        //public bool isUserNameAvailable(string username)
        //{
        //    foreach (Player player in activePlayers)
        //    {
        //        if (player.Username == username)
        //        {
        //            return false; // iff username is already taken
        //        }
       
        //    }
        //    return true; // the username is avaialable
        //}
        public bool Login(string username)
        {
            Console.WriteLine("Attempting login for username: " + username);
            if (!PlayerList.IsUserNameAvailable(username))
            {
                //Console.WriteLine("Username not available");
                return false; 
            }

            if (activeUsers.Contains(username))
            {
                //Console.WriteLine("Username already active");
                return false;
            }

            activeUsers.Add(username);
            return true;
        }

        public void Logout(string username)
        {
            activeUsers.Remove(username);
        }

        public List<string> GetAvailableRooms()
        {
            return new List<string>(rooms.Keys);
        }

        public bool CreateRoom(string roomName)
        {
            if (rooms.ContainsKey(roomName)) return false;
            rooms[roomName] = new List<string>();
            roomMessages[roomName] = new List<string>();
            return true;
        }

        public bool JoinRoom(string username, string roomName)
        {
            if (!rooms.ContainsKey(roomName)) return false;
            if (!rooms[roomName].Contains(username)) rooms[roomName].Add(username);
            return true;
        }

        public bool LeaveRoom(string username, string roomName)
        {
            if (!rooms.ContainsKey(roomName)) return false;
            rooms[roomName].Remove(username);
            return true;
        }

        public void SendMessage(string username, string message, string roomName)
        {
            if (rooms.ContainsKey(roomName))
            {
                roomMessages[roomName].Add($"{username}: {message}");
            }
        }

        public List<string> GetMessages(string roomName)
        {
            if (roomMessages.ContainsKey(roomName))
            {
                return roomMessages[roomName];
            }
            return new List<string>();
        }

        public void SendPrivateMessage(string fromUser, string toUser, string message)
        {
            // Logic for private message
        }

        public void ShareFile(string username, string roomName, byte[] fileData, string fileName)
        {
            // Logic for sharing files in a room
        }
    }
}
