using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class PHAN : StudentAI
    {
        private bool a = false;
        private Move? b = null;
        private List<Move> c = new List<Move>();
        private Dictionary<Move, bool> d = new Dictionary<Move, bool>();

        public PHAN()
        {
            Nickname = "OnePlus - Flaship Killer";
            CourseSection = Section.S07250;
        }

        public override void Observe(Move opponentMove)
        {
            b = opponentMove;
            c.Add(opponentMove);
            if (!d.ContainsKey(opponentMove))
            {
                d.Add(opponentMove, true);
            }
        }

        public override Move Play()
        {
            if (b.HasValue)
            {
                var isPattern = IsPattern();
                if (!isPattern)
                {
                    switch (b.Value)
                    {
                        case Move.Paper:
                        case Move.Lizard:
                            return Move.Scissors;
                        case Move.Rock:
                        case Move.Spock:
                            return Move.Paper;
                        case Move.Scissors:
                        default:
                            return Move.Rock;
                    }
                }
                else
                {
                    if (c.Count >= 5)
                    {
                        var idxOfLastMoveAI = d.Keys.ToList().IndexOf(b.Value);
                        for (int i = 0; i < d.Keys.Count; i++)
                        {
                            if (i == (idxOfLastMoveAI + 1) % 5)
                            {
                                return b.Value;
                            }
                        }
                    }
                    return RandomMove();
                }
            }
            else
            {
                return RandomMove();
            }
        }


        private bool IsPattern()
        {
            int sumOfElements = 0;
            foreach (var item in d.Values)
            {
                if (item == true)
                {
                    sumOfElements += 1;
                }
            }
            if (a == false && sumOfElements == 5 && c.Count == 5)
            {
                a = true;
            }
            return a;
        }

    }
}