using System;

namespace RPSLS
{
    class COSJ : StudentAI
    {
        public COSJ()
        {
            Nickname = "CosmoBot";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Lizard;
        }
    }
}
