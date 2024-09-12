using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    [ServiceContract]
    public interface ILobbyService
    {
        [OperationContract]
        bool Login(string username);

        //[OperationContract]
        //bool isUserNameAvailable(string username);

        [OperationContract]
        void Logout(string username);

        [OperationContract]
        List<string> GetAvailableRooms();

        [OperationContract]
        bool CreateRoom(string roomName);

        [OperationContract]
        bool JoinRoom(string username, string roomName);

        [OperationContract]
        bool LeaveRoom(string username, string roomName);

        [OperationContract]
        void SendMessage(string username, string message, string roomName);

        [OperationContract]
        List<string> GetMessages(string roomName);

        [OperationContract]
        void SendPrivateMessage(string fromUser, string toUser, string message);

        [OperationContract]
        void ShareFile(string username, string roomName, byte[] fileData, string fileName);
    }
}
