using System;

namespace RPSLS
{
    class SUNY : StudentAI
    {
        public SUNY()
        {
            Nickname = "BaBa";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return Move.Rock;
        }
    }
}
