using System;

namespace RPSLS
{
    class BHOA : StudentAI
    {
        public BHOA()
        {
            Nickname = "WelcomeToChillies";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Lizard;
        }
    }
}
