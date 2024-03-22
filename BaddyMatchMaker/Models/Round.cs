using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class Round 
    {
        private readonly List<Match> matches;

        public Round() { }

        public Round(Session session, List<Match> matches, int numberOfCourts, int roundNumber)
        {
            this.matches = matches;
            Session = session;
            CourtsAvailable = numberOfCourts;
            RoundNumber = roundNumber;
        }

        public int RoundId { get; set; }
        public int SessionId { get; set; }
        public int RoundNumber { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CourtsAvailable { get; set; }

        public virtual Session Session { get; set; }
        public IReadOnlyCollection<Match> Matches => matches.AsReadOnly();

        private Match FindPlayerMatch(int playerId)
        {
            var match = Matches.FirstOrDefault(m => m.GetPlayer(playerId) != null);
            if (match == null)
            {
                throw new Exception("Player not found.");
            }

            return match;
        }

        public void SwapPlayers(int player1Id, int player2Id)
        {
            var player1Match = FindPlayerMatch(player1Id);
            var player2Match = FindPlayerMatch(player2Id);

            if (player1Match.MatchId == player2Match.MatchId)
            {
                throw new Exception("Players in the same match.");
            }

            // remove player1 from original match then add to player2's original match
            var player1 = player1Match.PlayerMatches.First(pm => pm.PlayerId == player1Id);
            player1Match.PlayerMatches.Remove(player1);
            player2Match.PlayerMatches.Add(player1);

            // remove player2 from original match then add to player1's original match
            var player2 = player2Match.PlayerMatches.First(pm => pm.PlayerId == player2Id);
            player2Match.PlayerMatches.Remove(player2);
            player1Match.PlayerMatches.Add(player2);
        }

    }
}
