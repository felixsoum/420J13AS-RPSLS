using System;
using System.Collections.Generic;

namespace RPSLS
{
       
    class NOLR : StudentAI
    {
        List<Move> a = new List<Move>(); 
        Move b;
        Move c;
        int d = 0;
        public NOLR()
        {
            Nickname = "MultiFingers";
            CourseSection = Section.S07049;
        }
        public override Move Play()
        {
            if (d < 2)
            {
                c = Move.Paper;
            }
            else if(d >= 2 && a[0] == a[1])
            {
                c = (Move)((int)b + 1%5);
            }
            else
            {
                c = b;
            }

            return c;
        }

        public override void Observe(Move opponentMove)
        {
            b = opponentMove;
            a.Add(b);
            d++;
        }
        
    }
    
}
