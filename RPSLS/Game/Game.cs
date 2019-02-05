using System;

namespace RPSLS
{
    public static class Game
    {
        public static bool IsLogging { get; set; } = true;
        static string log;

        public static int Battle(BaseAI ai1, BaseAI ai2)
        {
            Move move1;
            Move move2;
            int ai1WinCount = 0;
            int ai2WinCount = 0;
            log = "";
            Log($"{ai1} ({ai1.GetType()}) VS {ai2} ({ai2.GetType()}):\n");

            for (int i = 0; i < 100; i++)
            {
                move1 = ai1.Play();
                move2 = ai2.Play();

                Log($"Round {i + 1}: ");

                switch (move1.CompareWith(move2))
                {
                    case 0:
                        Log($"{ai1} and {ai2} both played {move1}.\n");
                        break;
                    case 1:
                        ai1WinCount++;
                        Log($"{ai1}'s {move1} beats {ai2}'s {move2}.\n");
                        break;
                    case -1:
                        ai2WinCount++;
                        Log($"{ai2}'s {move2} beats {ai1}'s {move1}.\n");
                        break;
                }
            }

            Log($"{ai1} won {ai1WinCount} rounds and {ai2} won {ai2WinCount} rounds.\n");

            if (ai1WinCount > ai2WinCount)
            {
                Log($"{ai1} ({ai1.GetType()}) defeats {ai2} ({ai2.GetType()})!\n");
            }
            else if (ai1WinCount < ai2WinCount)
            {
                Log($"{ai2} ({ai2.GetType()}) defeats {ai1} ({ai1.GetType()})!\n");
            }
            else
            {
                Log($"{ai1} ({ai1.GetType()}) ties with {ai2} ({ai2.GetType()})!\n");
            }

            if (IsLogging)
            {
                Console.WriteLine(log);
            }

            return ai1WinCount.CompareTo(ai2WinCount);
        }

        static void Log(string message)
        {
            if (IsLogging)
            {
                log += message;
            }
        }
    }
}
