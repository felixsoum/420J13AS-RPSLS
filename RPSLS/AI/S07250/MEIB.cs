using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{

    class MEIB : StudentAI
    {
        int[,,] table = new int[5, 5, 5];
        Move? prevMove = null;
        Move? prevMoveSecond = Move.Rock;


        public MEIB()
        {
            Nickname = "JusBieberFan";
            CourseSection = Section.S07250;

        }

        public override void Observe(Move opponentMove)
        {
            if (prevMove.HasValue)
            {
                table[(int)prevMove, (int)prevMoveSecond, (int)opponentMove]++;
            }
            prevMove = prevMoveSecond;
            prevMoveSecond = opponentMove;
        }

        public override Move Play()
        {

            if (!prevMove.HasValue)
            {
                return RandomMove();
            }
            else if(prevMove.HasValue)
            {
                Move bestMove = Move.Spock;
                Move bestMoveSecond = Move.Spock;
                int bestCount = -1;
                for (int i = 0; i < 5; i++)
                {
                    int currentCount = table[(int)prevMove, (int)prevMoveSecond, i];
                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                        bestMoveSecond = (Move)i;
                    }
                }

                
                switch (bestMove)
                {
                    case Move.Rock:
                    case Move.Scissors:
                        return Move.Spock;
                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;
                    case Move.Spock:
                        return Move.Lizard;
                    default:
                        return Move.Lizard;
                }

                
            }
            else
            {
                return RandomMove();
            }
           


        }

    }

}
