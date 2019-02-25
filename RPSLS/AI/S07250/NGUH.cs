using System;
using System.Collections.Generic;

namespace RPSLS
{
    class NGUH : StudentAI
    {
        private Move? a = null;
        private List<Move> b = new List<Move>();
        private List<Move> c = new List<Move>();
        private bool d = false;
        private bool e = false;

        public NGUH()
        {
            Nickname = "JayHng";
            CourseSection = Section.S07250;
        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            b.Add(opponentMove);
            if (!c.Contains(opponentMove))
            {
                c.Add(opponentMove);
                e = true;

            }
        }

        private bool ForGenericAI()
        {
            int numberOfMove = 0;
            foreach (var item in c)
            {
                if (e == true)
                {
                    numberOfMove++;
                }
            }
            if (numberOfMove == 5 && b.Count == 5 && d == false)
            {
                d = true;
            }
            return d;
        }

        public override Move Play()
        {
            if (a.HasValue)
            {
                var forCircularAI = ForGenericAI();
                if (!forCircularAI)
                {
                    switch (a.Value)
                    {
                        case Move.Rock:
                        case Move.Scissors:
                            return Move.Spock;
                        case Move.Paper:
                        case Move.Lizard:
                            return Move.Scissors;
                        case Move.Spock:
                        default:
                            return Move.Paper;
                    }
                }
                else
                {
                    if (b.Count >= 5)
                    {
                        var MoveIndex = c.IndexOf(a.Value);
                        for (int i = 0; i < c.Count; i++)
                        {
                            if (i == (MoveIndex + 1) % 5)
                            {
                                var nextMove = b[i];
                                switch (nextMove)
                                {
                                    case Move.Rock:
                                    case Move.Scissors:
                                        return Move.Spock;
                                    case Move.Paper:
                                    case Move.Lizard:
                                        return Move.Scissors;
                                    case Move.Spock:
                                    default:
                                        return Move.Paper;
                                }
                            }
                        }
                    }
                }
                return RandomMove();
            }
            else
            {
                return RandomMove();
            }
        }
    }
}