using System;

namespace RPSLS
{
    class SUNC : StudentAI
    {
        int a=0;
        Move b;
        Move c;
        Move d=Move.Rock;
        public SUNC()
        {
            Nickname = "Chengyu Sun";
            CourseSection = Section.S07248;

        }

        public override Move Play()
        {

           
            if (b == Move.Rock  )
            {
                if(c==Move.Rock)
                {
                    d = Move.Spock;
                }
                if(c==Move.Paper)
                {
                    d = Move.Rock;
                    
                }
                
              
            }
             if (b == Move.Lizard)
            {
                if (c == Move.Lizard)
                {
                    d = Move.Rock;
                }
                if (c == Move.Rock)
                {
                    d = Move.Lizard;

                }
            }
             if (b == Move.Paper)
            {
                if (c == Move.Paper)
                {
                    d = Move.Lizard;
                }
                if (c == Move.Scissors)
                {
                    d = Move.Spock;

                }
            }
             if (b == Move.Scissors)
            {
                if (c == Move.Scissors)
                {
                    d = Move.Rock;
                }
                if (c == Move.Spock)
                {
                    d = Move.Scissors;

                }
            }
             if (b == Move.Spock)
            {
                if (c == Move.Spock)
                {
                    d = Move.Lizard;
                }
                if (c == Move.Lizard)
                {
                    d = Move.Spock;

                }
            }
           
            return d;



        }
        public override void Observe(Move opponentMove)
        {
            if (a>=1)
            {
                c = b;
            }
            b = opponentMove;
            a++;
           


        }
    }
}
