using System;

namespace RPSLS
{
    class ZHAQ : StudentAI
    {
        int[,,] data = new int[5, 5, 5];
        Move? previousMove = null;
        Move? previousMove2 = null;


        public ZHAQ()
        {
            Nickname = "Sutton";
            CourseSection = Section.S07248;

        }

        public override void Observe(Move opponentMove)
        {
            if (previousMove.HasValue)
            {
                data[(int)previousMove,(int)previousMove2,(int)opponentMove]++;
            }
            previousMove = previousMove2;
            previousMove2 = opponentMove;
        }


        public override Move Play()
        {
            if (!previousMove.HasValue || !previousMove2.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move frequentMove = Move.Rock;
                int frequentMoveCount = -1;

                for (int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)previousMove,(int)previousMove2, i];
                    if(currentCount > frequentMoveCount)
                    {
                        frequentMove = (Move)i;
                        frequentMoveCount = currentCount;
                    }
                }

                switch (frequentMove)
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
                        return RandomMove();

                }

            }
        }


    }
}