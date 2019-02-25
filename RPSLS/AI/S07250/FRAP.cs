using System;

namespace RPSLS
{
    class FRAP : StudentAI
    {
        private Move? a = null;
        private Move? b = null;
        private bool c = false;
        private bool d = false;
        private int e = 0;
        public FRAP()
        {
            Nickname = "Dummy AI";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            LostPrevRound();

            if (c && !d  )
            {
                b = a;
                return (Move)b;
            }

            else if (d)
            {
                b = RandomMove();
                return (Move)b;
            }

            else
            {
                if (a.HasValue)
                {
                    int rand = Game.SeededRandom.Next(2);

                    switch (a.Value)
                    {
                        case Move.Rock:
                            if (rand == 0)
                            {
                                b = Move.Paper;
                                return Move.Paper;
                            }
                            else
                            {
                                b = Move.Spock;
                                return Move.Spock;
                            }
                        case Move.Paper:
                            if (rand == 0)
                            {
                                b = Move.Scissors;
                                return Move.Scissors;
                            }
                            else
                            {
                                b = Move.Lizard;
                                return Move.Lizard;
                            }
                        case Move.Scissors:
                            if (rand == 0)
                            {
                                b = Move.Spock;
                                return Move.Spock;
                            }
                            else
                            {
                                b = Move.Rock;
                                return Move.Rock;
                            }
                        case Move.Spock:
                            if (rand == 0)
                            {
                                b = Move.Lizard;
                                return Move.Lizard;
                            }
                            else
                            {
                                b = Move.Paper;
                                return Move.Paper;
                            }
                        case Move.Lizard:
                            if (rand == 0)
                            {
                                b = Move.Rock;
                                return Move.Rock;
                            }
                            else
                            {
                                b = Move.Scissors;
                                return Move.Scissors;
                            }
                        default:
                            b = RandomMove();
                            return (Move)b;
                    }
                }

                else
                {
                    b = RandomMove();
                    return (Move)b;
                }
            }
        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
        }

        public void LostPrevRound()
        {
            if (b.HasValue && a.HasValue)
            {
                switch (((Move)b).CompareWith((Move)a))
                {
                    case 0:
                        e++;
                        break;
                    case 1:
                        break;
                    case -1:
                        e++;
                        break;
                    default:
                        break;
                }

                if (e > 1 && e < 5)
                {
                    c = true;
                }

                else if (e >= 5)
                {
                    c = false;
                    d = true;
                }
            }
        }
    }
}
