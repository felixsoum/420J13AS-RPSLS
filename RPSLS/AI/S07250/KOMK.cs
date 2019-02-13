using System;

namespace RPSLS
{
    class KOMK : StudentAI
    {
        public KOMK()
        {
            Nickname = "Comik";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
