namespace RPSLS
{
    class KOMK : StudentAI
    {
        private Move? a = null;


        public KOMK()
        {
            Nickname = "Comik";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            if (a.HasValue)
            {
                switch (a)
                {
                    case Move.Rock:
                        return Move.Scissors;
                    case Move.Scissors:
                        return Move.Rock;
                    case Move.Lizard:
                        return Move.Scissors;
                    case Move.Paper:
                        return Move.Rock;
                    case Move.Spock:
                        return Move.Paper;
                    default:
                        return Move.Rock;
                }

            }
            else
            {
                return Move.Rock;
            }
        }
        public override void Observe(Move oppMove)
        {
            a = oppMove;
            base.Observe(oppMove);
        }
    }
}
