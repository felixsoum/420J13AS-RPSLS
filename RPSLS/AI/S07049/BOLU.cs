using System;

namespace RPSLS
{
    class BOLU : StudentAI
    {
        static int countdown;
        public BOLU()
        {
            Nickname = "The World ends with Mittens";
            CourseSection = Section.S07049;
            countdown = 0;
        }

        public override Move Play()
        {
            Move chosenOne = RandomMove();
            if (countdown < 50)
            {

                chosenOne = (Move)((int)RandomMove() - 1);
                countdown++;

            }
            else
            {
                if (countdown % 2 == 0)
                {
                    chosenOne = Move.Lizard;
                }
                else
                {
                    chosenOne = Move.Spock;
                }
                countdown++;
            }

            return chosenOne;

        }
    }
}