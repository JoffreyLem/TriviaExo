using NUnit.Framework;
using Trivia;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {
        [SetUp]
        public void Initialize()
        {
            game = new Game();
        }

        private Game game;

        [Test]
        public void IsPlayableSuperior0Test()
        {
            game.Add("test");
            var playable = game.IsPlayable();
            Assert.Equals(playable, 1);
        }

        [Test]
        public void IsNotPlayableTest()
        {
            var playable = game.IsPlayable();
            Assert.Equals(playable, 0);
        }

        [Test]
        public void HowManyPlayersTest()
        {
            game.Add("test");
            Assert.Equals(game.HowManyPlayers(), 1);
        }
    }
}