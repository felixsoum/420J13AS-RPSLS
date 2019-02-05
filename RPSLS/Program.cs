namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Battle(new GenericOneAI(), new RandomAI());
        }
    }
}
