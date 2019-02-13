namespace RPSLS
{
    public class PaperOnlyAI : DummyAI
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
