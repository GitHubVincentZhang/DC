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
        public static List<Player> Players()
        {
            List<Player> plist = new List<Player>();

            // Creating sample players
            Player player1 = new Player();
            player1.Name = "Robert";
            player1.GameTag = "RobFighter";
            player1.Id = 101;

            Player player2 = new Player();
            player2.Name = "Mia";
            player2.GameTag = "MiaCombo";
            player2.Id = 102;

            Player player3 = new Player();
            player3.Name = "Adam";
            player3.GameTag = "AdamSlasher";
            player3.Id = 103;

            Player player4 = new Player();
            player4.Name = "Sophia";
            player4.GameTag = "SophiaBlade";
            player4.Id = 104;

            Player player5 = new Player();
            player5.Name = "Ethan";
            player5.GameTag = "EthanThunder";
            player5.Id = 105;

            // Adding players to the list
            plist.Add(player1);
            plist.Add(player2);
            plist.Add(player3);
            plist.Add(player4);
            plist.Add(player5);

            return plist;
        }
    }
}
