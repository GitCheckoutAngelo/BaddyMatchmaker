using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Dto
{
    public class SessionPlayerDto
    {
        public int SessionPlayerId { get; set; }

        public int SessionId { get; set; }

        public int PlayerId { get; set; }

        public DateTime SignInTime { get; set; }

        public bool Active { get; set; }

        public PlayerDto Player { get; set; }

        public SessionDto Session { get; set; }

        public static SessionPlayerDto FromModel(SessionPlayer model)
        {
            if (model == null) return null;

            return new SessionPlayerDto()
            {
                SessionPlayerId = model.SessionPlayerId,
                SessionId = model.SessionId,
                PlayerId = model.PlayerId,
                SignInTime = model.SignInTime,
                Active = model.Active,
                Player = PlayerDto.FromModel(model.Player),
                Session = SessionDto.FromModel(model.Session),
            };
        }

        public SessionPlayer ToModel()
        {
            return new SessionPlayer()
            {
                SessionPlayerId = SessionPlayerId,
                SessionId = SessionId,
                PlayerId = PlayerId,
                SignInTime = SignInTime,
                Active = Active,
                Player = Player?.ToModel(),
                Session = Session?.ToModel(),
            };
        }
    }
}