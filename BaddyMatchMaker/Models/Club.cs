using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Club
    {
        public Club()
        {
            Players = new HashSet<Player>();
            Sessions = new HashSet<Session>();
        }

        public int ClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Setting Setting { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
