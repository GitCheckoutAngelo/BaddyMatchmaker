using System;
using System.Collections.Generic;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Session
    {
        private readonly List<Round> rounds;
        private readonly List<SessionPlayer> sessionPlayers;

        public Session()
        {
            rounds = new List<Round>();
            sessionPlayers = new List<SessionPlayer>();
        }

        public int SessionId { get; set; }
        public int ClubId { get; set; }
        public int VenueId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Active { get; set; }

        public Club Club { get; set; }
        public Venue Venue { get; set; }
        public IReadOnlyCollection<Round> Rounds => rounds.AsReadOnly();
        public IReadOnlyCollection<SessionPlayer> SessionPlayers => sessionPlayers.AsReadOnly();

        public void SignInPlayer(SessionPlayer sessionPlayer) {
            sessionPlayers.Add(sessionPlayer);
        }

        public void StartSession()
        {
            Active = true;
        }

        public void EndSession()
        {
            Active = false;
        }
    }
}
