using System;
using System.Collections.Generic;

namespace RPSLS
{
    class TRAV : StudentAI
    {
        List<Move> a = new List<Move>();
        Move b;
        Move c;

        public TRAV()
        {
            Nickname = "ilikefornite";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            if(a.Count > 2)
            {
                if (a[0] == a[1])
                {
                    if (b == Move.Scissors)
                    {
                        c = Move.Rock;
                    }
                    if (b == Move.Rock)
                    {
                        c = Move.Spock;
                    }
                    if (b == Move.Spock)
                    {
                        c = Move.Paper;
                    }
                    if (b == Move.Paper)
                    {
                        c = Move.Scissors;
                    }
                    if (b == Move.Lizard)
                    {
                        c = Move.Scissors;
                    }
                }
                else
                {
                    c = b;
                }
            }
            return c;
        }

        public override void Observe(Move opponentMove)
        {
            this.b = opponentMove;
            a.Add(b);
        }
    }
}