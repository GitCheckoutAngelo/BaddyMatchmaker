using BaddyMatchMaker.ExceptionHandling;
using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    /// <summary>
    /// Gets an even number of males and females to be able to form valid matches
    /// Valid match = men's doubles, women's doubles and mixed doubles
    /// If the number of male or female players is odd, the last player in the playerpool will have to be swapped
    /// with the nearest opposite sex player in the reserve
    /// Eg. Consider the list of players MMMFMMMM|MMMF... where | is the cutoff line
    /// Applying algorithm will swap M (8th pos) with F (12th)
    /// </summary>
    public class SwapLastPlayerSelectionStrategy : PlayerPoolSelectionStrategyBase, IPlayerPoolSelectionStrategy
    {
        public SwapLastPlayerSelectionStrategy(RoundSettings roundSettings) : base(roundSettings)
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

            var lastPlayer = playerPool.Last();

            // find the nearest opposite sex player from reserve
            var nearestReserveOppositeSexIndex = reserve.FindIndex(p => p.Player.Sex != lastPlayer.Player.Sex);

            if (nearestReserveOppositeSexIndex < 0)
            {
                // not found
                throw new Exception("No player to swap with.");
            }

            // swap last player with player in found index
            playerPool[RequiredPlayersCount - 1] = reserve[nearestReserveOppositeSexIndex];

            return playerPool;
        }
    }
}
