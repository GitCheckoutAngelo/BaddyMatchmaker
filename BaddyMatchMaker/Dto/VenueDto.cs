using BaddyMatchMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMaker.Dto
{
    public class VenueDto
    {
        public int VenueId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int NumberOfCourts { get; set; }

        public ICollection<SessionDto> Sessions { get; set; }

        public static VenueDto FromModel(Venue model)
        {
            if (model == null) return null;

            return new VenueDto()
            {
                VenueId = model.VenueId,
                Name = model.Name,
                Address = model.Address,
                NumberOfCourts = model.NumberOfCourts,
                //Sessions = model.Sessions?.Select(s => SessionDto.FromModel(s)).ToList(), 
            };
        }

        public Venue ToModel()
        {
            return new Venue()
            {
                VenueId = VenueId,
                Name = Name,
                Address = Address,
                NumberOfCourts = NumberOfCourts,
                Sessions = Sessions?.Select(s => s.ToModel()).ToList(),
            };
        }
    }
}