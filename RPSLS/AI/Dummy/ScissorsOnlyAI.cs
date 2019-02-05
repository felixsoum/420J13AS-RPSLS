namespace RPSLS
{
    public class ScissorsOnlyAI : BaseAI
    {
        public ScissorsOnlyAI()
        {
            Nickname = "Cut Man";
            CourseSection = Section.Dummy;
        }

        public override Move Play()
        {
            return Move.Scissors;
        }
    }
}
