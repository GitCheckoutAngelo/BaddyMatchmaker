using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Dto
{
    public class MatchDto
    {
        public int MatchId { get; set; }

        public int CourtNumber { get; set; }

        public int RoundId { get; set; }

        public RoundDto Round { get; set; }

        public ICollection<PlayerMatchDto> PlayerMatches { get; set; }

        public static MatchDto FromModel(Match model)
        {
            if (model == null) return null;

            return new MatchDto()
            {
                MatchId = model.MatchId,
                CourtNumber = model.CourtNumber,
                RoundId = model.RoundId,
                Round = RoundDto.FromModel(model.Round),
                PlayerMatches = model.PlayerMatches?.Select(pm => PlayerMatchDto.FromModel(pm)).ToList(),
            };
        }

        public Match ToModel()
        {
            return new Match()
            {
                MatchId = MatchId,
                CourtNumber = CourtNumber,
                RoundId = RoundId,
                Round = Round?.ToModel(),
                PlayerMatches = PlayerMatches?.Select(pm => pm.ToModel()).ToList(),
            };
        }
    }
}