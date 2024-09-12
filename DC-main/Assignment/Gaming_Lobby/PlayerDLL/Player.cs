using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDLL
{
    public class Player
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public override string ToString()
        {
            string info = $"Player UserName: {Username}";
            return info;
        }
    }
}
