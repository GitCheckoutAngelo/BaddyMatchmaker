using BaddyMatchMaker.ExceptionHandling;
using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Strategies.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Services
{
    /// <summary>
    /// Prioritizes available players based on certain criteria,
    /// Gets the player pool to create matches from, and
    /// Groups the players into matches according to skill level and other criteria
    /// </summary>
    public class MatchMakingService : IMatchMakingService
    {
        private readonly IPlayerPoolSelectionStrategyFactory playerPoolSelectionStrategyFactory;
        private readonly IMatchGroupingStrategyFactory matchGroupingStrategyFactory;  
        private readonly IPlayerPrioritizationService playerPrioritizationService;
        private readonly IShuffleService shuffleService;

        public MatchMakingService(
            IPlayerPoolSelectionStrategyFactory playerPoolSelectionStrategyFactory, 
            IMatchGroupingStrategyFactory matchGroupingStrategyFactory,
            IPlayerPrioritizationService playerPrioritizationService,
            IShuffleService shuffleService)
        {
            this.playerPoolSelectionStrategyFactory = playerPoolSelectionStrategyFactory;
            this.matchGroupingStrategyFactory = matchGroupingStrategyFactory;
            this.playerPrioritizationService = playerPrioritizationService;
            this.shuffleService = shuffleService;
        }

        public List<Match> CreateMatches(RoundSettings roundSettings)
        {
            // get all players ordered by prioritization
            var availablePlayers = playerPrioritizationService.GetAvailablePlayersForNextRound();

            // get player pool to create matches from
            var playerPoolSelectionStrategy = playerPoolSelectionStrategyFactory.Create(roundSettings);
            var playerPool = playerPoolSelectionStrategy.GetPlayerPool(availablePlayers).ToList();

            if (playerPool.Count < roundSettings.PlayersNeededPerMatch)
            {
                throw new ValidationException("Not enough players to create a match.");
            }

            // shuffle the player pool to mix up the players a bit
            shuffleService.Shuffle<SessionPlayer>(playerPool);

            // create court grouping and assignment
            var matchGroupingStrategy = matchGroupingStrategyFactory.Create(roundSettings);
            return matchGroupingStrategy.GroupPlayers(playerPool);
        }

    }

}
