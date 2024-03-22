using BaddyMatchMaker.Helpers;
using BaddyMatchMaker.Models;
using BaddyMatchMaker.Strategies.PlayerPoolSelection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BaddyMatchMakerTests.Strategies
{
    [TestClass]
    public class IndiscriminateSelectionStrategyTests
    {
        [TestMethod]
        public void GetPlayerPool_ReturnsRequiredPlayerCount()
        {
            var roundSetting = new RoundSettings(1, new Setting(), new[] { 1 }.ToList());
            var selection = new IndiscriminateSelectionStrategy(roundSetting);

            var playerPool = selection.GetPlayerPool(sessionPlayers.OrderBy(p => p.PlayerId));
            Assert.AreEqual(roundSetting.RequiredPlayersCount, playerPool.Count());
        }

        [TestMethod]
        public void GetPlayerPool_WhenAvailablePlayerCountLessThanRequired_Multiple_ReturnsAll()
        {
            var selection = new IndiscriminateSelectionStrategy(new RoundSettings(1, new Setting(), new[] { 1, 2 }.ToList()));
            var availableCount = 4;

            var playerPool = selection.GetPlayerPool(sessionPlayers.Take(availableCount).OrderBy(p => p.PlayerId));
            Assert.AreEqual(availableCount, playerPool.Count());
        }

        [TestMethod]
        public void GetPlayerPool_WhenAvailablePlayerCountLessThanRequired_NonMultiple_ReturnsAMultiple()
        {
            var selection = new IndiscriminateSelectionStrategy(new RoundSettings(1, new Setting(), new[] { 1, 2 }.ToList()));
            var availableCount = 6;

            var playerPool = selection.GetPlayerPool(sessionPlayers.Take(availableCount).OrderBy(p => p.PlayerId));
            Assert.AreEqual(4, playerPool.Count());
        }

        [TestMethod]
        public void GetPlayerPool_WhenAvailablePlayerCountLessThanLowestMultiple_ReturnsEmpty()
        {
            var selection = new IndiscriminateSelectionStrategy(new RoundSettings(1, new Setting(), new[] { 1, 2 }.ToList()));
            var availableCount = 3;

            var playerPool = selection.GetPlayerPool(sessionPlayers.Take(availableCount).OrderBy(p => p.PlayerId));
            Assert.AreEqual(0, playerPool.Count());
        }

        public static List<SessionPlayer> sessionPlayers => new List<SessionPlayer> {
            new SessionPlayer { PlayerId = 1 },
            new SessionPlayer { PlayerId = 2 },
            new SessionPlayer { PlayerId = 3 },
            new SessionPlayer { PlayerId = 4 },
            new SessionPlayer { PlayerId = 5 },
            new SessionPlayer { PlayerId = 6 },
            new SessionPlayer { PlayerId = 7 },
            new SessionPlayer { PlayerId = 8 },
            new SessionPlayer { PlayerId = 9 },
            new SessionPlayer { PlayerId = 10 },
        };
    }
}
