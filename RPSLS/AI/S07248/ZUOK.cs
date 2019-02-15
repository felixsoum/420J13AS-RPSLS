using System;

namespace RPSLS
{
    class ZUOK : StudentAI
    {
        public ZUOK()
        {
            Nickname = "KaiWen";
            CourseSection = Section.S07248;

        }

        public override Move Play()
        {

            return Move.Scissors;
        }





    }
}
