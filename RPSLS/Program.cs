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
        static readonly Type studentAI = typeof(RandomAI);

        static Game game = Game.GetInstance();
        const int Seed = 2019;
        const int BattleCount = 20;

        static void Main(string[] args)
        {
            Challenge<RockOnlyAI>();
            Challenge<GenericOneAI>();
            Challenge<CircularAI>();
            game.WriteToFile();
        }

        static BaseAI CreateAI(Type type)
        {
            game.ResetMutex();
            return (BaseAI)Activator.CreateInstance(type);
        }

        static BaseAI CreateAI<T>() where T : BaseAI
        {
            return CreateAI(typeof(T));
        }

        static void Challenge<T>() where T : BaseAI
        {
            int seed = Seed;
            BaseAI player1 = null;
            BaseAI player2 = null;
            game.StartLog();
            bool isSuccess = true;
            for (int i = 0; i < BattleCount; i++)
            {
                game.SetSeed(seed++);
                player1 = CreateAI(studentAI);
                player2 = CreateAI<T>();
                game.SetBattleCount(i + 1);
                if (game.Battle(player1, player2) != 1)
                {
                    isSuccess = false;
                }
            }
            game.Log($"!!! Challenge against {player2.GetAuthor()} " + (isSuccess ? "passed" : "failed") + " !!! \n\n", true);
        }
    }
}
