using System;

namespace RPSLS
{
    class TRAR : StudentAI
    {
       

        public TRAR()
        {
            Nickname = "Robert";
            CourseSection = Section.S07248;

        }

        

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
