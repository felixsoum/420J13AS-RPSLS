namespace RPSLS
{
    class CHEB : StudentAI
    {
        Move a;
        int b = 0;
        public CHEB()
        {
            Nickname = "Baiyang Chen";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {

            if (a is Move.Rock)
            {
                b++;
                if (b >= 2)
                {
                    return Move.Paper;
                }
                else
                {
                    return Move.Rock;
                }
            }
            b = 0;
            if (a is Move.Paper)
            {
                b++;
                if (b >= 2)
                {
                    return Move.Scissors;

                }
                else
                {
                    return Move.Paper;

                }
            }
            b = 0;
            if (a is Move.Spock)
            {
                b++;
                if (b >= 2)
                {
                    return Move.Lizard;

                }
                else
                {
                    return Move.Rock;

                }
            }
            b = 0;
            if (a is Move.Lizard)
            {
                if (b >= 2)
                {
                    return Move.Scissors;

                }
                else
                {
                    return Move.Lizard;

                }
            }
            b = 0;
            if (a is Move.Scissors)
            {
                if (b >= 2)
                {
                    return Move.Rock;

                }
                else
                {
                    return Move.Lizard;

                }
            }
            return RandomMove();
        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
            base.Observe(opponentMove);
        }


    }
}
