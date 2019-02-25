using System;
using System.Collections.Generic;

namespace RPSLS
{
    class HASN : StudentAI
    {
        Move a;
        List<Move> b = new List<Move>();

        public HASN()
        {
            Nickname = "Ligma";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            if (b.Count > 1 && b[0] != b[1])
            {
                if (a == Move.Scissors)
                {
                    return Move.Scissors;
                }
                else if (a == Move.Paper)
                {
                    return Move.Paper;
                }
                else if (a == Move.Rock)
                {
                    return Move.Rock;
                }                
                else if (a == Move.Lizard)
                {
                    return Move.Lizard;
                }
                else
                {
                    return Move.Spock;
                }
            }
            else
            {
                if (a == Move.Rock || a == Move.Scissors)
                {
                    return Move.Spock;
                }
                else if (a == Move.Paper || a == Move.Lizard)
                {
                    return Move.Scissors;
                }
                else if (a == Move.Spock)
                {
                    return Move.Paper;
                }
                else
                {
                    return RandomMove();
                }
            }                
        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            b.Add(a);     
        }
    }
}
