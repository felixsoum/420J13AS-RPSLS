using System;

namespace RPSLS
{
    class LEPA : StudentAI
    {
        public LEPA()
        {
            Nickname = "GrisWoldDiablo";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            //Move randomMove = (Move)new Random().Next(((Move[])Enum.GetValues(typeof(Move))).Length);

            return RandomMove();
        }
    }
}
