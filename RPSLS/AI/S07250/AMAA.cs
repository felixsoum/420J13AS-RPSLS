using System;
using System.Collections.Generic;

namespace RPSLS
{
    class AMAA : StudentAI
    {
        public Move a;
        public List<Move> b = new List<Move>();
        int c = 0;

        public AMAA()
        {
            Nickname = "Aman";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            if (c > 2)
            {
                if (a != b[b.Count - 2])
                {
                    return a;
                }

                else
                {
                    return MyMove(a);
                }
            }

            else
            {
                c++;
                return Move.Spock;
            }

        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            b.Add(a);
        }

        private Move MyMove(Move enemyMove)
        {
            if (enemyMove == Move.Rock)
            {
                return Move.Spock;
            }
            else if (enemyMove == Move.Scissors)
            {
                return Move.Spock;
            }
            else if (enemyMove == Move.Lizard)
            {
                return Move.Scissors;
            }
            else if (enemyMove == Move.Paper)
            {
                return Move.Scissors;
            }
            else if (enemyMove == Move.Spock)
            {
                return Move.Paper;
            }

            return RandomMove();
        }

    }

}
