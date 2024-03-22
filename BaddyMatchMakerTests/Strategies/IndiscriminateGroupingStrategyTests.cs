using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Strategies.MatchGrouping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static BaddyMatchMaker.Helpers.Constants;

namespace BaddyMatchMakerTests.Strategies
{
    [TestClass]
    public class IndiscriminateGroupingStrategyTests
    {
        [TestMethod]
        public void GroupPlayers_CreatesNewMatches() {
            var sessionPlayers = new List<SessionPlayer> {
                new SessionPlayer { PlayerId = 1, Player = new Player { Sex = PlayerSex.Male, Grade = 2 } },
                new SessionPlayer { PlayerId = 2, Player = new Player { Sex = PlayerSex.Male, Grade = 4 } },
                new SessionPlayer { PlayerId = 3, Player = new Player { Sex = PlayerSex.Female, Grade = 3 } },
                new SessionPlayer { PlayerId = 4, Player = new Player { Sex = PlayerSex.Male, Grade = 2 } },
                new SessionPlayer { PlayerId = 5, Player = new Player { Sex = PlayerSex.Male, Grade = 4 } },
                new SessionPlayer { PlayerId = 6, Player = new Player { Sex = PlayerSex.Male, Grade = 2 } },
                new SessionPlayer { PlayerId = 7, Player = new Player { Sex = PlayerSex.Male, Grade = 5 } },
                new SessionPlayer { PlayerId = 8, Player = new Player { Sex = PlayerSex.Female, Grade = 5 } },
            };

            var match1 = new int[] { 1, 4, 6, 3 };

            var availCourts = new[] { 1, 2 }.ToList();
            var roundSetting = new RoundSettings(1, new Setting(), availCourts);
            var grouping = new IndiscriminateGroupingStrategy(roundSetting);

            var matches = grouping.GroupPlayers(sessionPlayers);
            Assert.IsNotNull(matches);
            Assert.AreEqual(2, matches.Count());
            Assert.IsTrue(matches.First().PlayerMatches.All(p => match1.Contains(p.PlayerId)));

        }
    }
}
