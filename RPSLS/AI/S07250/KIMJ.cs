using System;

namespace RPSLS
{
    class KIMJ : StudentAI
    {
        public KIMJ()
        {
            Nickname = "Shevala";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Spock;
        }
    }
}
