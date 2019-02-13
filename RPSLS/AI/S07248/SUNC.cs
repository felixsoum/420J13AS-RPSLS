using System;

namespace RPSLS
{
    class SUNC : StudentAI
    {
        public SUNC()
        {
            Nickname = "Chengyu Sun";

        }

        public override Move Play()
        {

            return Move.Paper;
        }
    }
}
