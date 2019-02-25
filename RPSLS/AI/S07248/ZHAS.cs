using System;
using System.Collections.Generic;

namespace RPSLS
{
    class ZHAS : StudentAI
    {
        private Move? a = null;
        List<Move> b = new List<Move>();

        public ZHAS()
        {
            Nickname = "Yahaha!";
            CourseSection = Section.S07248;
        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            if(b.Count < 2)
            {
                b.Add(a.Value);
            }
        }

        public override Move Play()
        {
            if(b.Count >= 2)
            {
                if (b[0] != b[1])
                {
                    return a.Value;
                }
                else
                {
                    switch (a.Value)
                    {
                        case Move.Rock:
                        case Move.Scissors:
                            return Move.Spock;
                        case Move.Paper:
                        case Move.Lizard:
                            return Move.Scissors;
                        case Move.Spock:
                        default:
                            return Move.Paper;
                    }
                }
            }
            else
            {
                switch (a)
                {
                    case Move.Rock:
                    case Move.Scissors:
                        return Move.Spock;
                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;
                    case Move.Spock:
                    default:
                        return Move.Paper;
                }
            }
        }
    }
}
