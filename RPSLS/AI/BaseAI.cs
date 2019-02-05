using System;

namespace RPSLS
{
    public abstract class BaseAI
    {
        static Move[] possibleMoves;
        static Random random = new Random();
        public string Nickname { get; set; }
        public Section CourseSection { get; set; }

        public abstract Move Play();

        static BaseAI()
        {
            possibleMoves = (Move[])(Enum.GetValues(typeof(Move)));
        }

        protected Move RandomMove()
        {
            return possibleMoves[random.Next(possibleMoves.Length)];
        }

        public override string ToString()
        {
            return Nickname;
        }

        public string GetAuthor()
        {
            return GetType().Name;
        }
    }
}
