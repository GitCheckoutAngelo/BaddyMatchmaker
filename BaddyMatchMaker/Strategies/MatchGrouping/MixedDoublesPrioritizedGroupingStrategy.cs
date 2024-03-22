using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Strategies.MatchGrouping
{
    /// <summary>
    /// Form mixed double matches first then use the remaining players to form regular doubles matches
    /// </summary>
    public class MixedDoublesPrioritizedGroupingStrategy : IMatchGroupingStrategy
    {
        public List<Match> GroupPlayers(ICollection<SessionPlayer> playerPool)
        {
            throw new NotImplementedException();
        }
    }
}
