using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Match
    {
        public Match()
        {
            PlayerMatches = new HashSet<PlayerMatch>();
        }

        public int MatchId { get; set; }
        public int CourtNumber { get; set; }
        public int RoundId { get; set; }

        public virtual Round Round { get; set; }
        public virtual ICollection<PlayerMatch> PlayerMatches { get; set; }

        public PlayerMatch GetPlayer(int playerId)
        {
            return PlayerMatches.FirstOrDefault(pm => pm.PlayerId == playerId);
        }
    }
}
