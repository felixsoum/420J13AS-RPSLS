using System;

namespace RPSLS
{
    class FRAP : StudentAI
    {
        public FRAP()
        {
            Nickname = "Dummy AI";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Paper;
        }
    }
}
