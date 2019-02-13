using System;

namespace RPSLS
{
    class ZHAQ : StudentAI
    {
        public ZHAQ()
        {
            Nickname = "Sutton";
            CourseSection = Section.S07248;

        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
