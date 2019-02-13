using System;

namespace RPSLS
{
    class MELB : StudentAI
    {
        public MELB()
        {
            Nickname = "Nanith Omicron";
            //The best selection obviously .
            CourseSection = Section.S07049;
        }
        int funnynumber = 69;
        int turn = 1;
        public override Move Play()
        {


            if (turn == 1) Start();
//----------------------------------------------------------------//
            turn++;
            if (funnynumber == 69)
            {
                funnynumber = 420;
                return Move.Spock;
            }
           
            else
            {

                funnynumber = 69;
                return Move.Paper;
                
            }
          
        }

        void Start()
        {

         // For future "disrupting" function :   )
        }
    
    }
}
