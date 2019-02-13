using System;

namespace RPSLS
{
    class DUXM : StudentAI
    {
        public DUXM()
        {
			Nickname = "mw";
			CourseSection = Section.S07250;
        }

        public override Move Play()
        {
			return Move.Scissors;
        }
    }
}
