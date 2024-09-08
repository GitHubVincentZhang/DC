using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    [ServiceContract]
    public interface IGamingLobbyService
    {
        [OperationContract]
        bool Login(string username);

        [OperationContract]
        bool CreateRoom(string roomName);

        [OperationContract]
        bool JoinRoom(string roomName, string username);

        [OperationContract]
        void LeaveRoom(string roomName, string username);

        [OperationContract]
        void SendMessage(string roomName, string message);

        [OperationContract]
        void SendPrivateMessage(string fromUser, string toUser, string message);

        [OperationContract]
        List<string> GetRooms();

        [OperationContract]
        List<string> GetRoomParticipants(string roomName);
    }
}
