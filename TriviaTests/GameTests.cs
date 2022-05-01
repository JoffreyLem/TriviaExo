using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Tests
{
    [TestClass()]
    public class GameTests
    {

        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        [TestMethod()]
        public void IsPlayableSuperior0Test()
        {
            game.Add("test");
            var playable = game.IsPlayable();
            Assert.Equals(playable, 1);
        }

        [TestMethod()]
        public void IsNotPlayableTest()
        {

            var playable = game.IsPlayable();
            Assert.Equals(playable, 0);
        }

        [TestMethod()]
        public void HowManyPlayersTest()
        {
            game.Add("test");
            var playable = game.IsPlayable();
            Assert.Equals(playable, 1);
        }
    }
}