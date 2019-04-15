using System;

namespace RPSLS
{
    class GUXH : StudentAI
    {
        //private Move a;
        //private Move b;
        //private int c;

        private Move[] d =
        {
            Move.Scissors,
            Move.Spock,
            Move.Rock,
            Move.Lizard,
            Move.Paper
        };

        Move? Hanzo = null;
        Move? Genji = Move.Rock;
        int[,,] history = new int[5,5,5];

        public GUXH()
        {
            Nickname = "Harry spinach";
            CourseSection = Section.S07248;
        }


        public override void Observe(Move opponentMove)
        {           

            if (Hanzo.HasValue)
            {
                history[(int)Hanzo, (int)Genji, (int)opponentMove]++;
                
            }

            Hanzo = Genji;
            Genji = opponentMove;
           
        }


        public override Move Play()
        {
            if (!Hanzo.HasValue)
            {
                return RandomMove();
            }

            else
            {
                Move bestMove = Move.Rock;         
                int bestCount = -1;
                for(int i = 0; i < 5; i++)
                {
                    int currentCount = history[(int)Hanzo, (int)Genji, i];                   
                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }
                   
                }

                switch (bestMove)
                {
                    default:
                    case Move.Rock:
                    case Move.Scissors:
                        return Move.Spock;

                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;

                    case Move.Spock:
                        return Move.Lizard;

                        //default:
                        //case Move.Rock:
                        //    if (secondMove == Move.Spock)
                        //    {
                        //        return Move.Paper;
                        //    }
                        //    if (secondMove == Move.Scissors)
                        //    {
                        //        return Move.Spock;
                        //    }
                        //    else return Move.Paper;

                        //case Move.Paper:
                        //    if (secondMove == Move.Lizard)
                        //    {
                        //        return Move.Scissors;
                        //    }
                        //    if (secondMove == Move.Spock)
                        //    {
                        //        return Move.Lizard;
                        //    }
                        //    else return Move.Scissors;

                        //case Move.Scissors:
                        //    if (secondMove == Move.Rock)
                        //    {
                        //        return Move.Spock;
                        //    }
                        //    if (secondMove == Move.Lizard)
                        //    {
                        //        return Move.Rock;
                        //    }
                        //    else return Move.Spock;


                        //case Move.Spock:
                        //    if (secondMove == Move.Paper)
                        //    {
                        //        return Move.Lizard;
                        //    }
                        //    if (secondMove == Move.Rock)
                        //    {
                        //        return Move.Paper;
                        //    }
                        //    else return Move.Lizard;

                        //case Move.Lizard:
                        //    if (secondMove == Move.Scissors)
                        //    {
                        //        return Move.Rock;
                        //    }
                        //    if (secondMove == Move.Paper)
                        //    {
                        //        return Move.Scissors;
                        //    }
                        //    else return Move.Rock;

                }
            }
           
        }

       
        
    }
}
