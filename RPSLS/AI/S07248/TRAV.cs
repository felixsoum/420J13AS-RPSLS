using System;

namespace RPSLS
{
    class TRAV : StudentAI
    {
        public TRAV()
        {
            Nickname = "Hoang";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
