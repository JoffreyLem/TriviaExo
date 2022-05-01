using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Players> _players = new List<Players>();



        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private int _currentPlayer;
      

        private Players CurrentPlayer => _players[_currentPlayer];

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
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
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer.InPenaltyBox)
            {
      
                if (roll % 2 != 0)
                {

                   CurrentPlayer.IsGettingOutOfPenaltyBox=true;
               
                

                    Console.WriteLine(CurrentPlayer + " is getting out of the penalty box");
                    playerPlace = playerPlace + roll;
                    if (playerPlace > 11) playerPlace = playerPlace - 12;

                    Console.WriteLine(CurrentPlayer
                                      + "'s new location is "
                                      + playerPlace);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    CurrentPlayer.IsGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                playerPlace = playerPlace + roll;
                if (playerPlace > 11) playerPlace = playerPlace - 12;

                Console.WriteLine(_players[_currentPlayer]
                        + "'s new location is "
                        + playerPlace);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        private string CurrentCategory()
        {
            if (CurrentPlayer.Place == 0) return "Pop";
            if (CurrentPlayer.Place == 4) return "Pop";
            if (CurrentPlayer.Place == 8) return "Pop";
            if (CurrentPlayer.Place == 1) return "Science";
            if (CurrentPlayer.Place == 5) return "Science";
            if (CurrentPlayer.Place == 9) return "Science";
            if (CurrentPlayer.Place == 2) return "Sports";
            if (CurrentPlayer.Place == 6) return "Sports";
            if (CurrentPlayer.Place == 10) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer.InPenaltyBox)
            {
                if (CurrentPlayer.IsGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    CurrentPlayer.Purse++;
                    Console.WriteLine(CurrentPlayer
                                      + " now has "
                                      + CurrentPlayer.Purse
                                      + " Gold Coins.");

                    var winner = DidPlayerWin();
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;

                    return winner;
                }
                else
                {
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                CurrentPlayer.Purse++;
                Console.WriteLine(CurrentPlayer
                                  + " now has "
                                  + CurrentPlayer.Purse
                                  + " Gold Coins.");

                var winner = DidPlayerWin();
                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer + " was sent to the penalty box");
            CurrentPlayer.InPenaltyBox = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return CurrentPlayer.Purse != 6;
        }
    }

}
