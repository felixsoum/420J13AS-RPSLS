using System;

namespace RPSLS
{
    public abstract class BaseAI
    {
        static Move[] possibleMoves;

        public string Nickname { get; set; } = "???";

        public abstract Move Play();

        static BaseAI()
        {
            possibleMoves = (Move[])(Enum.GetValues(typeof(Move)));
        }

        public BaseAI()
        {
            if (Game.Mutex > 0)
            {
                throw new UnauthorizedAccessException();
            }
            else
            {
                Game.IncrementMutex();
            }
        }

        public virtual void Observe(Move opponentMove) { }

        protected Move RandomMove()
        {
            return possibleMoves[Game.SeededRandom.Next(possibleMoves.Length)];
        }

        public override string ToString()
        {
            return Nickname;
        }

        public virtual string GetAuthor()
        {
            return GetType().Name;
        }
    }
}
