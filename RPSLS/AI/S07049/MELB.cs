using System;
using System.Collections.Generic;
namespace RPSLS
{
    class MELB : StudentAI
    {
        public MELB()
        {
            Nickname = "Nanith Omicron";
            a = 69420;

            CourseSection = Section.S07049;
        }
        int a = 0;
        int b = 1;
        int c = 0;


        Move counterMove(Move z)
        {
            return (Move)(((int)z + 1) % 5);
        }

        Move[] lol = new Move[5];

        void Season2(Move opponentMove)
        {
            /*switch (c)
   {
       case 1:
           return counterMove(lol[0] - 1);
       case 2:
           return counterMove((Move)rr++ + 1);
       case 3:
           return counterMove(lol[1] + 2);
       default:
           return counterMove(lol[1]);
   }

*/
            for (int i = 1; i < lol.Length; i++)
                lol[i - 1] = lol[i];


            lol[lol.Length - 1] = opponentMove;
            var z = true;
            foreach (var item in lol)
                if (item != Move.Rock) z = false;
            if (z) { c = 3; return; }
            if (b <= 2) return;
            if (((int)lol[0] + (int)lol[1] + (int)lol[2]) / 3 == (int)lol[0]) c = 1;
            if (lol[2] == (counterMove(lol[1])))
                ok++;
            if (ok >= 3) { c = 2; rr = (int)opponentMove; }


        }
        void season3()
        {
            FromPerc();
        }
        int[,,] arr = new int[5, 5,5];
        List<Move> ahah = new List<Move>();
        List<Move> ToCounter = new List<Move>();
        Move mostUse;
        int[] movesagain = new int[5];
        Move FromPerc()
        {


            int[] cca = new int[5];
            foreach (var item in ahah)
                cca[(int)item]++;


            var big = 0;
            for (int i = 0; i < 5; i++)
            {
                if (cca[big] < cca[i])
                    big = i;
            }
            mostUse = (Move)big;
            var e = Game.SeededRandom.Next(0, ahah.Count);
            if (ahah.Count == 45)
            {
                int length = -1;
                for (int x = 20; x < 40; x++)
                {
                    bool f = true;
                    for (int i = 0; i < 6; i++)
                    {
                        if (ahah[i] != ahah[i + x])
                        {
                            f = false;
                            continue;
                        }
                        else if (i == 5)
                            if (f)
                            {
                                length = x;
                                break;
                            }
                    }
                }
                if (length != -1)
                {
                    // Console.WriteLine("=========================== GAMER RISE UP!=================================");
                    c = 1;
                    a = 45 - length;

                    ToCounter.Clear();
                    for (int i = 0; i < length; i++)
                        ToCounter.Add(ahah[i]);

                }
            }
            while (movesagain[(int)ahah[e]] >= 15 && (ahah[e] != mostUse))
            {
                e = Game.SeededRandom.Next(0, ahah.Count);
            }
            return counterMove(ahah[e]);
        }

        Move lasmov,laslasmove;
        public override void Observe(Move opponentMove)
        {
            movesagain[(int)opponentMove]++;
            ahah.Add(opponentMove);
            if (b > 1)
            {
                //arr[(int)lasmov, (int)opponentMove]++;
                arr[(int)laslasmove,(int)lasmov, (int)opponentMove]++;
                laslasmove = ahah[b - 2];
            }
            lasmov = opponentMove;

        }
        int ok = 0;
        int rr = 0;

