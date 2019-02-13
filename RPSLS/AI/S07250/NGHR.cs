using System;

namespace RPSLS
{
    class NGHR : StudentAI
    {
        public NGHR()
        {
            Nickname = "FinalExam";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
