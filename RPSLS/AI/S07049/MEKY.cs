using System;

namespace RPSLS
{
    class MEKY : StudentAI
    {
        public MEKY()
        {
            Nickname = "Saitama";
            CourseSection = Section.S07049;
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
