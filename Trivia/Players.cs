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

        public int Place { get; set; }

        public int Purse { get; set; }

        public bool InPenaltyBox { get; set; }

        public bool IsGettingOutOfPenaltyBox { get; set; }
        
    }
}