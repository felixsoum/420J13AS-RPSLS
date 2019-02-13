using System;

namespace RPSLS
{
    class MEIB : StudentAI
    {
        public MEIB()
        {
            Nickname = "JusBieberFan";
            CourseSection = Section.S07250;


        }

        public override Move Play()
        {
            return RandomMove();

            /* paper-->(Rock,Spock) & rock--> (Lizard,Scissor) & lizard(Paper,Spock) & spock(Rock,Scissor) & scissor(Paper,Lizard) */




        }
    }
}
