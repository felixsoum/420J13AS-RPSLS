namespace RPSLS
{
    class PHAN : StudentAI
    {
        int[,,] data = new int[5, 5, 5];
        Move? prev = null;
        Move? prev2 = Move.Rock;


        public PHAN()
        {
            Nickname = "Minh Phan";
            CourseSection = Section.S07250;
        }


        public override Move Play()
        {
            if (!prev.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move bestMove = Move.Rock;
                int bestCount = -1;
                for (int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)prev, (int)prev2, i];
                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }
                }


                switch (bestMove)
                {
                    case Move.Rock:
                    case Move.Scissors:
                        return Move.Spock;
                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;
                    case Move.Spock:
                        return Move.Lizard;
                    default:
                        return Move.Lizard;
                }
            }
        }

        public override void Observe(Move opponentMove)
        {
            if (prev.HasValue)
            {
                data[(int)prev, (int)prev2, (int)opponentMove]++;
            }
            prev = prev2;
            prev2 = opponentMove;
        }
    }
}