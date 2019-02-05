using System;
using System.IO;

namespace RPSLS
{
    public static class Game
    {
        public static bool IsLogging { get; set; } = true;
        static string LogPath;
        const int RoundMax = 100;
        static string log;

        static Game()
        {
            LogPath = Path.Combine("..", "..", "..", "BattleLog.txt");
        }

        public static int Battle(BaseAI ai1, BaseAI ai2)
        {
            Move move1;
            Move move2;
            int ai1WinCount = 0;
            int ai2WinCount = 0;
            log = "";
            Log($"{ai1} ({ai1.GetAuthor()}) VS {ai2} ({ai2.GetAuthor()}):\n");

            for (int i = 0; i < RoundMax; i++)
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
            string outcomeMessage = $"{ai1} won {ai1WinCount} rounds and {ai2} won {ai2WinCount} rounds.\n";

            if (ai1WinCount > ai2WinCount)
            {
                outcomeMessage += $"{ai1} ({ai1.GetAuthor()}) defeats {ai2} ({ai2.GetAuthor()})!\n";
            }
            else if (ai1WinCount < ai2WinCount)
            {
                outcomeMessage += $"{ai2} ({ai2.GetAuthor()}) defeats {ai1} ({ai1.GetAuthor()})!\n";
            }
            else
            {
                outcomeMessage += $"{ai1} ({ai1.GetAuthor()}) ties with {ai2} ({ai2.GetAuthor()})!\n";
            }
            Log(outcomeMessage);

            if (IsLogging)
            {
                Console.Write(outcomeMessage);
                Console.WriteLine($"Please see log at {Path.GetFullPath(LogPath)} for more details.");
                WriteToFile();
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

        static void WriteToFile()
        {
            File.WriteAllLines(LogPath, new string[] { log });
        }
    }
}
