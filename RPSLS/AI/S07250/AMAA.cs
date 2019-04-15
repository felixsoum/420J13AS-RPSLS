using System;
using System.Collections.Generic;

namespace RPSLS
{
    class AMAA : StudentAI
    {
        int[,] data = new int[5, 5];
        int[,,] dataCh2 = new int[5, 5, 5];
        Move? prev = null;

        public AMAA()
        {
            Nickname = "Aman";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            if (!prev.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move bestMove = Move.Rock;
                int bestCount = -1;
                for(int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)prev, i];
                    if(currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }
                }
                if(bestMove == Move.Rock)
                {
                    return Move.Spock;
                }
                else if(bestMove == Move.Scissors)
                {
                    return Move.Spock;
                }
                else if(bestMove == Move.Lizard)
                {
                    return Move.Scissors;
                }
                else if(bestMove == Move.Paper)
                {
                    return Move.Scissors;
                }
                else if(bestMove == Move.Spock)
                {
                    return Move.Paper;
                }
                return RandomMove();
            }
          

        }

        public override void Observe(Move opponentMove)
        {
           if(prev.HasValue)
            {
                data[(int)prev, (int)opponentMove]++;
            }
            prev = opponentMove;
        }

    }

}
