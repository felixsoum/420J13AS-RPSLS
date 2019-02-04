namespace RPSLS
{
    class DummyAI : BaseAI
    {
        public DummyAI()
        {
            Nickname = "Rock Lee";
            CourseSection = Section.Teacher;
        }

        public override Move Play()
        {
            return Move.Rock;
        }
    }
}
