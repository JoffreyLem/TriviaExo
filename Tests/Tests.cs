using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Trivia;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {

        private Game game;


        [SetUp]
        public void Initialize()
        {
            game = new Game();
            game.Add("test");
            game.Add("test2");
            game.Add("test3");
        }

        [Test]
        public void IsPlayableSuperior0Test()
        {
          
            var playable = game.IsPlayable();
            playable.Should().Be(true);
   
        }

        [Test]
        public void IsNotPlayableTest()
        {
           var game2 = new Game();
            game2.Add("test");
 
            var playable = game2.IsPlayable();
            playable.Should().Be(false);
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void RollGetOutOfPenaltyBox(int roll)
        {
   
            
            var player = game.Players.First();

            player.InPenaltyBox = true;

            game.Roll(roll);

            player.InPenaltyBox.Should().Be(false);

        }

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        public void RollStayInPenaltyBox(int roll)
        {
        

            var player = game.Players.First();

            player.InPenaltyBox = true;

            game.Roll(roll);

            player.InPenaltyBox.Should().Be(true);

        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void PlayerPlaceMoveOutOfPenaltyBox(int roll)
        {
       

            var player = game.Players.First();

            player.InPenaltyBox = false;
            var currentPlace = player.Place;

            game.Roll(roll);

            player.Place.Should().Be(currentPlace+roll);
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void PlayerPlaceMoveGettingOutOfPenaltyBox(int roll)
        {
   

            var player = game.Players.First();

            player.InPenaltyBox = true;
            var currentPlace = player.Place;

            game.Roll(roll);

            player.Place.Should().Be(currentPlace + roll);
        }

        [Test]
        public void CorrrectAnswerIfInPenaltyBox()
        {
            var player = game.Players[0];
            player.InPenaltyBox = true;
            var playerActualPurse = player.Purse;
            var currentIndex = game.Players.IndexOf(player);
            game.WasCorrectlyAnswered();
            player.Purse.Should().Be(playerActualPurse);
            game.CurrentPlayerIndex.Should().Be(game.Players.IndexOf(game.Players[1]));

        }

        [Test]
        public void CorrrectAnswerIfInPenaltyBoxWithLastPlayers()
        {
            var player = game.Players[2];
            player.InPenaltyBox = true;
            var playerActualPurse = player.Purse;
            var currentIndex = game.Players.IndexOf(player);
            game.CurrentPlayerIndex = currentIndex;
            game.WasCorrectlyAnswered();
            player.Purse.Should().Be(playerActualPurse);
            game.CurrentPlayerIndex.Should().Be(game.Players.IndexOf(game.Players[0]));

        }

        [Test]
        public void InPenaltyBoxIfWrongAnswer()
        {
            var player = game.Players[0];
            player.InPenaltyBox = false;
            game.WrongAnswer();
            player.InPenaltyBox.Should().Be(true);
        }
    }
}