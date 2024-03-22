using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Sessions = new HashSet<Session>();
        }

        public int VenueId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfCourts { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
