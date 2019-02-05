namespace RPSLS
{
    class RandomAI : DummyAI
    {
        public RandomAI()
        {
            Nickname = "Gambler";
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
