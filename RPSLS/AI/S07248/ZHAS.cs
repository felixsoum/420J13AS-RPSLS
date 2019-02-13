using System;

namespace RPSLS
{
    class ZHAS : StudentAI
    {
        public ZHAS()
        {
            Nickname = "Potato";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
