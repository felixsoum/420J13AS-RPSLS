using System;

namespace RPSLS
{
    class WHIJ : StudentAI
    {
        public WHIJ()
        {
            Nickname = "SMorc";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
