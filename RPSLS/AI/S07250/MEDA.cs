﻿using System;

namespace RPSLS
{
    class MEDA : StudentAI
    {
        public MEDA()
        {
            IsDisqualified = true;

            Nickname = "Rasputin";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return Move.Spock; //Because Spock ALWAYS WINS!!!!!
        }
    }
}
