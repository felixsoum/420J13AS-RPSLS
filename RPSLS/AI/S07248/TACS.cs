using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class TACS : StudentAI
    {
        private class RandomGenerator 
        {
            private static Random a = null;
            private RandomGenerator() { }

            public static Random GetInstance()
            {
                return a is null ? a = Game.SeededRandom : a;
            }
        }

        private int b1, b2, b3, b4, b5;
        private int c1, c2, c3, c4, c5;
        private int d1, d2, d3, d4, d5;
        private int e;
        private int f;
        private Move g1, g2, g3;      
        private bool h = false;
        private bool i = false;
        private bool j = false;
        private bool k = false;
        private int l;
        private int m = 0;
        private bool n = false;
        private int o;

        Random p = RandomGenerator.GetInstance();      
        public TACS()
        {
            Nickname = "TAX";           
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {

            if (h == false)
            {
                e++;
                if (j == false)
                {
                    Observe(g2);    
                }

                if (k == false)      
                {
                    CircleCheck(g2);                   
                }                            
                if (j == false)               
                {
                    SpamCheck(g2);
                }               
                
            }
                      
            if (h == true)      
            {
                f++;


                o = (d1 + d2 + d3 + d5 + d4);



                int roll = p.Next((o + 1));
                if (roll >= 0 && roll <= (d1))
                {
                    g1 = Move.Rock;
                }
                else if (roll > (d1) && roll <= (d1 + d2))
                { 
                    g1 = Move.Paper;
                }
                else if (roll > (d1 + d2) && roll <= (d1 + d2 + d3))
                {
                    g1 = Move.Scissors;
                }
                else if (roll > (d1 + d2 + d3) && roll <= (d1 + d2 + d3 + d5))
                {
                    g1 = Move.Spock;
                }
                else if (roll > (d1 + d2 + d3 + d5) && roll <= (d1 + d2 + d3 + d5 + d4))
                {
                    g1 = Move.Lizard;
                }
                if (f == 25)
                {
                    h = false;
                    f = 0;
                }

            }
            return g1;
            
           

        }

        private void CircleCheck(Move enemy)
        {
            if (n == true)  
            {
                if (enemy == Move.Scissors && g3 == Move.Spock)
                {
                    g1 = enemy;
                    l++;
                }
                else if (enemy == Move.Paper && g3 == Move.Scissors)
                {
                    g1 = enemy;
                    
                    l++;
                }
                else if (enemy == Move.Rock && g3 == Move.Paper)
                {
                   
                    g1 = enemy;
                    
                    l++;
                }
                else if (enemy == Move.Lizard && g3 == Move.Rock)
                {
                    g1 = enemy;
                    l++;
                }
                else if (enemy == Move.Spock && g3 == Move.Lizard)
                {
                    g1 = enemy;
                    l++;
                }
                else
                {
                    l = 0;
                    m--;
                    j = false;
                    if (m <= -5)
                    {
                        k = true;
                    }
                    g1 = g3;
                }
            }

            g3 = enemy;    

            if (n == false)   
            {
                g1 = Move.Spock;
            }

            n = true;      

            if (l >= 5 && j == false)       
            {
                
                j = true;
            }
        }        

        private void SpamCheck(Move enemy)
        {
            if (enemy == Move.Rock)  
            {
                b1++;
                c1 += 1;
                c2 = 0;
                c3 = 0;
                c4 = 0;
                c5 = 0;
            }
            else if (enemy == Move.Paper)
            {
                b2++;
                c2 += 1;

                c1 = 0;
                c3 = 0;
                c4 = 0;
                c5 = 0;
            }
            else if (enemy == Move.Scissors)
            {
                b3++;
                c3 += 1;

                c1 = 0;
                c2 = 0;
                c4 = 0;
                c5 = 0;
            }
            else if (enemy == Move.Spock)
            {
                b5++;
                c5 += 1;

                c1 = 0;
                c2 = 0;
                c3 = 0;
                c4 = 0;
            }
            else if (enemy == Move.Lizard)
            {
                b4++;
                c4 += 1;

                c1 = 0;
                c2 = 0;
                c3 = 0;
                c5 = 0;
            }
            else
            {
                 Console.WriteLine("Weird move detected, Played random AI (TACS)");
                 g1 = RandomMove();
             }


            if (c1 > 5)          
            {
                g1 = Move.Paper;
                i = true;
            }
            if (c2 > 5)          
            {
                g1 = Move.Scissors;
                i = true;
            }
            if (c3 > 5)          
            {
                g1 = Move.Spock;
                i = true;
            }
            if (c5 > 5)          
            {
                g1 = Move.Lizard;
                i = true;
            }
            if (c4 > 5)          
            {
                g1 = Move.Scissors;
                i = true;
            }
            if(c1 < 5 && c2 < 5 && c3 < 5 && c5 < 5 && c4 < 5)
            {            
                i = false;
            }
        }

        public override void Observe(Move E)
        {
            base.Observe(E);  
            g2 = E;      

            if (j == false && i == false)
            {
                if (e == 25)
                {
                    d1 = b1;
                    d2 = b2;
                    d3 = b3;
                    d4 = b4;
                    d5 = b5;
                    h = true;
                   
                    e = 0;

                    g1 = RandomMove();

                }
            }


        }
        
    }
}
