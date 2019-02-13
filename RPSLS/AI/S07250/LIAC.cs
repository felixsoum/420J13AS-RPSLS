using System;

namespace RPSLS
{
    class LIAC : StudentAI
    {
        public LIAC()
        {
            Nickname = "AThumb";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Scissors;
        }
    }
}
