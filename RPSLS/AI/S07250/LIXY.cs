using System;

namespace RPSLS
{
    class LIXY : StudentAI
    {
        public LIXY()
        {
            Nickname = "Pro";
            CourseSection = Section.S07250;        
        }
        public Move a;
        public Move[] b = new Move[100];
        public int c = 0;
        public Move[] d = new Move[]
        {
            Move.Lizard,
            Move.Spock,
            Move.Scissors,
            Move.Paper,
            Move.Rock
        };
        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            b[c++] = opponentMove;

        }
        public bool CheckIfCircular()
        {
            if (b[0] != b[1])
            {
                return true;
            }
            else return false;
        }

        public override Move Play()
        {
            if (CheckIfCircular())
            {
                return b[c - 1];
            }
            for (int i = 0; i < d.Length; i++)
            {

                if (d[i] == a)
                {
                    if ((i - 1) < 0)
                    {
                        i = i + 5;
                    }
                    return d[(i - 1)];
                }               
            }
            return 0;
            if ((int)a < 4)
            {
                return d[(int)a];
            }

            else if ((int)a == 4)
            {
                return d[0];
            }
            else return d[(int)a + 1]; ;

        }

    }
}
