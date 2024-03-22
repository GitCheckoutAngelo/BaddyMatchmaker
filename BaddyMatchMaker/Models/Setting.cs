using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Setting
    {
        public int ClubId { get; set; }
        public int MatchDuration { get; set; }
        public bool IgnoreSex { get; set; }
        public bool SinglesMode { get; set; }
        public bool PrioritizeMixed { get; set; }

        public virtual Club Club { get; set; }
    }
}
