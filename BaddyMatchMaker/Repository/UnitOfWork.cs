using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaddyMatchMakerContext dbContext;
        private IRepository<Session> sessionRepository;
        private IRepository<Round> roundRepository;
        private IRepository<Player> playerRepository;
        private IRepository<SessionPlayer> sessionPlayerRepository;
        private Repository<Club> clubRepository;
        private Repository<Match> matchRepository;
        private Repository<PlayerMatch> playerMatchRepository;
        private Repository<Setting> settingsRepository;

        public UnitOfWork(BaddyMatchMakerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<Club> ClubRepository => clubRepository ??= new Repository<Club>(dbContext);

        public IRepository<Session> SessionRepository => sessionRepository ??= new Repository<Session>(dbContext);

        public IRepository<Round> RoundRepository => roundRepository ??= new Repository<Round>(dbContext);

        public IRepository<Match> MatchRepository => matchRepository ??= new Repository<Match>(dbContext);

        public IRepository<PlayerMatch> PlayerMatchRepository => playerMatchRepository ??= new Repository<PlayerMatch>(dbContext);

        public IRepository<Player> PlayerRepository => playerRepository ??= new Repository<Player>(dbContext);

        public IRepository<SessionPlayer> SessionPlayerRepository => sessionPlayerRepository ??= new Repository<SessionPlayer>(dbContext);

        public IRepository<Setting> SettingsRepository => settingsRepository ??= new Repository<Setting>(dbContext);

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
