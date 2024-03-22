using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Strategies.PlayerPoolSelection;
using System;

namespace BaddyMatchMaker.Strategies.Factory
{
    public class PlayerPoolSelectionStrategyFactory : IPlayerPoolSelectionStrategyFactory
    {
        public IPlayerPoolSelectionStrategy Create(RoundSettings roundSettings)
        {
            if (roundSettings.IgnoreSex)
            {
                return new IndiscriminateSelectionStrategy(roundSettings);
            }
            else
            {
                return new SwapLastPlayerSelectionStrategy(roundSettings);
            }
        }
    }

    public interface IPlayerPoolSelectionStrategyFactory
    {
        IPlayerPoolSelectionStrategy Create(RoundSettings roundSettings);
    }
}
