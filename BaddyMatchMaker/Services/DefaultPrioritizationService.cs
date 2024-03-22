using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using System.Linq;

namespace BaddyMatchMaker.Services
{
    public class DefaultPrioritizationService : IPlayerPrioritizationService
    {
        private readonly IUnitOfWork unitOfWork;

        public DefaultPrioritizationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IOrderedEnumerable<SessionPlayer> GetAvailablePlayersForNextRound()
        {
            var availablePlayers = unitOfWork.SessionPlayerRepository
                            .Get(p => p.Active, includeProperties: nameof(SessionPlayer.Player))
                            .OrderBy(p => p.Player.PlayerMatches.Count)
                            .OrderBy(p => p.SignInTime);

            return availablePlayers;
        }
    }
}
