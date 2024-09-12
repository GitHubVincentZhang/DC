using PlayerDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    public class PlayerList
    { 
        private static HashSet<string> playerUsernames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        static PlayerList()
        {
            InitialisePlayers();
        }

        private static void InitialisePlayers()
        {
            // Creating sample players
            Player player1 = new Player { Username = "Robert" };
            Player player2 = new Player { Username = "Mia" };

            // Adding usernames to the HashSet
            playerUsernames.Add(player1.Username);
            playerUsernames.Add(player2.Username);
        }

        // Method to check if the username is available
        public static bool IsUserNameAvailable(string username)
        {
            // Check if the username is in the HashSet
            return !playerUsernames.Contains(username);
        }

        // Optional method to add a new player if needed
        public static bool AddPlayer(Player player)
        {
            // Attempt to add the player's username to the HashSet
            return playerUsernames.Add(player.Username);
        }

        // Optional method to remove a player if needed
        public static bool RemovePlayer(Player player)
        {
            // Attempt to remove the player's username from the HashSet
            return playerUsernames.Remove(player.Username);
        }
    }
}
