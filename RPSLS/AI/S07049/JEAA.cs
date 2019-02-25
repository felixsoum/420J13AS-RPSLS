using System;
using System.Collections.Generic;

namespace RPSLS
{
    class JEAA : StudentAI
    {
        int a = -1;
        Queue<MoveConection> b = new Queue<MoveConection>(5);
        Dictionary<Move,MoveConection> c; 

        public JEAA()
        {
            Nickname = "paper";
            CourseSection = Section.S07049;
            c = new Dictionary<Move, MoveConection>(5);
            c.Add(Move.Paper, new MoveConection(Move.Paper, Move.Rock, Move.Spock, Move.Scissors, Move.Lizard));
            c.Add(Move.Rock, new MoveConection(Move.Rock, Move.Lizard, Move.Scissors, Move.Paper, Move.Spock));
            c.Add(Move.Lizard, new MoveConection(Move.Lizard, Move.Spock, Move.Paper, Move.Rock, Move.Scissors));
            c.Add(Move.Spock, new MoveConection(Move.Spock, Move.Scissors, Move.Rock, Move.Lizard, Move.Paper));
            c.Add(Move.Scissors, new MoveConection(Move.Scissors, Move.Paper, Move.Lizard, Move.Spock, Move.Rock));
        }

        public override Move Play()
        {
            
            if(++a<1)
            {
                return RandomMove();
            }
            else if(a<6)
            {
                return b.GetLast().GetWin();
            }
            else
            {
                int k = (int)b.GetLast().Move + GetTrend();
                if (k>4)
                {
                    k -= 5;
                }
                else if( k<0)
                {
                    k += 5;
                }
                return c[(Move)k].GetWin();
                
            }
        }

        private int GetTrend()
        {
            MoveConection[] moves= b.GetValues();
            int[] diffs = new int[moves.Length-1];
            for(int i=0;i<diffs.Length;i++)
            {
                diffs[i] = moves[i].Compare(moves[i + 1]);
            }
            int[] k = new int[5];
            for(int i=1;i<diffs.Length-1;i++)
            {
                k[diffs[i]] += i;
            }
            int max = 0;
            int trend = 0;
            for(int i=0;i<k.Length;i++)
            {
                if (k[i]>max)
                {
                    max = k[i];
                    trend = i;
                }
            }
            return trend;
        }

        public override void Observe(Move opponentMove)
        {
            
            b.Add(c[opponentMove]);
        }

        #region classes

        class MoveConection
        {
            
            Move move;
            Move[] win;
            Move[] lose;

            public Move Move { get => move; set => move = value; }

            public MoveConection(Move move,Move win1,Move win2,Move lose1,Move lose2)
            {
                this.Move = move;
                win = new Move[] { win1, win2 };
                lose = new Move[] { lose1, lose2 };
            }

            public static int Compare(MoveConection first,MoveConection second)
            {
                return first.Compare(second);
            }
            public int Compare(MoveConection second)
            {
                int direction = second.Move - Move;
                if (direction < 0)
                {
                    direction += 5;
                }
                return direction;
            }

            public Move GetWin()
            {
                return lose[Game.SeededRandom.Next(0, 2)];
            }

            public Move GetMoveAtDiff(int diff)
            {
                int k = (int)Move + diff;
                if(k>4)
                {
                    k -= 5;
                }
                else if(k<0)
                {
                    k += 5;
                }
                return (Move)k;
            }

        }

        class Queue<T>
        {
            T[] values;
            int i=-1;

            public Queue(int size)
            {
                values = new T[size];
            }

            public T GetValueAtIndex(int index)
            {
                return values[index];
            }
            
            public void Add(T value)
            {
                i++;
                if(i<values.Length)
                {
                    values[i] = value;
                }
                else
                {
                    ShiftArray();
                    values[values.Length - 1]=value;
                }
            }
            private void ShiftArray()
            {
                for (int i = 0; i < values.Length - 1; i++)
                {
                    values[i] = values[i + 1];
                }
            }
            public T[] GetValues()
            {
                return values;
            }
            public T GetLast()
            {
                if (i > -1)
                {
                    if (i < values.Length)
                    {
                        return values[i];
                    }
                    else
                    {
                        return values[values.Length - 1];
                    }
                }
                else throw new Exception("no value in table") ;
            }

        }

        #endregion
    }
}