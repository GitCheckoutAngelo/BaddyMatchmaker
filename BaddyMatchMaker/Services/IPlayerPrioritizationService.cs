using BaddyMatchMaker.Models;
using System.Linq;

namespace BaddyMatchMaker.Services
{
    public interface IPlayerPrioritizationService
    {
        IOrderedEnumerable<SessionPlayer> GetAvailablePlayersForNextRound();
    }
}
