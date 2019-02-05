namespace RPSLS
{
    class Outcome
    {
        public Move WinningMove { get; set; }
        public Move LosingMove { get; set; }

        public Outcome(Move winningMove, Move losingMove)
        {
            WinningMove = winningMove;
            LosingMove = losingMove;
        }
    }
}
