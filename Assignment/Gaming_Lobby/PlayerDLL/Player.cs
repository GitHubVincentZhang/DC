using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDLL
{
    public class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class Player : Person
    {
        private int id;
        private string gameTag;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string GameTag
        {
            get { return gameTag; }
            set { gameTag = value; }
        }

        public override string ToString()
        {
            string info = $"Player Name: {Name}\n";
            info += $"Player ID: {Id}\n";
            info += $"Player GameTag: {GameTag}";
            return info;
        }
    }
}
