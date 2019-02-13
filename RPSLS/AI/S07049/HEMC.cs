using System;
using System.Collections.Generic;

namespace RPSLS
{
    class HEMC : StudentAI
    {
        //List.//
        public List<string> plays = new List<string>();

       
        public HEMC()
        { 
            Nickname = "Leprauchaun 1.0";
        }

        public override Move Play()
        {
            ////make a list, check how many of each, return vs one that's higher.//
            ////plays.Add(getmove);
            //if(plays.Count < 0)
            //{

            //    return RandomMove();
            //}

            return Move.Lizard;
        }

        //private int rockPlays()
        //{
        //    int rockCount = 0;
        //    foreach(string Rock in plays.FindAll(x => x=="Rock"))
        //    {
        //        rockCount++;
        //    }

        //    return rockCount;
        //}

        //private int paperPlays()
        //{
        //    int paperCount = 0;
        //    foreach (string Paper in plays.FindAll(x => x == "Paper"))
        //    {
        //        paperCount++;
        //    }

        //    return paperCount;
        //}

        //private int ScissorsPlays()
        //{
        //    int scissorsCount = 0;
        //    foreach (string Scissors in plays.FindAll(x => x == "Scissors"))
        //    {
        //        scissorsCount++;
        //    }

        //    return scissorsCount;
        //}

        //private int lizardPlays()
        //{
        //    int lizardCount = 0;
        //    foreach (string Lizard in plays.FindAll(x => x == "Lizard"))
        //    {
        //        lizardCount++;
        //    }

        //    return lizardCount;
        //}

        //private int SpockPlays()
        //{
        //    int spockCount = 0;
        //    foreach (string Spock in plays.FindAll(x => x == "Spock"))
        //    {
        //        spockCount++;
        //    }

        //    return spockCount;
        //}

        //private void playsPercentage()
        //{
        //    int rock = 0;
        //    int paper = 0;
        //    int scissors = 0;
        //    int lizard = 0;
        //    int spock = 0;
        //    int total = 0;

        //    rock = rockPlays();
        //    paper = paperPlays();
        //    scissors = ScissorsPlays();
        //    lizard = lizardPlays();
        //    spock = SpockPlays();

        //    total = rock + paper + scissors + lizard + spock;




        //}
    }
}
