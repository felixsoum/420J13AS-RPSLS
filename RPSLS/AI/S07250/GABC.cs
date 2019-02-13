using System;

namespace RPSLS
{
    class GABC : StudentAI
    {
        public GABC()
        {
            Nickname = "Cookies";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Lizard;
        }
    }
}
