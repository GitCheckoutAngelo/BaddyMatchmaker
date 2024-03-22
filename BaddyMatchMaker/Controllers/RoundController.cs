using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Dto.RequestDto;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BaddyMatchMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly ISessionManagementService sessionManagementService;

        public RoundController(ISessionManagementService sessionManagementService)
        {
            this.sessionManagementService = sessionManagementService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("API Running...");
        }

        [HttpPost("[action]")] // get availablecourts list
        public IActionResult GetNext([FromBody] NextRoundRequestDto nextRoundRequest)
        {
            return new OkObjectResult(sessionManagementService.CreateNewRound(nextRoundRequest));
        }

    }
}
