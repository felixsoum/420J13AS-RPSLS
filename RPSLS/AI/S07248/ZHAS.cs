using System;
using System.Collections.Generic;

namespace RPSLS
{
    class ZHAS : StudentAI
    {
        int[,] dataMarkovOne = new int[5, 5];
        int[,,] dataMarkovTwo = new int[5, 5, 5];
        Move? prev; //? is the Nullable operator
        Move? prevPrev;

        public ZHAS()
        {
            Nickname = "Yahaha!";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            if (prevPrev.HasValue && prev.HasValue)
            {
                Move bestMove = Move.Rock;
                int bestCount = -1;

                for (int i = 0; i < 5; i++)
                {
                    //MarkovOne
                    //int currentCount = dataMarkovOne[(int)prev, i];

                    //MarkovTwo
                    int currentCount = dataMarkovTwo[(int)prevPrev, (int)prev, i];

                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }
                }
                switch (bestMove)
                {
                    case Move.Rock:
                    default:
                        return Move.Paper;
                    case Move.Paper:
                        return Move.Scissors;
                    case Move.Scissors:
                        return Move.Spock;
                    case Move.Spock:
                        return Move.Lizard;
                    case Move.Lizard:
                        return Move.Rock;

                }
            }
            else
            {
                return RandomMove();
            }
        }

        public override void Observe(Move opponentMove)
        {
            if (prev.HasValue && prevPrev.HasValue)
            {
                //MarkovTwo
                dataMarkovTwo[(int)prevPrev, (int)prev, (int)opponentMove]++;

                //MarkovOne
                //dataMarkovOne[(int)prev, (int)opponentMove]++;
            }
            prevPrev = prev;
            prev = opponentMove;
        }
    }
}

