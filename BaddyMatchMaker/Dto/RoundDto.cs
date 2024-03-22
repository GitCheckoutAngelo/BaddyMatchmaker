using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Dto
{
    public class RoundDto
    {
        public int RoundId { get; set; }

        public int SessionId { get; set; }

        public int RoundNumber { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int CourtsAvailable { get; set; }


        public SessionDto Session { get; set; }

        public ICollection<MatchDto> Matches { get; set; }

        public static RoundDto FromModel(Round model)
        {
            if (model == null) return null;

            return new RoundDto()
            {
                RoundId = model.RoundId,
                SessionId = model.SessionId,
                RoundNumber = model.RoundNumber,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                CourtsAvailable = model.CourtsAvailable,
                Session = SessionDto.FromModel(model.Session),
                Matches = model.Matches?.Select(m => MatchDto.FromModel(m)).ToList(),
            };
        }

        public Round ToModel()
        {
            return new Round()
            {
                RoundId = RoundId,
                SessionId = SessionId,
                RoundNumber = RoundNumber,
                StartTime = StartTime,
                EndTime = EndTime,
                CourtsAvailable = CourtsAvailable,
                Session = Session?.ToModel(),
                //Matches = Matches?.Select(m => m.ToModel()).ToList(),
            };
        }
    }
}