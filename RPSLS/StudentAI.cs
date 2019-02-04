namespace RPSLS
{
    class StudentAI : BaseAI
    {
        public StudentAI()
        {
            Nickname = "felixsoum";
            CourseSection = Section.S07249;
        }

        public override Move Play()
        {
            return RandomMove();
        }
    }
}
