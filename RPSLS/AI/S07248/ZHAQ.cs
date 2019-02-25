using System;

namespace RPSLS
{
    class ZHAQ : StudentAI
    {
        private Move a;
        private Move b;
        private Move[] c = { Move.Scissors, Move.Paper, Move.Rock, Move.Lizard, Move.Spock };
        private int d;

        public ZHAQ()
        {
            Nickname = "Sutton";
            CourseSection = Section.S07248;

        }

        public override Move Play()
        {
            return a;
        }

        public override void Observe(Move opponentMove)
        {
            
            if ( b == opponentMove)
            {
                
              if (opponentMove == Move.Rock)
                {
                    a = Move.Paper;
                }
                else if (opponentMove == Move.Scissors)
                {
                    a = Move.Rock;
                }
                else if (opponentMove == Move.Spock)
                {
                    a = Move.Lizard;
                }
                else if (opponentMove == Move.Lizard)
                {
                    a = Move.Rock;
                }
                else if (opponentMove == Move.Paper)
                {
                    a = Move.Scissors;
                }

                
            }
            else
            {  
                   for (int i = 0; i <c.Length; i++)
                  {
                    if(c[i] == opponentMove)
                    {
                        d = i;
                    }
                  }

                  d++;
                  a = c[d-1];

            }
            b = opponentMove;
        }
    }
}
