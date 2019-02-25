using System;
using System.Collections.Generic;

namespace RPSLS
{
    class TAVS : StudentAI
    {  
        
        public TAVS()
        {
            Nickname = "Origami";
            CourseSection = Section.S07248;
        }

        public List<Move> a = new List<Move>();
        public Move b;
        public override Move Play()
        {
            try
            {
                if (b != a[a.Count - 2])
                {
                    return b;
                }
                else
                {
                    switch (b)
                    {
                        case Move.Scissors:
                            return Move.Rock;
                        case Move.Lizard:
                            return Move.Scissors;
                        case Move.Paper:
                            return Move.Scissors;
                        case Move.Rock:
                            return Move.Paper;
                        case Move.Spock:
                            return Move.Paper;
                        default:
                            return Move.Paper;
                    }
                }
            }catch{ return Move.Paper; }
        }
        public override void Observe(Move opponentMove)
        {
            b = opponentMove;
            a.Add(b);
        }

    }
}
