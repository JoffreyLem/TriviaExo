using System;

namespace Trivia
{
    public class Players
    {
        public Players(string name)
        {
            Name = name;
            Place = 0;
            Purse = 0;
            InPenaltyBox = false;
            IsGettingOutOfPenaltyBox=false;
        }

        public string Name { get; set; }

        private int _place;

        public int Place
        {
            get
            {
                return _place;
            }
            set
            {
                if (value > 11) value -= 12;
                _place = value;
            }
        }

        public int Purse { get; set; }

        public bool InPenaltyBox { get; set; }

        public bool IsGettingOutOfPenaltyBox { get; set; }

        public void PrintLocation()
        {

            Console.WriteLine(Name + "'s new location is " +        Place);
      
        }
        
    }
}