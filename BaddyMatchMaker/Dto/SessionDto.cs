using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Dto
{
    public class SessionDto
    {
        public int SessionId { get; set; }

        public int ClubId { get; set; }

        public int VenueId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool Active { get; set; }

        public ClubDto Club { get; set; }

        public VenueDto Venue { get; set; }

        public ICollection<RoundDto> Rounds { get; set; }

        public ICollection<SessionPlayerDto> SessionPlayers { get; set; }

        public static SessionDto FromModel(Session model)
        {
            if (model == null) return null;

            return new SessionDto()
            {
                SessionId = model.SessionId,
                ClubId = model.ClubId,
                VenueId = model.VenueId,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Active = model.Active,
                Club = ClubDto.FromModel(model.Club),
                Venue = VenueDto.FromModel(model.Venue),
                //Rounds = model.Rounds?.Select(r => RoundDto.FromModel(r)).ToList(), 
                //SessionPlayers = model.SessionPlayers?.Select(sp => SessionPlayerDto.FromModel(sp)).ToList(), 
            };
        }

        public Session ToModel()
        {
            return new Session()
            {
                SessionId = SessionId,
                ClubId = ClubId,
                VenueId = VenueId,
                StartTime = StartTime,
                EndTime = EndTime,
                Active = Active,
                Club = Club?.ToModel(),
                Venue = Venue?.ToModel(),
                //Rounds = Rounds?.Select(r => r.ToModel()).ToList(), 
                //SessionPlayers = SessionPlayers?.Select(sp => sp.ToModel()).ToList(), 
            };
        }
    }
}