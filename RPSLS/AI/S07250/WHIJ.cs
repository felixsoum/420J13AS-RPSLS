using System;
namespace RPSLS
{
    class WHIJ : StudentAI
    {
        Move? oppLastMove = null;
        Move oppNextMove;
        Move myMove;

        Move mostPlayedMove = Move.Rock;
        Move secondMostPlayedMove = Move.Rock;

        int[] moveCount = new int[5];
        int mostPlayedCount = 0;

        //[0] = Rock,
        //[1] = Paper
        //[2] = Scissors
        //[3] = Spock
        //[4] = Lizard

        public WHIJ()
        {
            Nickname = "neverfirst";
            CourseSection = Section.S07250;
        }

        private int CheckWin()
        {
            switch (myMove.CompareWith(oppNextMove))
            {
                case 0:
                    //tieCount++;
                    return 0;
                case 1:
                    //winCount++;
                    return 1;
                case -1:
                    //loseCount++;
                    return -1;
                default:
                    return 1;
            }
        }

        public override Move Play()
        {
            if (oppLastMove.HasValue)
            {

                for (int i = 0; i < 5; i++)
                {
                    if (moveCount[i] > (mostPlayedCount)) //mostplayedmove? 
                    {
                        mostPlayedMove = (Move)i; //(Move)i;
                        
                        mostPlayedCount = moveCount[i];
                        
                    }
                    
                }
               // Console.WriteLine("MOst played : "+ mostPlayedMove);
                switch (mostPlayedMove)
                {
                    case Move.Rock:
                    case Move.Spock:
                        return Move.Paper;
                    case Move.Lizard:
                    case Move.Paper:
                        return Move.Scissors;
                    case Move.Scissors:
                        return Move.Rock;
                    default:
                        break;
                }
            }

            return Move.Paper;
        }

        public override void Observe(Move opponentMove)
        {
            if (oppLastMove.HasValue)
            {
                oppLastMove = opponentMove;
                moveCount[(int)oppLastMove]++;
            }
            else
            {
                oppLastMove = opponentMove;
            }


            // oppLastMove = oppNextMove;
            // oppNextMove = opponentMove;
            //int rand;
        }
    }
}
