using System;
using System.Collections.Generic;


namespace RPSLS
{
    class ZHAB : StudentAI
    {
        private Move a;
        private List<Move> b = new List<Move>();
        private int c = 0;

        public ZHAB()
        {
            Nickname = "BBB";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            for (int i = 0; i < b.Count - 1; i++)
            {
                if (b[i] != b[i + 1])
                {
                    c++;
                }
                else
                {
                    c--;
                    if (c < 0)
                    {
                        c = 0;
                    }
                }
            }
            if (c > 2)
            {
                return AntiCircularAI();
            }
            else
                return AntiPreviousMoveAI();
        }
        public override void Observe(Move oppo)
        {
            a = oppo;
            b.Add(oppo);
        }

        public Move AntiPreviousMoveAI()
        {
            if (a == Move.Lizard)
            {
                return Move.Rock;
            }
            if (a == Move.Spock)
            {
                return Move.Lizard;
            }
            if (a == Move.Scissors)
            {
                return Move.Spock;
            }
            if (a == Move.Paper)
            {
                return Move.Scissors;
            }
            if (a == Move.Rock)
            {
                return Move.Paper;
            }
            else
                return Move.Spock;
        }

        public Move AntiCircularAI()
        {
            return a;
        }
    }
}
