using System;

namespace RPSLS
{
    class GUXH : StudentAI
    {
        public GUXH()
        {
            Nickname = "Harry spinach";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return Move.Lizard;
        }
    }
}
