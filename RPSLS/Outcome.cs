namespace RPSLS
{
    class Outcome
    {
        public Move WinningMove { get; set; }
        public Move LosingMove { get; set; }
        public string Description { get; set; }

        public Outcome(Move winningMove, Move losingMove, string description)
        {
            this.WinningMove = winningMove;
            this.LosingMove = losingMove;
            this.Description = description;
        }
    }
}
