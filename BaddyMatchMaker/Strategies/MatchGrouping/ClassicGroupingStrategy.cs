using BaddyMatchMaker.ExceptionHandling;
using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Helpers.Extensions;
using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    /// <summary>
    /// Forms doubles matches: men's, women's and mixed doubles
    /// Prioritizes regular doubles over mixed doubles
    /// </summary>
    public class ClassicGroupingStrategy : MatchGroupingStrategyBase, IMatchGroupingStrategy
    {
        public ClassicGroupingStrategy(RoundSettings roundSettings) : base(roundSettings)
        {
        }

        public List<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            //if (playerPool.Count % PlayersNeededPerMatch != 0)
            //{
            //    throw new ArgumentException($"Expected player count to be multiple of {PlayersNeededPerMatch}.");
            //}

            //var availableCourts = new Queue<int>(AvailableCourts);
            //var malePlayers = new Queue<SessionPlayer>(playerPool.Where(p => p.Player.Sex == PlayerSex.Male).OrderBy(p => p.Player.Grade));
            //var femalePlayers = new Queue<SessionPlayer>(playerPool.Where(p => p.Player.Sex == PlayerSex.Female).OrderBy(p => p.Player.Grade));

            //var matchesToCreate = playerPool.Count / PlayersNeededPerMatch;
            //if (matchesToCreate > availableCourts.Count)
            //{
            //    throw new ValidationException("Player count exceeds expected number.");
            //}

            //var matches = new List<Match>();
            //for (var i = 0; i < matchesToCreate; i++) {
            //    var dequeuedMalePlayers = malePlayers.DequeueMultiple<SessionPlayer>(PlayersNeededPerMatch).ToList();
            //    var menSkillDiff = dequeuedMalePlayers.GetSkillDiff();
            //    var menAdded = false;
            //    if (menSkillDiff == 0)
            //    {
            //        matches.Add(CreateMatch(dequeuedMalePlayers, availableCourts.Dequeue()));
            //        menAdded = true;
            //    }


            //}

            return null;
        }

        private Match CreateMatch(IEnumerable<SessionPlayer> players, int court)
        {
            return new Match
            {
                CourtNumber = court,
                PlayerMatches = players
                        .Select(p => new PlayerMatch { PlayerId = p.PlayerId })
                        .ToList()
            };
        }

    }
}
