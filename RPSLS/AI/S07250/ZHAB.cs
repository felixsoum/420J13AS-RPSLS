using System;

namespace RPSLS
{
    class ZHAB : StudentAI
    {
        public ZHAB()
        {
            Nickname = "BBB";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
