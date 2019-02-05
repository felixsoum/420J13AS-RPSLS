namespace RPSLS
{
    class GenericOneAI : BaseAI
    {
        readonly Move favoriteMove;

        public GenericOneAI()
        {
            favoriteMove = RandomMove();
            Nickname = $"{favoriteMove} Enthusiast";
            CourseSection = Section.Dummy;
        }

        public override Move Play()
        {
            return favoriteMove;
        }
    }
}
