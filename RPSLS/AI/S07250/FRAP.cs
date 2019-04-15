using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class FRAP : StudentAI
    {
        private int[,,] data = new int[5, 5, 5];

        private Move? opponentLastMove = null;
        private Move? opponentTwoMovesAgo = null;
        private Move? opponentThreeMovesAgo = null;

        public FRAP()
        {
            Nickname = "Dummy AI";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            Move opponentNextMove = RandomMove();

            if (opponentLastMove != null && opponentTwoMovesAgo != null)
            {
                int bestCount = -1;

                for (int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)opponentTwoMovesAgo, (int)opponentLastMove, i];

                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        opponentNextMove = (Move)i;
                    }
                }
            }

            int rand = Game.SeededRandom.Next(2);


            switch (opponentNextMove)
            {
                case Move.Rock:
                    if (rand == 0)
                    {
                        return Move.Paper;
                    }
                    else
                    {
                        return Move.Spock;
                    }
                case Move.Paper:
                    if (rand == 0)
                    {
                        return Move.Scissors;
                    }
                    else
                    {
                        return Move.Lizard;
                    }
                case Move.Scissors:
                    if (rand == 0)
                    {
                        return Move.Spock;
                    }
                    else
                    {
                        return Move.Rock;
                    }
                case Move.Spock:
                    if (rand == 0)
                    {
                        return Move.Lizard;
                    }
                    else
                    {
                        return Move.Paper;
                    }
                case Move.Lizard:
                    if (rand == 0)
                    {
                        return Move.Rock;
                    }
                    else
                    {
                        return Move.Scissors;
                    }
                default:
                    return RandomMove();
            }

        }

        public override void Observe(Move opponentMove)
        {
            if (opponentTwoMovesAgo != null)
            {
                opponentThreeMovesAgo = opponentTwoMovesAgo;
            }

            if (opponentLastMove != null)
            {
                opponentTwoMovesAgo = opponentLastMove;
            }

            opponentLastMove = opponentMove;

            if (opponentLastMove != null && opponentTwoMovesAgo != null && opponentThreeMovesAgo != null)
            {
                data[(int)opponentThreeMovesAgo, (int)opponentTwoMovesAgo, (int)opponentLastMove]++;
            }
        }
    }
}



   