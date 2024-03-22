using BaddyMatchMaker.ExceptionHandling;
using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    /// <summary>
    /// Gets an even number of males and females to be able to form valid matches
    /// Valid match = men's doubles, women's doubles and mixed doubles
    /// If the number of male or female players is odd, one player within the cutoff limit will have to be swapped
    /// with another player outside the cutoff following the 'least disruption' criteria ie. one that causes the least disruption to the queue
    /// Eg. Consider the list of players MMMFMMMM|MMMF... where | is the cutoff line
    /// Swapping M (8th pos) with F (12th) would give disruption index = 4; whereas changing F (4th) to M (9th), disruption index = 5; 
    /// So swapping M => F would cause less disruption and would be performed by this algorithm
    /// </summary>
    public class LeastDisruptionSelectionStrategy : PlayerPoolSelectionStrategyBase, IPlayerPoolSelectionStrategy
    {
        public LeastDisruptionSelectionStrategy(RoundSettings roundSettings) : base(roundSettings)
        {
        }

        public IEnumerable<SessionPlayer> GetPlayerPool(IOrderedEnumerable<SessionPlayer> availablePlayers)
        {
            var playerPool = availablePlayers.Take(RequiredPlayersCount).ToList();
            var reserve = availablePlayers.Skip(RequiredPlayersCount).ToList();

            if (IsMultiple(playerPool.Count) && HasEvenMaleAndFemaleCount(playerPool))
            {
                return playerPool;
            }

            if (!reserve.Any())
            {
                int excess = 0;
                if (playerPool.Count % PlayersNeededPerMatch != 0)
                {
                    // if not multiple
                    excess = playerPool.Count % PlayersNeededPerMatch;
                }
                else
                {
                    // if multiple but not even number of male and female
                    excess = PlayersNeededPerMatch;
                }

                var adjustedPlayerPoolCount = playerPool.Count - excess;
                var adjustedPlayerPool = playerPool.Take(adjustedPlayerPoolCount).ToList();

                if (IsMultiple(adjustedPlayerPoolCount) && HasEvenMaleAndFemaleCount(adjustedPlayerPool))
                {
                    return adjustedPlayerPool;
                }

                if (!reserve.Any())
                {
                    throw new ValidationException("Expected reserve to be not empty.");
                }

                return GetPlayerPoolWithLeastDisruption(adjustedPlayerPool, playerPool.Skip(adjustedPlayerPoolCount).ToList());
            }

            return GetPlayerPoolWithLeastDisruption(playerPool, reserve);
        }

        private IEnumerable<SessionPlayer> GetPlayerPoolWithLeastDisruption(List<SessionPlayer> playerPool, List<SessionPlayer> reserve)
        {
            var requiredPlayersCount = playerPool.Count;
            var lastPlayer = playerPool.Last();

            // find the nearest opposite sex player from reserve
            var nearestReserveOppositeSexIndex = reserve.FindIndex(p => p.Player.Sex != lastPlayer.Player.Sex);
            var nearestReserveDistance = nearestReserveOppositeSexIndex + 1;

            if (nearestReserveOppositeSexIndex != -1 && nearestReserveDistance <= 2)
            {
                // nearestReserveDistance 2 or less is best case scenario, no longer need to compare
                playerPool[requiredPlayersCount - 1] = reserve[nearestReserveOppositeSexIndex];
                return playerPool;
            }

            // find the opposite sex player closest to the end of the pool
            var nearestPlayerPoolOppositeSexIndex = playerPool.FindLastIndex(p => p.Player.Sex != lastPlayer.Player.Sex);
            var nearestPlayerPoolDistance = requiredPlayersCount - (nearestPlayerPoolOppositeSexIndex + 1);

            if (nearestReserveOppositeSexIndex != -1 && nearestReserveDistance <= nearestPlayerPoolDistance)
            {
                playerPool[requiredPlayersCount - 1] = reserve[nearestReserveOppositeSexIndex];
                return playerPool;
            }
            else
            {
                playerPool[nearestPlayerPoolOppositeSexIndex] = reserve[0];
            }

            return playerPool;
        }
    }
}
