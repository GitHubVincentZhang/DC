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

        public bool Login(string username)
        {
            if (activeUsers.Contains(username)) return false;
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
