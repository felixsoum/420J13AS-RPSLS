namespace RPSLS
{
    public abstract class StudentAI : BaseAI
    {
        public Section CourseSection { get; set; } = Section.None;
    }
}
