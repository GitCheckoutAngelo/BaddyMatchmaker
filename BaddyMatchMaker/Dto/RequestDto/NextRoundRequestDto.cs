using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.Dto.RequestDto
{
    public class NextRoundRequestDto
    {
        public int SessionId { get; set; }

        public List<int> AvailableCourts { get; set; }
    }
}
