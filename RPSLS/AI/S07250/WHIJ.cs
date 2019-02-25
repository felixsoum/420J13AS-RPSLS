using System;
namespace RPSLS
{
    class WHIJ : StudentAI
    {
        Move? a = null;
        Move b;
        Move c;

        private bool d;

        public WHIJ()
        {
            Nickname = "neverfirst";
            CourseSection = Section.S07250;
        }
        private int CheckWin()
        {
            switch (c.CompareWith(b))
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case -1:
                    return -1;
                default:
                    return 1;
            }
        }

        public override Move Play()
        {
            if (a.HasValue)
            {
                if (b.Equals(a))
                {
                    d = false;
                }
                else if (!b.Equals(a) && CheckWin() == 1)
                {
                    d = true;
                }
                else if (!b.Equals(a) && CheckWin() == -1)
                {
                    d = false;
                }
                return c;
            }
            else
            {
                return Move.Paper;
            }
        }
        public override void Observe(Move opponentMove)
        {
            a = b;
            b = opponentMove;

            int rand;
            if (!d)
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        rand = Game.SeededRandom.Next(2);
                        if (rand == 1)
                        {
                            c = Move.Spock;
                            break;
                        }
                        c = Move.Paper;
                        break;
                    case Move.Paper:
                        rand = Game.SeededRandom.Next(2);
                        if (rand == 1)
                        {
                            c = Move.Lizard;
                            break;
                        }
                        c = Move.Scissors;
                        break;
                    case Move.Scissors:
                        rand = Game.SeededRandom.Next(2);
                        if (rand == 1)
                        {
                            c = Move.Spock;
                            break;
                        }
                        c = Move.Rock;
                        break;
                    case Move.Spock:
                        rand = Game.SeededRandom.Next(2);
                        if (rand == 1)
                        {
                            c = Move.Lizard;
                            break;
                        }
                        c = Move.Paper;
                        break;
                    case Move.Lizard:
                        rand = Game.SeededRandom.Next(2);
                        if (rand == 1)
                        {
                            c = Move.Scissors;
                            break;
                        }
                        c = Move.Rock;
                        break;
                    default:
                        break;
                }
            }
            else if (d)
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        c = Move.Rock;
                        break;
                    case Move.Paper:
                        c = Move.Paper;
                        break;
                    case Move.Scissors:
                        c = Move.Scissors;
                        break;
                    case Move.Spock:
                        c = Move.Spock;
                        break;
                    case Move.Lizard:
                        c = Move.Lizard;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
