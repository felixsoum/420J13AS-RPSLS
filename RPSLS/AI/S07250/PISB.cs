using System;

namespace RPSLS
{
    class PISB : StudentAI
    {
        static Move[] possibleMoves;
        static Random random = Game.SeededRandom;
        public new string Nickname { get; set; } = "Watson";
        public string Name { get; set; } = "Benito Pisanelli";
        public string Section { get; set; } = "07250";

        public PISB()
        {          
        }

        public override Move Play()
        {
            return Move.Rock;
        }
       
        protected new Move RandomMove()
        {
            return possibleMoves[random.Next(possibleMoves.Length)];
        }

        public override string ToString()
        {
            return Nickname;
        }

        public virtual string Author => GetType().Name;
    }
}
