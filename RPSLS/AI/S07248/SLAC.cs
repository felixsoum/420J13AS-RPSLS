using System;
using System.Diagnostics;

namespace RPSLS
{
    class SLAC : StudentAI
    {
        Move a = Move.Rock;
        Move b;
        public SLAC()
        {
            Nickname = "awesome possum";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return a;
        }

        public override void Observe(Move opponentMove)
        {

            if (opponentMove == b)
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
                        a = Move.Rock;
                        break;

                    case Move.Spock:
                        a = Move.Lizard;
                        break;

                    case Move.Lizard:
                        a = Move.Rock;
                        break;

                    default:
                        break;
                }
            } else
            {
                a = opponentMove;
            }


            b = opponentMove;

        }
        
    }
}

