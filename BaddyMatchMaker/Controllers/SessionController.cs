using BaddyMatchMaker.Dto;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BaddyMatchMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionManagementService sessionManagementService;

        public SessionController(ISessionManagementService sessionManagementService)
        {
            this.sessionManagementService = sessionManagementService;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] SessionDto sessionDto)
        {
            if (sessionDto.ClubId <= 0 || sessionDto.VenueId <= 0)
            {
                return new BadRequestResult();
            }

            var session = sessionManagementService.CreateSession(sessionDto);
            return new OkObjectResult(SessionDto.FromModel(session));
        }

        [HttpPost("[action]")]
        public IActionResult SignInPlayer([FromBody] SessionPlayerDto sessionPlayerDto)
        {
            if (sessionPlayerDto.PlayerId <= 0 || sessionPlayerDto.SessionId <= 0)
            {
                return new BadRequestResult();
            }

            var sessionPlayer = sessionManagementService.SignInPlayer(sessionPlayerDto.PlayerId, sessionPlayerDto.SessionId);
            return new OkObjectResult(SessionPlayerDto.FromModel(sessionPlayer));
        }

        [HttpPost("[action]")]
        public IActionResult SignAllPlayersIn([FromBody] SessionDto sessionDto)
        {
            if (sessionDto.SessionId <= 0)
            {
                return new BadRequestResult();
            }

            sessionManagementService.SignAllPlayersIn(sessionDto.SessionId);
            return new OkResult();
        }
    }
}
