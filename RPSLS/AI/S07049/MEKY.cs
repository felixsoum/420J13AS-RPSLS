using System;

namespace RPSLS
{
    class MEKY : StudentAI
    {
        //FIND A WAY TO DETECT WHICH AI IS PLAYING AND CALL THE COUNTER METHOD ??
        //
       int indexTheOfMove;
       Move Lastopponentmove;
        
       public Move[] CounterCircularOpponent = new Move[] {
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
             //return PlayAgainstAll();
        
        }

        public override void Observe(Move opponentMove)
        {
           Lastopponentmove = opponentMove;
            
        }

        //Method to play in tournament 
        public Move PlayAgainstAll()
        {
            if (Lastopponentmove == Move.Rock)
            {
                return Move.Paper;

            }

            else if (Lastopponentmove == Move.Paper)
            {
                return Move.Scissors;

            }

            else if (Lastopponentmove == Move.Scissors)
            {
                return Move.Rock;

            }

            else if (Lastopponentmove == Move.Lizard)
            {
                return Move.Scissors;
            }

            else if (Lastopponentmove == Move.Spock)
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
            if (Lastopponentmove == Move.Rock)
            {
                indexTheOfMove = 2;
                return CounterCircularOpponent[indexTheOfMove++];
               
            }

            else if (Lastopponentmove == Move.Paper)
            {
                indexTheOfMove = 1;
                return CounterCircularOpponent[indexTheOfMove++];

            }

            else if (Lastopponentmove == Move.Scissors)
            {
                indexTheOfMove = 0;

                return CounterCircularOpponent[indexTheOfMove++];

            }


            else if (Lastopponentmove == Move.Lizard)
            {
                indexTheOfMove = 3;
                return CounterCircularOpponent[indexTheOfMove++];
            }

            else if (Lastopponentmove == Move.Spock)
            {
                indexTheOfMove = 4;

                return CounterCircularOpponent[indexTheOfMove++];
                
            }

            else
            {
                return RandomMove();
            }
            
        }

       

    }
}
