using System;

namespace RPSLS
{
    class WANT : StudentAI
    {
        public WANT()
        {
            Nickname = "Wubu";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            double roll = Game.SeededRandom.NextDouble();
            if (roll<0.4)
            {
                return Move.Rock;
            }
            else if (roll<0.55)
            {
                return Move.Paper;
            }
            else if (roll<0.7)
            {
                return Move.Scissors;
            }
            else if (roll<0.85)
            {
                return Move.Lizard;
            }
            else
            {
                return Move.Spock;
            }
        }
    }
}
