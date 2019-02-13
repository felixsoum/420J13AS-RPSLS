using System;

namespace RPSLS
{
    class NOLR : StudentAI
    {
        public NOLR()
        {
            Nickname = "MultiFingers";
            CourseSection = Section.S07049;
        }

        public override Move Play()
        {       
            return Move.Paper;
        }
    }
}
