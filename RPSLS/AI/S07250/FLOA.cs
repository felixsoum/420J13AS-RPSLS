using System;

namespace RPSLS
{
    class FLOA : StudentAI
    {
        public FLOA()
        {
            Nickname = "Sora";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return RandomMove();

            
        }
    }
}
