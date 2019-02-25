using System;

namespace RPSLS
{
    class COSJ : StudentAI
    {
        private Move a;
        private Move b;
        
        public COSJ()
        {
            Nickname = "CosmoBot";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            if (a == b)
            {
                return MyMove(a);
            }
            else
            {
                return GetWhoBeats(b);
            }
        }

        public override void Observe(Move opponentMove)
        {
            b = a;
            a = opponentMove;
        }

        private Move MyMove(Move _spectedMove)
        {
            switch (_spectedMove)
            {
                case Move.Rock:
                    return Move.Paper;

                case Move.Lizard:
                    return Move.Rock;

                case Move.Spock:
                    return Move.Lizard;

                case Move.Scissors:
                    return Move.Spock;

                case Move.Paper:
                    return Move.Scissors;
                default:
                    return Move.Scissors;
            }
        }

        private Move GetWhoBeats(Move move)
        {
            switch (move)
            {
                case Move.Rock:
                    return Move.Lizard;

                case Move.Lizard:
                    return Move.Spock;

                case Move.Spock:
                    return Move.Scissors;

                case Move.Scissors:
                    return Move.Paper;

                case Move.Paper:
                    return Move.Rock;
                default:
                    return Move.Scissors;
               
            }
        }
    }
}
