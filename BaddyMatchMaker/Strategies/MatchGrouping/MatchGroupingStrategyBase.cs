using BaddyMatchMaker.Helpers;
using System.Collections.Generic;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    public abstract class MatchGroupingStrategyBase
    {
        private readonly RoundSettings roundSettings;

        public MatchGroupingStrategyBase(RoundSettings roundSettings)
        {
            this.roundSettings = roundSettings;
        }

        protected int PlayersNeededPerMatch => roundSettings.PlayersNeededPerMatch;

        protected IReadOnlyCollection<int> AvailableCourts => roundSettings.AvailableCourts;
    }
}
