using System;

namespace RPSLS
{
    class RUAX : StudentAI
    {
        public RUAX()
        {
	        CourseSection = Section.S07250;
	        Nickname = "Ruan Xun";
        }

        public override Move Play()
        {
	        return Move.Paper;
        }
    }
}
