using System;
using System.Collections.Generic;

namespace RPSLS
{
    class HASN : StudentAI
    {
        int[] history = new int[5];

        public HASN()
        {
            Nickname = "Sugma";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            Move mostPlayedMove = Move.Rock;
            int mostPlayedCount = history[0];

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
                case Move.Rock:          
                        return Move.Spock;

                case Move.Spock:
                        return Move.Paper;
              
                case Move.Lizard:
                        return Move.Scissors;

                case Move.Paper:
                        return Move.Lizard;
    
                case Move.Scissors:
                        return Move.Rock;

            }

        }
        public override void Observe(Move opponentMove)
        {
            history[(int)opponentMove]++;
        }
    }
}
