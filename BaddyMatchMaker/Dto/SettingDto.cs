using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Dto
{
    public class SettingDto
    {
        public int ClubId { get; set; }

        public int MatchDuration { get; set; }

        public bool IgnoreSex { get; set; }

        public bool SinglesMode { get; set; }

        public bool PrioritizeMixed { get; set; }

        public static SettingDto FromModel(Setting model)
        {
            if (model == null)
            {
                return null;
            }

            return new SettingDto()
            {
                ClubId = model.ClubId,
                MatchDuration = model.MatchDuration, 
                IgnoreSex = model.IgnoreSex,
                SinglesMode = model.SinglesMode,
                PrioritizeMixed = model.PrioritizeMixed
            }; 
        }

        public Setting ToModel()
        {
            return new Setting()
            {
                ClubId = ClubId,
                MatchDuration = MatchDuration, 
                IgnoreSex = IgnoreSex,
                SinglesMode = SinglesMode,
                PrioritizeMixed = PrioritizeMixed
            }; 
        }
    }
}