using System;

namespace RPSLS
{
    class TRIM : StudentAI
    {
        public TRIM()
        {
			this.Nickname = "Minh";
			this.CourseSection = Section.S07248;
        }

        public override Move Play()
        {
			return RandomMove();
        }
    }
}
