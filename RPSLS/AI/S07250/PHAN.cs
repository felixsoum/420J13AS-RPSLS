using System;

namespace RPSLS
{
    class PHAN : StudentAI
    {
        public PHAN()
        {
            Nickname = "Ken";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
