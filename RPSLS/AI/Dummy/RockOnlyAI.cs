namespace RPSLS
{
    public class RockOnlyAI : DummyAI
    {
        public RockOnlyAI()
        {
            Nickname = "Rock Lee";
        }

        public override Move Play()
        {
            return Move.Rock;
        }
    }
}
