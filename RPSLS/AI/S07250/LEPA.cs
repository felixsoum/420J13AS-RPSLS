using System;
using System.Collections.Generic;

namespace RPSLS
{
    
    class LEPA : StudentAI
    {

        private Random a = Game.SeededRandom;
        private int b;

        private Move c;
        List<Move> d = new List<Move>();
        List<Move> e = new List<Move>();
        Move f;
        float[] g = new float[5];
        int[] h = new int[5];
        float[] i = new float[5];
        int[] j = new int[5];
        static int k = 0;

        int[] m = new int[] { 0, 3, 1, 4, 2 };
        int n = 0;
        bool o = true;

        bool p = false;
        int q = 0;
        int r = 0;
        int s = 0;
        int t = 0;

        public LEPA()
        {
            k++;
            Nickname = $"GrisWold Diablo"; 
            CourseSection = Section.S07250;
            b = a.Next(2);
        }

        public override Move Play()
        {
            #region SHOWMOVES

            #endregion
            if (o)
            {
                c = PlayFromQueue();
            }
            f = c;
            return c;
        }

        private Move PlayFromQueue()
        {
            if (n > 4)
            {
                n = 0;
            }
            return (Move)m[n++];
        }

       

        public override void Observe(Move opponentMove)
        {
            if (opponentMove < 0)
            {
                Console.WriteLine();
            }
            #region QTYWINLOST
            if (WonLast(f, opponentMove))
            {
                p = true;
                q++;
                s++;
                t = -1;
            }
            else
            {
                p = false;
                r++;
                t++;
                s = -1;
            }
            #endregion

            d.Add(opponentMove);

            #region CALC_PERCENTAGE
            if (opponentMove >= 0)
            {

                h[(int)opponentMove]++;
                j[(int)f]++;
                SetPercentage(opponentMove);
                e.Add(f);
                SetPlayerPercentage(f);
            }
            #endregion

            if (t > 3)
            {
                b = a.Next(2);
            }
            if (s > 2)
            {
                b = a.Next(2);
            }

            int minDist = MinDistance();
            c = GetCounterMove(opponentMove - minDist);
            
            if (IsItCircular())
            {
                o = false;
                if (opponentMove >= 0)
                {
                    c = opponentMove; 
                }
                else
                {
                    o = true;
                }
            }
            else
            {
                if (d.Count > 1)
                {
                    if (opponentMove == d[d.Count - 2])
                    {
                        o = false;
                    }
                    else
                    {
                        o = true;
                    } 
                }
            }
            if ((p && s > 20) || t > 2)
            {
                c = GetCounterMove(GetHighestPercentageMove());
                o = false;
            }
        }

        private bool FeelsRandom()
        {
            int diffPercentage = 0;
            float highest = 0;
            float lowest = int.MaxValue;
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i] > highest)
                {
                    highest = g[i];
                }
                else if (g[i] < lowest)
                {
                    lowest = g[i];
                }
            }

            return highest - lowest < 0.1;
        }
        
        private Move GetHighestPercentageMove()
        {
            float highest = 0;
            int index = 0;
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i] > highest)
                {
                    highest = g[i];
                    index = i;
                }
            }
            return (Move)index;
        }

        public Move GetCounterMove(Move _move)
        {
            
            switch (_move)
            {
                case Move.Rock:
                    return b == 0 ? Move.Paper : Move.Spock;
                case Move.Paper:
                    return b == 0 ? Move.Scissors : Move.Lizard;
                case Move.Scissors:
                    return b == 0 ? Move.Rock : Move.Spock;
                case Move.Spock:
                    return b == 0 ? Move.Paper : Move.Lizard;
                default: 
                    return b == 0 ? Move.Rock : Move.Scissors;
            }
        }

        public int MinDistance()
        {
            int minDistance = int.MaxValue;
            int prevNumber = (int)d[0];
            for (int i = 1; i < d.Count; i++)
            {
                int distance = Math.Abs(prevNumber - (int)d[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
                prevNumber = (int)d[i];
            }
            return minDistance;
        }

        private void SetPercentage(Move _move)
        {
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = h[i] / (float)d.Count;
            }
            for (int i = 0; i < this.i.Length; i++)
            {
                this.i[i] = j[i] / (float)d.Count;
            }
        }

        private void SetPlayerPercentage(Move _move)
        {
            
            for (int i = 0; i < this.i.Length; i++)
            {
                this.i[i] = j[i] / (float)e.Count;
            }
        }

        private Move HighestMovePlayed()
        {
            int higestIndex = 0;
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i] > g[higestIndex])
                {
                    higestIndex = i;
                }
            }
            return (Move)higestIndex;
        }

        private Move HighestPlayerMovePlayed()
        {
            int higestIndex = 0;
            for (int i = 0; i < this.i.Length; i++)
            {
                if (this.i[i] >= this.i[higestIndex])
                {
                    higestIndex = i;
                }
            }
            return (Move)higestIndex;
        }

        private bool WonLast(Move playerMove, Move opMove)
        {
            if (playerMove == opMove)
            {
                return false;
            }
            switch (playerMove)
            {
                case Move.Rock:
                    if (opMove != Move.Spock && opMove != Move.Paper)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Move.Paper:
                    if (opMove != Move.Scissors && opMove != Move.Lizard)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Move.Scissors:
                    if (opMove != Move.Rock && opMove != Move.Spock)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Move.Spock:
                    if (opMove != Move.Lizard && opMove != Move.Paper)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:  
                    if (opMove != Move.Scissors && opMove != Move.Rock)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
        }
        private void showMoves()
        {
            if (this.e.Count != 0)
            {
                Console.WriteLine($"----{this.Nickname}----");
                for (int i = 0; i < this.i.Length; i++)
                {
                    Console.WriteLine($"{(Move)i} : {j[i]} , {this.i[i].ToString("P2")}");
                }
                Console.WriteLine("*** OPPONENT ***");
                for (int i = 0; i < g.Length; i++)
                {
                    Console.WriteLine($"{(Move)i} : {h[i]} , {g[i].ToString("P2")}");
                }
                Console.WriteLine($"--------");
            }
        }

        public bool IsItCircular()
        {
            bool circular = false;
            for (int i = 1; i < d.Count; i++)
            {
                if(WonLast(d[i - 1], d[i]))
                {
                    circular = true;
                }
                else
                {
                    return false;
                }
            }
            return circular;
        }
    }   
}  
