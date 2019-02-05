/*
 * felixsoum
 * 
 * 420-J13-AS 
 * 
 * Rock, Paper, Scissors, Lizard, Spock for AI Games 2019
 */
namespace RPSLS
{
    class Program
    {
        //Replace GenericOneAI with your AI to test
        static BaseAI player1 = new GenericOneAI();
        static BaseAI player2 = new RockOnlyAI();

        static void Main(string[] args)
        {
            Game.Battle(player1, player2);
        }
    }
}
