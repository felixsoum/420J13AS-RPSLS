using System;

namespace RPSLS
{
    class TAVS : StudentAI
    {
        public TAVS()
        {
            Nickname = "Origami";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            return Move.Paper;
        }
    }
}
