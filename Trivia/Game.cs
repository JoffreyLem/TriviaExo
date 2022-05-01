using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        public readonly List<Players> Players;
        public readonly Questions Questions;



        public int CurrentPlayerIndex { get; set; }
        private Players CurrentPlayer => Players[CurrentPlayerIndex];

        public Game()
        {
            Players = new List<Players>();
            Questions = new Questions();
            CurrentPlayerIndex = 0;
        }

     

        public bool Add(string playerName)
        {
            Players players = new Players(playerName);
            Players.Add(players);
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + Players.Count);
            return true;
        }

        public bool IsPlayable()
        {
            return Players.Count >= 2;
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

                   CurrentPlayer.InPenaltyBox = false;
                   Console.WriteLine(CurrentPlayer + " is getting out of the penalty box");
                   CurrentPlayer.Place = playerPlace + roll;
                    CurrentPlayer.PrintLocation();
                    Questions.AskQuestion(playerPlace);
                }
                else
                {
                    Console.WriteLine(CurrentPlayer + " is not getting out of the penalty box");
           
                }
            }
            else
            {
                CurrentPlayer.Place = playerPlace + roll;
                CurrentPlayer.PrintLocation();
                Questions.AskQuestion(playerPlace);
            }
        }

     

        public bool WasCorrectlyAnswered()
        {
            if (CurrentPlayer.InPenaltyBox)
            {
                HandleNextPlayer();
                return true;
             
            }
            else
            {

                HandleGoodAnswer();
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
            CurrentPlayerIndex++;
            if (CurrentPlayerIndex == Players.Count) CurrentPlayerIndex = 0;
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
