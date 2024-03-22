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
    /// Groups players according to skill level regardless of sex
    /// </summary>
    public class IndiscriminateGroupingStrategy : MatchGroupingStrategyBase, IMatchGroupingStrategy
    {
        public IndiscriminateGroupingStrategy(RoundSettings roundSettings) : base(roundSettings)
        {
        }

        public List<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            if (playerPool.Count % PlayersNeededPerMatch != 0)
            {
                throw new ValidationException($"Expected player count to be multiple of {PlayersNeededPerMatch}.");
            }

            var availableCourts = new Queue<int>(AvailableCourts);
            var playerPoolOrderedBySkillLevel = new Queue<SessionPlayer>(playerPool.OrderBy(p => p.Player.Grade));

            var matchesToCreate = playerPool.Count / PlayersNeededPerMatch;
            if (matchesToCreate > availableCourts.Count)
            {
                throw new ValidationException("Player count exceeds expected number.");
            }

            var matches = new List<Match>();
            for (var i = 0; i < matchesToCreate; i++)
            {
                var match = new Match {
                    CourtNumber = availableCourts.Dequeue(),
                    PlayerMatches = playerPoolOrderedBySkillLevel
                        .DequeueMultiple(PlayersNeededPerMatch)
                        .Select(p => new PlayerMatch { PlayerId = p.PlayerId })
                        .ToList()
                };

                matches.Add(match);
            }

            return matches;
        }
    }
}
