using System;

namespace RPSLS
{
    class GUXH : StudentAI
    {
        private  Move a;
        private Move b;     
        private int c;
        private Move[] d = 
        {
            Move.Scissors,
            Move.Spock,
            Move.Rock,
            Move.Lizard,
            Move.Paper
        };

        public GUXH()
        {
            Nickname = "Harry spinach";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return a;
        }

        public override void Observe(Move opponentMove)
        {
            if (b is Move.Paper)
            {
                a = Move.Scissors;
            }
            else if (b is Move.Rock)
            {
                a = Move.Paper;
            }
            else if (b is Move.Scissors)
            {
                a = Move.Rock;
            }
            else if (b is Move.Spock)
            {
                a = Move.Rock;
            }
            else if (b is Move.Lizard)
            {
                a = Move.Scissors;
            }

            else
            {
                int i = 0;
                while (i < d.Length)
                {
                    if (d[i] == b)
                    {
                        c++;
                    }
                    i++;

                }
                c++;
                a = d[c - 1];
            }

            b = opponentMove;
            
        }
    }
}
