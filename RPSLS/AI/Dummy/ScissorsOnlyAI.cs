namespace RPSLS
{
    public class ScissorsOnlyAI : DummyAI
    {
        public ScissorsOnlyAI()
        {
            Nickname = "Cut Man";
        }

        public override Move Play()
        {
            return Move.Scissors;
        }
    }
}
