using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Questions
    {
        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        public Questions()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast("Rock Question " + i);
            }
        }

        public void AskQuestion(int place)
        {

            var typequestion = GetCategorie(1);
            Console.WriteLine("The category is " + typequestion);
            if (typequestion == TypeQuestion.Pop)
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (typequestion == TypeQuestion.Science)
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (typequestion == TypeQuestion.Sports)
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (typequestion == TypeQuestion.Rock)
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        public TypeQuestion GetCategorie(int place)
        {
            switch (place)
            {
                case 0:
                case 4:
                case 8:
                    return TypeQuestion.Pop;
                case 1:
                case 5:
                case 9:
                    return TypeQuestion.Science;
                case 2:
                case 6:
                case 10:
                    return TypeQuestion.Sports;
                default:
                    return TypeQuestion.Rock;

            }
        }
    }
}