using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public class IndiscriminateSelectionStrategy : PlayerPoolSelectionStrategyBase, IPlayerPoolSelectionStrategy
    { 
        public IndiscriminateSelectionStrategy(RoundSettings roundSettings) : base(roundSettings)
        {
        }

        public IEnumerable<SessionPlayer> GetPlayerPool(IOrderedEnumerable<SessionPlayer> availablePlayers)
        {
            var playerPool = availablePlayers.Take(RequiredPlayersCount).ToList();

            if (playerPool.Count < RequiredPlayersCount)
            {
                var excessPlayer = playerPool.Count % PlayersNeededPerMatch;
                if (excessPlayer == 0) 
                {
                    return playerPool;
                }

                return playerPool.Take(playerPool.Count - excessPlayer);
            }

            return playerPool;
        }
    }
}
