namespace RPSLS
{
    class GenericOneAI : DummyAI
    {
        readonly Move favoriteMove;

        public GenericOneAI()
        {
            favoriteMove = RandomMove();
            Nickname = $"{favoriteMove} Enthusiast";
        }

        public override Move Play()
        {
            return favoriteMove;
        }
    }
}
