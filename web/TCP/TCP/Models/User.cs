using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCP.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public int Highscore { get; set; }

        public string Password { get; set; }
    }
}
