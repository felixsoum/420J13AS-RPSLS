using System;

namespace RPSLS
{
    class AMAA : StudentAI
    {
        public AMAA()
        {
            Nickname = "Aman";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Scissors;
        }
       
    }

} 
