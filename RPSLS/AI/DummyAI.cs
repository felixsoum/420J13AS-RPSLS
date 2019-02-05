namespace RPSLS
{
    public abstract class DummyAI : BaseAI
    {
        public int DummyLevel { get; set; } = 1;

        public override string GetAuthor()
        {
            return base.GetAuthor() + $" Lv.{DummyLevel}";
        }
    }
}
