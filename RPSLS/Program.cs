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
            var game = Game.Create<LastSolution>();

            //game.Challenge<RockOnlyAI>();
            //game.Challenge<GenericOneAI>();
            //game.Challenge<CircularAI>();

            //game.Challenge<FavoriteOneAI>();
            //game.Challenge<FavoriteTwoAI>();
            //game.Challenge<RepeaterAI>();

            //game.Challenge<MarkovOneAI>();
            //game.Challenge<MarkovTwoAI>();
            //game.Challenge<ShakespeareAI>();

            game.PlayTournament();

            game.End();
        }
    }
}
