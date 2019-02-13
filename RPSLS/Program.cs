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
        static void Main(string[] args)
        {
            var game = Game.Create<RandomAI>();

            game.Challenge<RockOnlyAI>();
            //game.Challenge<GenericOneAI>();
            //game.Challenge<CircularAI>();

            //game.PlayTournament();

            game.End();
        }
    }
}
