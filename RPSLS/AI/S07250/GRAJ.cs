using System;

namespace RPSLS
{
    class GRAJ : StudentAI
    {
        private Move? a = null;
       

        public GRAJ()
        {
            Nickname = "AI J";
            CourseSection = Section.S07250;

        }

        public override void Observe(Move botMove)
        {
            a = botMove;

        }

        public override Move Play()
        {

            if (a.HasValue)
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
                return RandomMove();
            }
        }
    }
}
