using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class HEMC : StudentAI
    {
        const int ROCK = 0;
        const int PAPER = 1;
        const int SCISSORS = 2;
        const int LIZARD = 3;
        const int SPOCK = 4;
 
        List<int> a = new List<int>();
        static readonly Move b;
        private static Random c = Game.SeededRandom;


        public HEMC()  
        {
            Nickname = "Leprauchaun 2.0";
            CourseSection = Section.S07049;
        }

        public override Move Play()
        {
            int indexMove = resultsPercentage();
            if (a.Count < 0)
            {
                return RandomMove();
            }

            if (indexMove == ROCK)
            {
                int[] Array = { 1, 2 };
                int randomIndex = c.Next(1, 2);
                int randomValue = Array[randomIndex];

                if (randomValue == 1){return Move.Paper;}
                if (randomValue == 2){return Move.Spock;}
            }
            if (indexMove == PAPER)
            {
                int[] Array = { 1, 2 };
                int randomIndex = c.Next(1, 2);
                int randomValue = Array[randomIndex];

                if (randomValue == 1){return Move.Scissors;}
                if (randomValue == 2){return Move.Lizard;}
            }
            if (indexMove == SCISSORS) 
            {
                int[] Array = { 1, 2 };
                int randomIndex = c.Next(1, 2);
                int randomValue = Array[randomIndex];

                if (randomValue == 1){return Move.Rock;}
                if (randomValue == 2){return Move.Spock;}
            }
            if (indexMove == LIZARD) 
            {
                int[] Array = { 1, 2 };
                int randomIndex = c.Next(1, 2);
                int randomValue = Array[randomIndex];

                if (randomValue == 1){return Move.Scissors;}
                if (randomValue == 2){return Move.Rock;}
            }
            if (indexMove == SPOCK)
            {
                int[] Array = { 1, 2 };
                int randomIndex = c.Next(1, 2);
                int randomValue = Array[randomIndex];

                if (randomValue == 1){return Move.Paper;}
                if (randomValue == 2){return Move.Lizard;}
            }


            return RandomMove();
        }

        private int resultsPercentage()
        {
            int rock;   
            int paper;  
            int scissors;  
            int lizard;  
            int spock;   

            int[] resultsB = new int[5];

            
            rock = rockResults();
            paper = paperResults();
            scissors = scissorsResults();
            lizard = lizardResults();
            spock = spockResults();

            resultsB[ROCK] = rock;
            resultsB[PAPER] = paper;
            resultsB[SCISSORS] = scissors;
            resultsB[LIZARD] = lizard;
            resultsB[SPOCK] = spock;

            int m = resultsB.Max();
            int p = Array.IndexOf(resultsB, m);
            return p;
        }

        public override void Observe(Move opponentMove)
        {
            int prevMov = (int) opponentMove;
            a.Add(prevMov);
        }
       
        private int rockResults()      
        {
            int rockCount = 0;
            foreach (var Rock in a.FindAll(x => x == 0))
            {
                rockCount++;
            }
            
            return rockCount;
            
        }
        private int paperResults()       
        {
            int paperCount = 0;
            foreach (var Paper in a.FindAll(x => x == 1))
            {
                paperCount++;
            }

            return paperCount;
        }
        private int scissorsResults()       
        {
            int scissorsCount = 0;
            foreach (var Scissors in a.FindAll(x => x == 2))
            {
                scissorsCount++;
            }

            return scissorsCount;
        }
        private int spockResults()       
        {
            int spockCount = 0;
            foreach (var Spock in a.FindAll(x => x == 3))
            {
                spockCount++;
            }

            return spockCount;
        }
        private int lizardResults()       
        {
            int lizardCount = 0;
            foreach (var Lizard in a.FindAll(x => x == 4))
            {
                lizardCount++;
            }

            return lizardCount;
        }
    }
}
