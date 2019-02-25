using System;

namespace RPSLS
{
    class MEKY : StudentAI
    {
       int a;
       Move b;
        
       public Move[] c = new Move[] {
            Move.Scissors,
            Move.Paper,
            Move.Rock,
            Move.Lizard,
            Move.Spock
        };

       
      
        public MEKY()
        {
            Nickname = "Saitama";
            CourseSection = Section.S07049;
        }

        public override Move Play()
        {
              return AgainstCircularAI();
        }

        public override void Observe(Move opponentMove)
        {
           b = opponentMove;
            
        }

        public Move PlayAgainstAll()
        {
            if (b == Move.Rock)
            {
                return Move.Paper;

            }

            else if (b == Move.Paper)
            {
                return Move.Scissors;

            }

            else if (b == Move.Scissors)
            {
                return Move.Rock;

            }

            else if (b == Move.Lizard)
            {
                return Move.Scissors;
            }

            else if (b == Move.Spock)
            {
                return Move.Paper;
            }

            else
            {
                return RandomMove();
            }

        }
        public Move AgainstCircularAI()
        {
            if (b == Move.Rock)
            {
                a = 2;
                return c[a++];
               
            }

            else if (b == Move.Paper)
            {
                a = 1;
                return c[a++];

            }

            else if (b == Move.Scissors)
            {
                a = 0;

                return c[a++];

            }


            else if (b == Move.Lizard)
            {
                a = 3;
                return c[a++];
            }

            else if (b == Move.Spock)
            {
                a = 4;

                return c[a++];
                
            }

            else
            {
                return RandomMove();
            }
            
        }

       

    }
}
