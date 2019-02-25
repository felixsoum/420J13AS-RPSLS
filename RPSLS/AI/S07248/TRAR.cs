using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class TRAR : StudentAI
    {
        private Move? a = null;
        private Move[] b = new Move[] { Move.Rock, Move.Rock, Move.Rock, Move.Rock, Move.Rock };
        private Move[] c = new Move[] { Move.Paper, Move.Paper, Move.Paper, Move.Paper, Move.Paper};
        private Move[] d = new Move[] { Move.Scissors, Move.Scissors, Move.Scissors, Move.Scissors, Move.Scissors };
        private Move[] e = new Move[] { Move.Lizard, Move.Lizard, Move.Lizard, Move.Lizard, Move.Lizard };
        private Move[] f = new Move[] { Move.Spock ,Move.Spock, Move.Spock, Move.Spock, Move.Spock };
        private Move[] g = new Move[] { Move.Rock, Move.Paper, Move.Scissors, Move.Spock, Move.Lizard };
        private Move[] h = new Move[5];
        
        private List<Move> i = new List<Move>();
        int j = 2;
        int k = 0;
        

        int l = 0;


        public TRAR()
        {
            Nickname = "Patrick :)";
            CourseSection = Section.S07248;
        }


        public override void Observe(Move opponentMove)
        {
            if (l == 5) {
                l = 0;
            }
            else
            {
                a = opponentMove;
                i.Insert(l,(Move)a);
                l++;
            }

        }
     
        public static bool compareArray(Move[] x ,Move[] y)
        {
            if (x.Count() != y.Count())
            {
                return false;
            }
            Array.Sort(x);
            Array.Sort(y);
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override Move Play()
        {

            if (i.Count > 5 && a.HasValue)
            {
                h[0] = i[0];
                h[1] = i[1];
                h[2] = i[2];
                h[3] = i[3];
                h[4] = i[4];


                if (compareArray(h, b))
                {
                    return Move.Paper;
                }
                if (compareArray(h, c))
                {
                    return Move.Scissors;
                }
                if (compareArray(h, d))
                {
                    return Move.Rock;
                }
                if (compareArray(h, f))
                {
                    return Move.Lizard;
                }
                if (compareArray(h, e))
                {
                    return Move.Rock;
                }

                if (i.Contains(Move.Scissors))
                {
                    int num = i.IndexOf(Move.Scissors);
                    if (num < 4)
                    {
                        if (i[num + 1] is Move.Paper)
                        {
                            return a.Value;
                        }
                        else
                        {
                            if (k < 65)
                            {
                                k++;
                                j %= 5;
                                return g[j++];
                            }
                            else
                            {
                                return RandomMove();
                            }
                        }
                    }
                    if (num == 4)
                    {
                        if (i[0] is Move.Paper)
                        {
                            return a.Value;
                        }
                        else
                        {
                            if (k < 55)
                            {
                                k++;
                                j %= 5;
                                return g[j++];
                            }
                            else
                            {
                                return RandomMove();
                            }
                        }
                    }
                    else
                    {
                        if (k < 55)
                        {
                            k++;
                            j %= 5;
                            return g[j++];
                        }
                        else
                        {
                            return RandomMove();
                        }
                    }
                }
                else
                {
                    if (k < 55)
                    {
                        k++;
                        j %= 5;
                        return g[j++];
                    }
                    else
                    {
                        return RandomMove();
                    }
                }
            }
            else
            {
                if (k < 55)
                {
                    k++;
                    j %= 5;
                    return g[j++];
                }
                else
                {
                    return RandomMove();
                }
            }
        }
    }
}
