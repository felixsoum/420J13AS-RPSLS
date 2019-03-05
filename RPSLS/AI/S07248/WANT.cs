using System.Collections.Generic;

namespace RPSLS
{
    class WANT : StudentAI
    {
        List<Move> a = new List<Move>();
        Move b;
        int c;
        int d;
        int e;
        int f;
        int g;
        public WANT()
        {
            Nickname = "Wubu";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            if (a.Count > 2)
            {
                if (a[1] != a[0])
                {
                    return b;
                }
                else
                {
                    if (c > 2)
                    {
                        return Move.Rock;
                    }
                    else if (d > 2)
                    {
                        return Move.Paper;
                    }
                    else if (e > 2)
                    {
                        return Move.Scissors;
                    }
                    else if (f > 2)
                    {
                        return Move.Lizard;
                    }
                    else if (g > 2)
                    {
                        return Move.Rock;
                    }
                    else
                    {
                        return RandomMove();
                    }
                }
            }
            else
            {
                return RandomMove();
            }
        }

        public override void Observe(Move opponentMove)
        {
            if (opponentMove == Move.Scissors)
            {
                c++;
                a.Add(Move.Scissors);
                b = Move.Scissors;
            }
            if (opponentMove == Move.Rock)
            {
                d++;
                a.Add(Move.Rock);
                b = Move.Rock;
            }
            if (opponentMove == Move.Paper)
            {
                e++;
                a.Add(Move.Paper);
                b = Move.Paper;
            }
            if (opponentMove == Move.Spock)
            {
                f++;
                a.Add(Move.Spock);
                b = Move.Spock;
            }
            if (opponentMove == Move.Lizard)
            {
                g++;
                a.Add(Move.Lizard);
                b = Move.Lizard;
            }
        }
    }
}
