using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Dto
{
    public class PlayerMatchDto
    {
        public int PlayerMatchId { get; set; }

        public int MatchId { get; set; }

        public int PlayerId { get; set; }

        public MatchDto Match { get; set; }

        public PlayerDto Player { get; set; }

        public static PlayerMatchDto FromModel(PlayerMatch model)
        {
            if (model == null) return null;

            return new PlayerMatchDto()
            {
                PlayerMatchId = model.PlayerMatchId,
                MatchId = model.MatchId,
                PlayerId = model.PlayerId,
                Match = MatchDto.FromModel(model.Match),
                Player = PlayerDto.FromModel(model.Player),
            };
        }

        public PlayerMatch ToModel()
        {
            return new PlayerMatch()
            {
                PlayerMatchId = PlayerMatchId,
                MatchId = MatchId,
                PlayerId = PlayerId,
                Match = Match?.ToModel(),
                Player = Player?.ToModel(),
            };
        }
    }
}