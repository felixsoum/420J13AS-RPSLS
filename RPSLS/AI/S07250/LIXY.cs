using System;

namespace RPSLS
{
    class LIXY : StudentAI
    {
        public LIXY()
        {
            Nickname = "Pro";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Scissors;
        }
    }
}
