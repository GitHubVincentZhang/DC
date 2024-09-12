using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Game_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mortal Kombat X Lobby Server!");

            // This is the actual host service system
            ServiceHost host;
            // This represents a tcp/ip binding in the Windows network stack
            NetTcpBinding tcp = new NetTcpBinding();
            // Bind server to the implementation of LobbyService
            host = new ServiceHost(typeof(LobbyService));

            /* Present the publicly accessible interface to the client. 0.0.0.0 tells .NET to
               accept on any interface. :8080 means this will use port 8080. LobbyService is a name for the
               actual service, this can be any string. */
            host.AddServiceEndpoint(typeof(ILobbyService), tcp, "net.tcp://localhost:8100/LobbyService");

            // And open the host for business!
            host.Open();
            Console.WriteLine("Server is online and listening for connections...");

            Console.WriteLine("Press Enter to shut down the server.");
            Console.ReadLine();

            // Don't forget to close the host after you're done!
            host.Close();
        }
    }
}