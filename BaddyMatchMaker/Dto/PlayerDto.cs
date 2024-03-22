using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Dto
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }

        public int ClubId { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Grade { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<PlayerMatchDto> PlayerMatches { get; set; }

        public ICollection<SessionPlayerDto> SessionPlayers { get; set; }

        public static PlayerDto FromModel(Player model)
        {
            if (model == null) return null;

            return new PlayerDto()
            {
                PlayerId = model.PlayerId,
                ClubId = model.ClubId,
                Name = model.Name,
                Sex = model.Sex,
                Grade = model.Grade,
                Phone = model.Phone,
                Email = model.Email,
                //PlayerMatches = model.PlayerMatches?.Select(pm => PlayerMatchDto.FromModel(pm)).ToList(), 
                //SessionPlayers = model.SessionPlayers?.Select(sp => SessionPlayerDto.FromModel(sp)).ToList(), 
            };
        }

        public Player ToModel()
        {
            return new Player()
            {
                PlayerId = PlayerId,
                ClubId = ClubId,
                Name = Name,
                Sex = Sex,
                Grade = Grade,
                Phone = Phone,
                Email = Email,
                PlayerMatches = PlayerMatches?.Select(pm => pm.ToModel()).ToList(),
                SessionPlayers = SessionPlayers?.Select(sp => sp.ToModel()).ToList(),
            };
        }
    }
}