using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Dto.RequestDto;
using BaddyMatchMaker.ExceptionHandling;
using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using System;
using System.Linq;

namespace BaddyMatchMaker.Services
{
    public class SessionManagementService : ISessionManagementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMatchMakingService matchMakingService;

        public SessionManagementService(IUnitOfWork unitOfWork, IMatchMakingService matchMakingService)
        {
            this.unitOfWork = unitOfWork;
            this.matchMakingService = matchMakingService;
        }

        public Round CreateNewRound(NextRoundRequestDto nextRoundRequest)
        {
            var numberOfCourts = nextRoundRequest.AvailableCourts.Count;
            var session = unitOfWork.SessionRepository
                .Get(s => s.SessionId == nextRoundRequest.SessionId, includeProperties: nameof(Session.Venue))
                .FirstOrDefault();

            if (session == null)
            {
                throw new NotFoundException(nameof(Session), nextRoundRequest.SessionId);
            }
              
            if (session.Venue.NumberOfCourts < numberOfCourts)
            {
                throw new ValidationException("Requested number of courts exceeds venue's available courts.");
            }

            var settings = unitOfWork.SettingsRepository.GetById(session.ClubId);

            if (settings == null)
            {
                throw new NotFoundException(nameof(Setting), session.ClubId);
            }

            var nextRoundNumber = session.Rounds.Count + 1;

            var roundSettings = new RoundSettings(nextRoundNumber, settings, nextRoundRequest.AvailableCourts);
            var matches = matchMakingService.CreateMatches(roundSettings).ToList();

            var newRound = new Round(session, matches, numberOfCourts, nextRoundNumber);
            unitOfWork.RoundRepository.Insert(newRound);
            unitOfWork.Commit();

            return newRound;
        }

        public Session CreateSession(SessionDto sessionDto)
        {
            var session = unitOfWork.SessionRepository.GetById(sessionDto.SessionId);

            if (session != null)
            {
                throw new DuplicateKeyException(nameof(Session), sessionDto.SessionId);
            }

            session = sessionDto.ToModel();
            session.StartSession();

            unitOfWork.SessionRepository.Insert(session);
            unitOfWork.Commit();
            return session;
        }

        public void EndSession(int sessionId)
        {
            var session = unitOfWork.SessionRepository.GetById(sessionId);

            if (session == null)
            {
                throw new NotFoundException(nameof(Session), sessionId);
            }

            session.EndSession();
            unitOfWork.Commit();
        }

        public void SignAllPlayersIn(int sessionId)
        {
            var allPlayers = unitOfWork.PlayerRepository.Get();
            var session = unitOfWork.SessionRepository.GetById(sessionId);

            if (session == null)
            {
                throw new NotFoundException(nameof(Session), sessionId);
            }

            var signUpTimeDelay = 0;
            foreach (var player in allPlayers)
            {
                var sessionPlayer = new SessionPlayer(sessionId, player.PlayerId);
                sessionPlayer.SignIn(DateTime.Now.AddSeconds(signUpTimeDelay += 5).ToUniversalTime());
                session.SignInPlayer(sessionPlayer);
            }

            unitOfWork.Commit();
        }

        public SessionPlayer SignInPlayer(int playerId, int sessionId)
        {
            var sessionPlayer = unitOfWork.SessionPlayerRepository
                .Get(sp => sp.PlayerId == playerId && sp.SessionId == sessionId)
                .FirstOrDefault();

            if (sessionPlayer != null)
            {
                throw new ValidationException("Player already signed in.");
            }

            sessionPlayer = new SessionPlayer(sessionId, playerId);
            sessionPlayer.SignIn();

            var session = unitOfWork.SessionRepository.GetById(sessionPlayer.SessionId);

            if (session == null)
            {
                throw new NotFoundException(nameof(Session), sessionId);
            }

            if (!session.Active)
            {
                throw new ValidationException("Session is inactive.");
            }

            session.SignInPlayer(sessionPlayer);
            unitOfWork.Commit();
            return sessionPlayer;
        }

        public void SignOutPlayer(int playerId, int sessionId)
        {
            var sessionPlayer = unitOfWork.SessionPlayerRepository
                .Get(sp => sp.PlayerId == playerId && sp.SessionId == sessionId)
                .FirstOrDefault();

            if (sessionPlayer == null)
            {
                throw new ValidationException("Player not signed in.");
            }

            sessionPlayer.SignOut();
            unitOfWork.Commit();
        }

        public void SwapPlayers(int roundId, int player1Id, int player2Id)
        {
            Round round = unitOfWork.RoundRepository.GetById(roundId);

            if (round == null)
            {
                throw new NotFoundException(nameof(round), roundId);
            }

            round.SwapPlayers(player1Id, player2Id);
            unitOfWork.Commit();
        }
    }
}
