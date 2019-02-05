namespace RPSLS
{
    public class RockOnlyAI : BaseAI
    {
        public RockOnlyAI()
        {
            Nickname = "Rock Lee";
            CourseSection = Section.Dummy;
        }

        public override Move Play()
        {
            return Move.Rock;
        }
    }
}
