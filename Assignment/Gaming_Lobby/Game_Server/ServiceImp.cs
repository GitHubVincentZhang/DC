using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] // Ensuring a single instance for all clients
    public class GamingLobbyService : IGamingLobbyService
    {
        private Dictionary<string, List<string>> rooms = new Dictionary<string, List<string>>();
        private List<string> loggedInUsers = new List<string>();

        public bool Login(string username)
        {
            if (!loggedInUsers.Contains(username))
            {
                loggedInUsers.Add(username);
                return true;
            }
            return false;
        }

        public bool CreateRoom(string roomName)
        {
            if (!rooms.ContainsKey(roomName))
            {
                rooms[roomName] = new List<string>();
                return true;
            }
            return false;
        }

        public bool JoinRoom(string roomName, string username)
        {
            if (rooms.ContainsKey(roomName) && !rooms[roomName].Contains(username))
            {
                rooms[roomName].Add(username);
                return true;
            }
            return false;
        }

        public void LeaveRoom(string roomName, string username)
        {
            if (rooms.ContainsKey(roomName))
            {
                rooms[roomName].Remove(username);
            }
        }

        public void SendMessage(string roomName, string message)
        {
            // This would ideally involve a callback to all clients in the room
        }

        public void SendPrivateMessage(string fromUser, string toUser, string message)
        {
            // This would ideally involve a callback to the specific client
        }

        public List<string> GetRooms()
        {
            return rooms.Keys.ToList();
        }

        public List<string> GetRoomParticipants(string roomName)
        {
            if (rooms.ContainsKey(roomName))
            {
                return rooms[roomName];
            }
            return new List<string>();
        }
    }
}
