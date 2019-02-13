using System;

namespace RPSLS
{
    class GRAJ : StudentAI
    {
        public GRAJ()
        {
            Nickname = "AI J";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Paper;
        }
    }
}
