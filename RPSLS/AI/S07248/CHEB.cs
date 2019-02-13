using System;

namespace RPSLS
{
    class CHEB : StudentAI
    {
        
        public CHEB()
        {
            Nickname = "Baiyang Chen";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
