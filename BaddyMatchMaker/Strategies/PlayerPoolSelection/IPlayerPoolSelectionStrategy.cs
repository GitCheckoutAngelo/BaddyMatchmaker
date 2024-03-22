using BaddyMatchMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Strategies.PlayerPoolSelection
{
    public interface IPlayerPoolSelectionStrategy
    {
        IEnumerable<SessionPlayer> GetPlayerPool(IOrderedEnumerable<SessionPlayer> availablePlayers);
    }
}
