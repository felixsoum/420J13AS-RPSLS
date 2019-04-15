namespace RPSLS
{
    class KOMK : StudentAI
    {
        public KOMK()
        {
            Nickname = "Comik";
            CourseSection = Section.S07250;
        }

        int[,] data = new int[5, 5];
        Move? moveX = null;

        public override Move Play()
        {
            if (moveX == null)
            {
                return Move.Rock;
            }
            else
            {
                Move bestMove = Move.Rock;
                int bestCount = -1;

                for (int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)moveX, i];
                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }

                }
                switch (bestMove)
                {
                    case Move.Rock: return Move.Spock;
                    case Move.Paper: return Move.Lizard;
                    case Move.Scissors: return Move.Rock;
                    case Move.Spock: return Move.Paper;
                    case Move.Lizard: return Move.Scissors;
                    default: return Move.Spock;
                }
            }
        }

        public override void Observe(Move opponentMove)
        {
            if (moveX.HasValue)
            {
                data[(int)moveX, (int)opponentMove]++;
            }
            moveX = opponentMove;
        }


    }

}
