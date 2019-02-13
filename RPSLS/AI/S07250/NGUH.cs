using System;

namespace RPSLS
{
    class NGUH : StudentAI
    {
        public NGUH()
        {
            Nickname = "JayHng";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Scissors;
        }
    
    }
}
