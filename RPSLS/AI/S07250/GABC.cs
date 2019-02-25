using System;

namespace RPSLS
{
    class GABC : StudentAI
    {
        Move a;
        Move b;
        bool c = false;

        public GABC()
        {
            Nickname = "Cookies";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return a;
        }

        public override void Observe(Move opponentMove)
        {
            if (!c)
            {
                b = opponentMove;
                c = true;
            }
            if (b != opponentMove)
            {
                switch (opponentMove)
                {
                    case Move.Scissors:
                        a = Move.Scissors;
                        break;
                    case Move.Paper:
                        a = Move.Paper;
                        break;
                    case Move.Rock:
                        a = Move.Rock;
                        break;
                    case Move.Lizard:
                        a = Move.Lizard;
                        break;
                    case Move.Spock:
                        a = Move.Rock;
                        break;
                }
            }
            else
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        a = Move.Paper;
                        break;
                    case Move.Paper:
                        a = Move.Scissors;
                        break;
                    case Move.Scissors:
                        a = Move.Spock;
                        break;
                    case Move.Spock:
                        a = Move.Lizard;
                        break;
                    case Move.Lizard:
                        a = Move.Rock;
                        break;
                }
            }

        }
    }
}
