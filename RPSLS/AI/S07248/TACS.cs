using System;

namespace RPSLS
{
    class TACS : StudentAI
    {
        public TACS()
        {
            Nickname = "Sarkis";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
