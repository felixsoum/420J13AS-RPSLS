using System;

namespace RPSLS
{
    class RUAX : StudentAI
    {
        private readonly Move[] a;
        private int b = 0;

        public RUAX()
        {
            CourseSection = Section.S07250;
            Nickname = "Ruan Xun";
            a = new Move[100];
        }


        public override void Observe(Move opponentMove)
        {
            a[b++] = opponentMove;
        }

        public override Move Play()
        {
            if (b < 1)
            {
                return (Move)Game.SeededRandom.Next(0, 5);
            }
            else if (b < 2)
            {
                return CounterMove(circularMoves[(int)(a[b - 1] + 1) % 5]);
            }
            else
            {
                return AnalyseEnemy();
            }


        }

        private Move AnalyseEnemy()
        {
            if (CheckIsOneTrickPlayer())
            {
                return CounterMove(a[b - 1]);

            }

            else if (CheckIsCircularPlayer())
            {
                Move lastEnemyMove = a[b - 1];
                Move nextMove = Move.Paper;
                ;
                for (int i = 0; i < circularMoves.Length; i++)
                {
                    if (lastEnemyMove == circularMoves[i])
                    {
                        nextMove = (Move)circularMoves[(i + 1) % 5];
                        break;
                    }
                }

                return CounterMove(nextMove);

            }
            else
            {
                return (Move)Game.SeededRandom.Next(5);
            }

        }

        private bool CheckIsCircularPlayer()
        {
            return a[0] != a[1];
        }

        private Move CounterMove(Move move)
        {
            switch (move)
            {
                case Move.Paper:
                case Move.Lizard:
                    return Move.Scissors;
                case Move.Scissors:
                    return Move.Rock;
                default:
                    return Move.Paper;
            }
        }

        private readonly Move[] circularMoves = new Move[]
        {
            Move.Scissors,
            Move.Paper,
            Move.Rock,
            Move.Lizard,
            Move.Spock
        };

        private bool CheckIsOneTrickPlayer()
        {
            return a[0] == a[1];
        }
    }
}
