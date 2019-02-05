namespace RPSLS
{
    class RandomAI : BaseAI
    {
        public RandomAI()
        {
            Nickname = "Gambler";
            CourseSection = Section.Dummy;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
