using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Dto
{
    public class ClubDto
    {
        public int ClubId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SessionDto> Sessions { get; set; }

        public static ClubDto FromModel(Club model)
        {
            if (model == null) return null;

            return new ClubDto()
            {
                ClubId = model.ClubId,
                Name = model.Name,
                Description = model.Description,
                //Sessions = model.Sessions?.Select(s => SessionDto.FromModel(s)).ToList(), 
            };
        }

        public Club ToModel()
        {
            return new Club()
            {
                ClubId = ClubId,
                Name = Name,
                Description = Description,
                Sessions = Sessions?.Select(s => s.ToModel()).ToList(),
            };
        }
    }
}