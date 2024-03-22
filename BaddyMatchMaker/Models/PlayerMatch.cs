using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class PlayerMatch
    {
        public int PlayerMatchId { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}
