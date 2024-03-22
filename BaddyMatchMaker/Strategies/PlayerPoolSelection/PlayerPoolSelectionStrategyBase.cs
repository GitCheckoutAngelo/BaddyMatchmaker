using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public abstract class PlayerPoolSelectionStrategyBase
    {
        private readonly RoundSettings roundSettings;

        public PlayerPoolSelectionStrategyBase(RoundSettings roundSettings)
        {
            this.roundSettings = roundSettings;
        }

        protected int PlayersNeededPerMatch => roundSettings.PlayersNeededPerMatch;

        protected int RequiredPlayersCount => roundSettings.RequiredPlayersCount;

        protected bool HasEvenMaleAndFemaleCount(IEnumerable<SessionPlayer> playerPool) => playerPool.Count(p => p.Player.Sex == PlayerSex.Male) % 2 == 0;

        protected bool IsMultiple(int count) => count % PlayersNeededPerMatch == 0;
    }
}
