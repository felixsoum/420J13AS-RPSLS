using System;
using System.Collections.Generic;
using System.IO;

namespace RPSLS
{
    public sealed class Game
    {
        public bool IsLogging { get; set; } = true;
        static string LogPath;
        const int RoundMax = 100;
        static string log;
        static List<string> fullLog = new List<string>();
        static bool isInstantiated;
        public static int Mutex { get; private set; }
        public static Random SeededRandom { get; private set; }

        static Game()
        {
            LogPath = Path.Combine("..", "..", "..", "BattleLog.txt");
        }

        public static Game GetInstance()
        {
            if (!isInstantiated)
            {
                isInstantiated = true;
                return new Game();
            }
            return null;
        }

        private Game() { }

        public int Battle(BaseAI ai1, BaseAI ai2)
        {
            Move move1;
            Move move2;
            Move? prevMove1 = null;
            Move? prevMove2 = null;

            int ai1WinCount = 0;
            int ai2WinCount = 0;
            Log($"{ai1} ({ai1.GetAuthor()}) VS {ai2} ({ai2.GetAuthor()}):\n", true);

            for (int i = 0; i < RoundMax; i++)
            {
                if (prevMove2.HasValue)
                {
                    ai1.Observe(prevMove2.Value);
                }
                move1 = ai1.Play();
                if (prevMove1.HasValue)
                {
                    ai2.Observe(prevMove1.Value); 
                }
                move2 = ai2.Play();

                prevMove1 = move1;
                prevMove2 = move2;

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
                outcomeMessage += $"{ai1} ({ai1.GetAuthor()}) defeats {ai2} ({ai2.GetAuthor()})!\n\n";
            }
            else if (ai1WinCount < ai2WinCount)
            {
                outcomeMessage += $"{ai2} ({ai2.GetAuthor()}) defeats {ai1} ({ai1.GetAuthor()})!\n\n";
            }
            else
            {
                outcomeMessage += $"{ai1} ({ai1.GetAuthor()}) ties with {ai2} ({ai2.GetAuthor()})!\n\n";
            }

            Log(outcomeMessage, true);

            if (IsLogging)
            {
                fullLog.Add(log);
            }

            return ai1WinCount.CompareTo(ai2WinCount);
        }

        public void SetBattleCount(int n)
        {
            log = "";
            Log($"Battle {n} ================================================================\n", true);
        }

        public void StartLog()
        {
            if (IsLogging)
            {
                fullLog.Clear();
            }
        }

        public void Log(string message, bool andPrint = false)
        {
            if (IsLogging)
            {
                log += message;
            }
            if (andPrint)
            {
                Console.Write(message);
            }
        }

        public void WriteToFile()
        {
            if (IsLogging)
            {
                Console.WriteLine($"Please see log at {Path.GetFullPath(LogPath)} for more details.");
                File.WriteAllLines(LogPath, fullLog);
            }
        }

        public void ResetMutex()
        {
            Mutex = 0;
        }

        public static void IncrementMutex()
        {
            Mutex++;
        }

        public void SetSeed(int seed)
        {
            SeededRandom = new Random(seed);
        }
    }
}
