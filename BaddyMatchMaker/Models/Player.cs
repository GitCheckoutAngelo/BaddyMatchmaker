using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Player
    {
        public Player()
        {
            PlayerMatches = new HashSet<PlayerMatch>();
            SessionPlayers = new HashSet<SessionPlayer>();
        }

        public int PlayerId { get; set; }
        public int ClubId { get; set; }

        public string Name { get; set; }
        public string Sex { get; set; }
        public int Grade { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual Club Club { get; set; }
        public virtual ICollection<PlayerMatch> PlayerMatches { get; set; }
        public virtual ICollection<SessionPlayer> SessionPlayers { get; set; }
    }
}
