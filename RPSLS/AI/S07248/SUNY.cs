
﻿using System;

namespace RPSLS
{
    class SUNY : StudentAI
    {
        Move a;
        int b = 0;
        int c = 0;
        int d = 0;
        int e = 0;
        int f = 0;
        public SUNY()
        {
            Nickname = "BaBa";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            if (a == Move.Paper)
            {
                b++;
                if (b >= 50)
                {
                    return Move.Scissors;
                }
                else
                {
                    return Move.Paper;
                }
                
               
            }
           else
            if (a == Move.Scissors)
            {
                d++;
                if (d >= 50)
                {
                    return Move.Rock;
                }
                else
                {
                    return Move.Scissors;
                }
            }
           else
            if (a == Move.Rock)
            {
                
                c++;
                if (c >= 50)
                {
                    return Move.Paper;
                }
                else
                {
                    return Move.Rock;
                }
            }
            else
            if (a == Move.Lizard)
            {
                e++;
                if (e >= 50)
                {
                    return Move.Rock;
                }
                else
                {
                    return Move.Lizard;
                }
            }
            else
            if (a == Move.Spock)
            {
                f++;
                if (f >= 50)
                {
                    return Move.Lizard;
                }
                else
                {
                    return Move.Spock;
                }
            }
            return RandomMove();
        }
     
        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            base.Observe(opponentMove);
            
        }
    }
}

﻿