        Move asimov()
        {

            var ok = new List<Move>();
            var t = 0;
            for (int i = 0; i < 5; i++)
            {

                if (arr[(int)laslasmove, (int)lasmov, t] < arr[(int)laslasmove,(int)lasmov, i]) t = i;
                for (int x = 0; x < arr[(int)laslasmove,(int)lasmov, i]; x++)
                {
                    ok.Add((Move)i);
                }


                /*  if (arr[(int)lasmov, t] < arr[(int)lasmov, i]) t = i;
                for (int x = 0; x < arr[(int)lasmov, i]; x++)
                {
                    ok.Add((Move)i);
                }*/
            }

            /*if (ok.Count < 1)
                return (Move)arr[(int)lasmov, t];*/
           if (ok.Count < 1)
               return (Move)arr[(int)laslasmove,(int)lasmov, t]; 

           else return  ok[Game.SeededRandom.Next(0, ok.Count)];
        }
        List<Move> sonnet = ShakespeareAI.CreateSequence();

        int Indexatlol = 0;
        bool found = false;
        static bool shakespear = false;
        public void Shakespeare()
        {
            var ta = new float[sonnet.Count];
            var ta2 = new float[sonnet.Count];
            IDictionary<int, float> oks = new Dictionary<int, float>();
            if (b != 25) return;
            for (int i = 0; i < sonnet.Count - 1; i++)
            {
               
                if (sonnet[i] == ahah[2])
                    for (int x = 2; i + x < sonnet.Count && x < ahah.Count; x++)
                    {
                        if (sonnet[x + i] == ahah[x])
                            ta[i]++;
                    }
                if (sonnet[i] == ahah[0])
                    for (int x = 0; i + x < sonnet.Count && x < ahah.Count; x++)
                    {
                        if (sonnet[x + i] == ahah[x])
                            ta[i]++;
                    }
                if (sonnet[i] == ahah[1])
                    for (int x = 1; i + x < sonnet.Count && x < ahah.Count; x++)
                    {
                        if (sonnet[x + i] == ahah[x])
                            ta2[i]++;
                    }

                if (ta[i] / ahah.Count > .55f)
                {
                    Console.WriteLine("CHANCE AT INDEX " + i + " EQUALS  " + ta[i] / ahah.Count * 100 + " % on turn " + b);
                    oks.Add(i, ta[i] / ahah.Count);
                }
                if (ta2[i] / ahah.Count > .66f && !oks.ContainsKey(i))
                {
                    Console.WriteLine("CHANCE AT INDEX T2 " + i + " EQUALS  " + ta2[i] / ahah.Count * 100 + " % on turn " + b);
                    oks.Add(i, ta2[i] / ahah.Count);
                }


            }
            
           var eq = new KeyValuePair<int, float>();
            
            foreach (var item in oks)
            {
        
                if (eq.Value < item.Value)
                {
                    eq = item;
                }
           
            }
           Console.WriteLine(eq.Key + " at " + eq.Value * 100 + " %");
            if (eq.Value != 0) {
                found = true;
                Indexatlol = eq.Key;
                shakespear = true;
            }
            
            
            /*       for (int i = 0; i < sonnet.Count; i++)
               {
                       if (ta[i] == 0) continue;

                   ta[i] /= ahah.Count;
                       if (ta[i] < .8f) continue;
                       if(ta[i] == 1)
                   {
                       Indexatlol = i;
                       return;
                   }
                       if(ta[Indexatlol] < ta[i])
                       Indexatlol = i;


               }*/

            /*  if (b == 7)
              for (int i = Indexatlol; i < sonnet.Count-1; i++)
              {
                          if (sonnet[i] == ahah[0])
                              for (int x = 0; x < ahah.Count && (x + i ) < sonnet.Count; x++)
                      {
                          Console.WriteLine(sonnet[i + x] + " vs " + ahah[x] + " on " + i);
                      }

              }*/
        }
        public override Move Play()
        {
            b++;

            if (b == 1) Console.WriteLine("Nanith Omicron: From now on, Alea iacta est. There is little to no random tho. /n");
 
        /*   Shakespeare();
            if (found)
            {
       

                return counterMove(sonnet[(Indexatlol + b -2) % sonnet.Count]);
            }
            if (shakespear && b > 22) return FromPerc();*/
            return counterMove(asimov());

        }


    }
}
