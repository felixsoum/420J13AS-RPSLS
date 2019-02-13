using System;

namespace RPSLS
{
    class HASN : StudentAI
    {
        public HASN()
        {
            Nickname = "Nico";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Lizard;
        }
    }
}
