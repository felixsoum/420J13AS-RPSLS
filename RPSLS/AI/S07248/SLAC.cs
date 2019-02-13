using System;

namespace RPSLS
{
    class SLAC : StudentAI
    {
        public SLAC()
        {
            Nickname = "awesome possum";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return Move.Lizard;
        }
    }
}
