namespace RPSLS.AI.Dummy
{
    class PaperOnlyAI : DummyAI
    {
        public PaperOnlyAI()
        {
            Nickname = "Origami Master";
        }

        public override Move Play()
        {
            return Move.Paper;
        }
    }
}
