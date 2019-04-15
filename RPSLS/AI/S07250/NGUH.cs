using System;
using System.Collections.Generic;

namespace RPSLS
{
    class NGUH : StudentAI
    {
        int[,,] data = new int[5, 5, 5];
        Move? prev = null;
        Move? prev1 = Move.Paper;

        public NGUH()
        {
            Nickname = "JayHng";
            CourseSection = Section.S07250;
        }

        public override void Observe(Move opponentMove)
        {
            if (prev.HasValue)
            {
                data[(int)prev, (int)prev1, (int)opponentMove]++;
            }
            prev = prev1;
            prev1 = opponentMove;
        }

        public override Move Play()
        {
            if (!prev.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move FavoriteMove = Move.Paper;
                int bestCount = -1;
                for (int i = 0 ; i < 5; i++)
                {
                    int currentCount = data[(int)prev, (int)prev1, i];
                    if (currentCount > bestCount)
                    {
                        FavoriteMove = (Move)i;
                        bestCount = currentCount;
                    }
                }
                switch (FavoriteMove)
                {
                    case Move.Rock:
                    case Move.Spock:
                        return Move.Paper;
                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;
                    case Move.Scissors:
                        return Move.Rock;
                    default:
                        return Move.Spock;
                }
            }
        }
    }
}