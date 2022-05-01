using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Players> _players = new List<Players>();

        private readonly Questions _questions = new Questions();



        private int _currentPlayer;
        private Players CurrentPlayer => _players[_currentPlayer];

        public Game()
        {
           
        }

        public bool IsPlayable()
        {
            return _players.Count >= 2;
        }

        public bool Add(string playerName)
        {
            Players players = new Players(playerName);
            _players.Add(players);
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }


        public void Roll(int roll)
        {
         
            var playerPlace = CurrentPlayer.Place;
            Console.WriteLine(CurrentPlayer + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer.InPenaltyBox)
            {
      
                if (roll % 2 != 0)
                {

                   CurrentPlayer.IsGettingOutOfPenaltyBox=true;
                   Console.WriteLine(CurrentPlayer + " is getting out of the penalty box");
                    playerPlace = playerPlace + roll;
                    CurrentPlayer.PrintLocation();
                    _questions.AskQuestion(playerPlace);
                }
                else
                {
                    Console.WriteLine(CurrentPlayer + " is not getting out of the penalty box");
                    CurrentPlayer.IsGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                CurrentPlayer.PrintLocation();
                _questions.AskQuestion(playerPlace);
            }
        }

     

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer.InPenaltyBox)
            {
                if (CurrentPlayer.IsGettingOutOfPenaltyBox)
                {

                    HandleGoodAnswer();

                    var winner = DidPlayerWin();
                    HandleNextPlayer();

                    return winner;
                }
                else
                {
                    HandleGoodAnswer();
                    HandleNextPlayer();
                    return true;
                }
            }
            else
            {
              

                var winner = DidPlayerWin();
                HandleNextPlayer();

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer + " was sent to the penalty box");
            CurrentPlayer.InPenaltyBox = true;
            HandleNextPlayer();
            return true;
        }

        public void HandleNextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        public void HandleGoodAnswer()
        {
            Console.WriteLine("Answer was corrent!!!!");
            CurrentPlayer.Purse++;
            Console.WriteLine(CurrentPlayer
                              + " now has "
                              + CurrentPlayer.Purse
                              + " Gold Coins.");
        }


        private bool DidPlayerWin()
        {
            return CurrentPlayer.Purse != 6;
        }
    }

}
