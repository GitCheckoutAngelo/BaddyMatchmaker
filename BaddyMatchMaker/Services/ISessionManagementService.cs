using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Dto.RequestDto;
using BaddyMatchMaker.Models;

namespace BaddyMatchMaker.Services
{
    public interface ISessionManagementService
    {
        Round CreateNewRound(NextRoundRequestDto nextRoundRequest);
        Session CreateSession(SessionDto sessionDto);
        void EndSession(int sessionId);
        void SwapPlayers(int roundId, int player1Id, int player2Id);
        SessionPlayer SignInPlayer(int playerId, int sessionId);
        void SignAllPlayersIn(int sessionId);
        void SignOutPlayer(int playerId, int sessionId);
    }
}