using System;

namespace RPSLS
{
    class SINS : StudentAI
    {
        public SINS()
        {
            Nickname = "mango boy";
            CourseSection = Section.S07248;


        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
