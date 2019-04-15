using System;
using System.Collections.Generic;

namespace RPSLS
{
    class SINS : StudentAI
    {
        public SINS()
        {
            Nickname = "mango boy";
            CourseSection = Section.S07248;


        }

        int[,] data = new int[5, 5];
        int[,,] dataCh2 = new int[5, 5, 5];
        Move? prev = null;
        
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
                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }
                }
            }

            

            return Move.Spock;
        }
        public override void Observe(Move opponentMove)
        {
            if (prev.HasValue)
            {
                data[(int)prev, (int)opponentMove]++;
            }
            prev = opponentMove;
            
        }
    }
}
