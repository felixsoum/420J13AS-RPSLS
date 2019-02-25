using System;
using System.Collections.Generic;

namespace RPSLS
{
    class VERD : StudentAI
    {
        
        static Random a = Game.SeededRandom;
        private List<Move> b = new List<Move>();
        private static List<List<Move>> c = new List<List<Move>>();
        private List<AILeaderboard> d = new List<AILeaderboard>();

        int e = 0;
        int f = 0;
        int g = 0;
        

        Move h;
        Move i;
        Move j;
        Move k;
        Move l;
        Move m;
        Move n;
        Move o;
        Move p;
        Move q;
        Move r;



        public VERD()
        {
           
            Nickname = "David Daniel";
            CourseSection = Section.S07049;

            c.Clear();
            d.Clear();

            d.Add(new AILeaderboard("AFirst", 0));
            d[0].Name = "AFirst";
            d.Add(new AILeaderboard("BSecond", 0));
            d[1].Name = "BSecond";
            d.Add(new AILeaderboard("CThird", 0));
            d[2].Name = "CThird";
            d.Add(new AILeaderboard("DFourth", 0));
            d[3].Name = "DFourth";

        }

       
        public override void Observe(Move opponentMove)
        {
            i = opponentMove;
        }

        class Result
        {
            public Move Name { get; set; }
            public int Count { get; set; }
           
           
        

            public Result(Move name, int count)
            {

                name = Name;
                count = Count;
                
            }

        }

        private Move TreatData(List<List<Move>> list, int index)
        {
            
            int rocks = 0;
            int scissors = 0;
            int papers = 0;
            int lizards = 0;
            int spocks = 0;

            foreach (var item in list)
            {
               
                switch (item[index].ToString())
                {
                    case "Rock":
                        rocks++;
                        
                        continue;
                    case "Paper":
                        papers++;
                       
                        continue;
                    case "Scissors":
                        scissors++;
                        
                        continue;
                    case "Spock":
                        spocks++;
                        
                        continue;

                    case "Lizard":
                        lizards++;
                       
                        continue;
                    default:
                        
                        break;
                }
            }
          
            List<Result> results = new List<Result>();

            results.Add(new Result(Move.Rock, rocks));
            results[results.Count - 1].Name = Move.Rock;
            results[results.Count - 1].Count = rocks;
            results.Add(new Result(Move.Paper, papers));
            results[results.Count - 1].Name = Move.Paper;
            results[results.Count - 1].Count = papers;
            results.Add(new Result(Move.Scissors, scissors));
            results[results.Count - 1].Name = Move.Scissors;
            results[results.Count - 1].Count = scissors;
            results.Add(new Result(Move.Lizard, lizards));
            results[results.Count - 1].Name = Move.Lizard;
            results[results.Count - 1].Count = lizards;
            results.Add(new Result(Move.Spock, spocks));
            results[results.Count - 1].Name = Move.Spock;
            results[results.Count - 1].Count = spocks;
            results.Sort((a, b) => (a.Count.CompareTo(b.Count)));
            
            Move move = choice(results[0].Name);
           
            
            return move;

        }

        

        private Move First()
        {
            Move toReturn = Move.Spock;
            toReturn = choice(i);
      
            return toReturn;
        }
        private Move Second()
        {           
            Move toReturn = Move.Spock;
            toReturn = TreatData(c, g);
            
            return toReturn;
        }

        private Move Third()
        {
            Move toReturn = i;
            return toReturn;
        }

        private Move Fourth()
        {
            Move toReturn = Move.Lizard;
           
            return toReturn;
        }


        private Move Advisers()
        {
            d.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            j = First();            
            d[0].Wins += CheckWin(n);

            if (e + f > 4)
            {
                k = Second();
                k = choice(k);
                d[1].Wins += CheckWin(o);


            }

            l = Third();
            d[2].Wins += CheckWin(p);

            m = Fourth();
            d[3].Wins += CheckWin(q);
            
            d.Sort((a, b) => (a.Wins.CompareTo(b.Wins)));

            n = j;
            o = k;
            p = l;
            q = m;

            
            switch (d[d.Count-1].Name)
            {
                case "AFirst":
                    return j;
                case "BSecond":
                    return k;
                case "CThird":
                    return l;
                case "DFourth":
                    return m;
                default:
                    return j;
            }

        }
        private int CheckWin(Move move)
        {
            switch (move.CompareWith(i))
            {
                case 0:
                    break;
                case 1:
                    return 1;
                    
                case -1:
                    return 0;
            }
            return 0;
        }

        public override Move Play()
        {
            d.Sort((a, b) => (a.Name.CompareTo(b.Name)));        
            
            if (b.Count<4)
            {
                b.Add(i);
                   
            }
            else
            {
                c.Add(b);
                b.Clear();
                b.Add(i);
                g = 0;
            }
            if (g == 4)
            {
                g = 3;
            }
          

            
            switch (r.CompareWith(i))
            {
                case 0:
                    break;
                case 1:
                    e++;
                    break;
                case -1:
                    f++;
                    break;
            }
            h = Advisers();
            d.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            

            g++;
            r = h;
            return h;


        }
        
        

        private Move choice(Move OppMove)
        {
            string a = i.ToString();
            switch (a)
            {
                case "Rock":
                    return Move.Paper;                   
                case "Paper":
                    return Move.Scissors;
                case "Scissors":
                    return Move.Rock;
                case "Spock":
                    return Move.Paper;
                    
                case "Lizard":
                    return Move.Rock;
                default:
                    return Move.Spock;
            }



            
        }



        public override string ToString()
        {
            return "David Daniel";
        }


    }

    class AILeaderboard
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        


        public AILeaderboard(string name, int wins)
        {
            name = Name;
            wins = Wins;
        }

    }

}
