using System;
using System.Collections.Generic;
using System.Linq;


namespace RPSLS
{
    class KIMJ : StudentAI
    {
        private int[] history = new int[1000];

        private bool b = false;
        Move? a = null;
        private List<Move> compareMoves = new List<Move>();
        private List<Move> compareGeneric = new List<Move>();
        private bool _true0 = false;
        private bool _true1 = false;
        private bool _true2 = false;

        public KIMJ()
        {
            Nickname = "Shevala";
            CourseSection = Section.S07250;
        }

        public override void Observe(Move opponentMove)
        {
            history[(int)opponentMove]++;
            a = opponentMove;

            compareMoves.Add(opponentMove);

            if (!compareGeneric.Contains(opponentMove))
            {
                compareGeneric.Add(opponentMove);
                _true1 = true;
            }

        }

        public override Move Play()
        {

            Move mostPlayedMove = Move.Rock;
            int mostPlayedCount = history[0];
            Move secondMostPlayedMove = Move.Rock;



            for (int i = 1; i < 5; i++)
            {
                if (history[i] > mostPlayedCount)
                {
                    mostPlayedMove = (Move)i;
                    mostPlayedCount = history[i];

                }
            }

            switch (mostPlayedMove)
            {
                default:
                    return RandomMove();
                case Move.Rock:
                    if (secondMostPlayedMove == Move.Scissors)
                    {
                        return Move.Spock;
                    }
                    else
                    {
                        return Move.Paper;
                    }
                case Move.Scissors:
                    if (secondMostPlayedMove == Move.Lizard)
                    {
                        return Move.Rock;
                    }
                    else
                    {
                        return Move.Spock;
                    }
                case Move.Paper:
                    if (secondMostPlayedMove == Move.Spock)
                    {
                        return Move.Lizard;
                    }
                    else
                    {
                        return Move.Scissors;
                    }
                case Move.Lizard:
                    if (secondMostPlayedMove == Move.Paper)
                    {
                        return Move.Scissors;
                    }
                    else
                    {
                        return Move.Rock;
                    }
                case Move.Spock:
                    if (secondMostPlayedMove == Move.Rock)
                    {
                        return Move.Paper;
                    }
                    else
                    {
                        return Move.Paper;
                    }
            }



        }
    }
        }

    
