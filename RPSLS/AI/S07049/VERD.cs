using System;

namespace RPSLS
{
    class VERD : StudentAI
    {
        static Move[] moves;
        static Random random = Game.SeededRandom;


        public VERD()
        {
        }

        public override Move Play()
        {
            moves = (Move[])(Enum.GetValues(typeof(Move)));

            return moves[1];

        }

        public override string ToString()
        {
            return "David Daniel";
        }


    }
}
