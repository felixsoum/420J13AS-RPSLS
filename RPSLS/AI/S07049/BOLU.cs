using System;
using System.Collections.Generic;
using System.IO;
namespace RPSLS
{
    class BOLU : StudentAI
    {

        public BOLU()
        {
            Nickname = "The World ends with Mittens";
            CourseSection = Section.S07049;

        }
        private bool a = false;
        private LinkedList<Move> b = new LinkedList<Move>();
        private int c = 3;
        public override void Observe(Move opponentMove)
        {
            
            if (b.Count == c)
            {
                b.RemoveFirst();
            }
            if ((int)opponentMove < 0)
            {
                Console.WriteLine("Warning! My opponent is a scrub who sends me negative numbers to crash my AI. Meow!");
                b.AddLast(Move.Lizard);
                return;

            }
            b.AddLast(opponentMove);
        }
        public override Move Play()
        {
            if (!a)
            {
                if (b.Count == 0)
                {
                    return Move.Paper;

                }
                if (b.Count == 1)
                {
                   
                    Move x = (Move)(((int)b.First.Value + 1) % 5);
                    
                    return x;
                }
                if (b.Count == 2)
                {
                    Move x = b.First.Value;
                    Move y = b.Last.Value;
                    
                       
                
                    if (x - y == 1 || (x == Move.Rock && y == Move.Lizard))
                    {
                        return y;
                    }
                    if (x - y == -1 || (y == Move.Rock && x == Move.Lizard))
                    {
                        return x;
                    }
                    if (x == y)
                    {

                        if ((int)x == 0)
                        {
                            return Move.Paper;

                        }
                        Move value = (Move)(((int)x + 1)%5);
                        
                        return value;
                    }
                }
                if (b.Count == 3)
                {
                    Move x = b.First.Value;
                    Move y = b.Last.Previous.Value;
                    Move z = b.Last.Value;
                    
                    if (x == y && y == z)
                    {

                        Move value = (Move)(((int)z + 1)%5);
                       
                       
                        return value;
                    }

                    if ((y == (Move)(((int)z + 1) % 5) && ((x == (Move)(((int)y + 1) % 5)))))
                    {
                        return z;
                    }

                    if ((z == (Move)(((int)y + 1) % 5) && ((y == (Move)(((int)x + 1) % 5)))))
                    {
                        return y;
                    }

                }


                a = true;
                return Move.Rock;
            }
            else
            {
                int i = (Game.SeededRandom.Next(0, 5));
                Move x = (Move)(( i+ 1) % 5);
               
                return x;

                
            }
        }
    }
}