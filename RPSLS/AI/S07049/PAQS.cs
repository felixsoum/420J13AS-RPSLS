using System;

namespace RPSLS
{
    class PAQS : StudentAI
    {
        public PAQS()
        {
            CourseSection = Section.S07049;
            Nickname = "The Master Chief";
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
