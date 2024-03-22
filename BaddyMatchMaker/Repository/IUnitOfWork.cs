using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Club> ClubRepository { get; }

        IRepository<Session> SessionRepository { get; }

        IRepository<Round> RoundRepository { get; }

        IRepository<Match> MatchRepository { get; }

        IRepository<PlayerMatch> PlayerMatchRepository { get; }

        IRepository<Player> PlayerRepository { get; }

        IRepository<SessionPlayer> SessionPlayerRepository { get; }

        IRepository<Setting> SettingsRepository { get; }

        void Commit();
    }
}
