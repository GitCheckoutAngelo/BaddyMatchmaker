using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using System.Collections.Generic;

namespace BaddyMatchMaker.Services
{
    public interface IMatchMakingService
    {
        List<Match> CreateMatches(RoundSettings roundSettings);
    }
}