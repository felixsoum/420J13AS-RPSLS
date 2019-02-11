/*
 * felixsoum
 * 
 * 420-J13-AS 
 * 
 * Rock, Paper, Scissors, Lizard, Spock for AI Games 2019
 */
using System;

namespace RPSLS
{
    class Program
    {
        static Game game = Game.GetInstance();

        static void Main(string[] args)
        {
            BaseAI player1 = CreateAI<GenericOneAI>();
            BaseAI player2 = CreateAI<RockOnlyAI>();
            game.Battle(player1, player2);
        }

        static BaseAI CreateAI<T>() where T : BaseAI
        {
            game.ResetMutex();
            return Activator.CreateInstance<T>();
        }
    }
}
