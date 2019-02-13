using System;

namespace RPSLS
{
    class JEAA : StudentAI
    {
        public JEAA()
        {
            Nickname = "paper";
            CourseSection = Section.S07049;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}