using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PlayerDLL;

namespace Game_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Game_Server.LobbyService)))
            {
                host.Open();
                Console.WriteLine("Lobby service is running...");
                Console.ReadLine(); // Keep the server running
            }
        }
    }
}
