using System;

namespace RPSLS
{
    class GORT : StudentAI
    {
        public GORT()
        {
            Nickname = "Inhuman Rat";
            CourseSection = Section.S07049;
        }

        public override Move Play()
        {
            
            return RandomMove();
        }
    }
}
