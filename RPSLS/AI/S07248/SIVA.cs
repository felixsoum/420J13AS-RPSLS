using System;

namespace RPSLS
{
    class SIVA : StudentAI
    {
        public SIVA()
        {
            CourseSection = Section.S07248;
            Nickname = "Is this supposed to be the nickname of my bot?";
        }

        public override Move Play()
        {
            //Paper kills Rock and Spock
            //Rock kills Scissors and Lizard
            //Scissors kills Paper and Lizard
            //Lizard kills Paper and Spock
            //Spock kills Rock and Scissors
            //return RandomMove[] = {Rock, Paper, Scissors, Lizard, Spock}
            return RandomMove();
        }
    }
}
