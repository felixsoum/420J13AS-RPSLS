using System;
using System.Collections.Generic;

namespace RPSLS
{
    class VERD : StudentAI
    {
        static Random random = Game.SeededRandom;
        private List<Move> moves = new List<Move>();
        private List<Move> EnnemyMoves = new List<Move>();
        private static List<List<Move>> listMove = new List<List<Move>>();
        private List<AILeaderboard> aILeaderboards = new List<AILeaderboard>();
        private Sequencer sequencer = new Sequencer(0, 0, Move.Rock);
        private List<List<Result>> patterns = new List<List<Result>>();
        private List<Move> felixAiPatternDB = new List<Move>();
        private List<Move> felixAi = new List<Move>();
        private List<string> theArtist = new List<string>();
        private List<Divine> divines = new List<Divine>();
        private List<int> bannedIndexes = new List<int>();
        List<Move> myPlays = new List<Move>();

        int wins = 0;
        int loses = 0;
        int draw = 0;

        int index = 0;
        int fifthIndex = 0;
        int turns;
        int virgilIndex = -1;



        private static Move myLastMove;

        Move overRuleMove;
        Move opMove;
        Move beforeOpMove;
        Move first;
        Move second;
        Move third;
        Move fourth;
        Move fifth;
        Move sixth;
        Move seventh;
        Move eigth;
        Move c1;
        Move c2;
        Move c3;
        Move c4;
        Move c5;
        Move c6;
        Move c7;
        Move c8;
        Move records;
        Move virgil;

        Move olfirst;
        Move olsecond;
        Move olthird;
        Move olFourth;
        Move olFifth;
        Move olSixth;
        Move olSeventh;
        Move olEigth;
        Move oc1;
        Move oc2;
        Move oc3;
        Move oc4;
        Move oc5;
        Move oc6;
        Move oc7;
        Move oc8;
        Move olRecords;
        Move olVirgil;

        public VERD()
        {
            Nickname = "David Daniel";
            CourseSection = Section.S07049;

            listMove.Clear();
            aILeaderboards.Clear();

            aILeaderboards.Add(new AILeaderboard("AFirst", 0));
            aILeaderboards[0].Name = "AFirst";
            aILeaderboards.Add(new AILeaderboard("BSecond", 0));
            aILeaderboards[1].Name = "BSecond";
            aILeaderboards.Add(new AILeaderboard("CThird", 0));
            aILeaderboards[2].Name = "CThird";
            aILeaderboards.Add(new AILeaderboard("DFourth", 0));
            aILeaderboards[3].Name = "DFourth";
            aILeaderboards.Add(new AILeaderboard("EFifth", 0));
            aILeaderboards[4].Name = "EFifth";
            aILeaderboards.Add(new AILeaderboard("FSixth", 0));
            aILeaderboards[5].Name = "FSixth";
            aILeaderboards.Add(new AILeaderboard("GSeventh", 0));
            aILeaderboards[6].Name = "GSeventh";
            aILeaderboards.Add(new AILeaderboard("HEigth", 0));
            aILeaderboards[7].Name = "HEigth";
            aILeaderboards.Add(new AILeaderboard("IC1", 0));
            aILeaderboards[8].Name = "IC1";
            aILeaderboards.Add(new AILeaderboard("JC2", 0));
            aILeaderboards[9].Name = "JC2";
            aILeaderboards.Add(new AILeaderboard("KC3", 0));
            aILeaderboards[10].Name = "KC3";
            aILeaderboards.Add(new AILeaderboard("LC4", 0));
            aILeaderboards[11].Name = "LC4";
            aILeaderboards.Add(new AILeaderboard("MC5", 0));
            aILeaderboards[12].Name = "MC5";
            aILeaderboards.Add(new AILeaderboard("NC6", 0));
            aILeaderboards[13].Name = "NC6";
            aILeaderboards.Add(new AILeaderboard("OC7", 0));
            aILeaderboards[14].Name = "OC7";
            aILeaderboards.Add(new AILeaderboard("PC8", 0));
            aILeaderboards[15].Name = "PC8";
            aILeaderboards.Add(new AILeaderboard("QRecords", 0));
            aILeaderboards[16].Name = "QRecords";
            aILeaderboards.Add(new AILeaderboard("Virgil", 0));
            aILeaderboards[17].Name = "Virgil";
        }

        public override void Observe(Move opponentMove)
        {
            opMove = opponentMove;
        }
        #region Shakespeare
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
        class Divine
        {
            public string Verse { get; set; }
            public int TempCount { get; set; }
            public int Validation { get; set; }



            public Divine(string verse, int tempCount, int validation)
            {
                verse = Verse;
                tempCount = TempCount;
                validation = Validation;


            }

        }
        private Move Virgil()
        {
            string currentJet;
            switch (felixAi[felixAi.Count - 1])
            {
                case Move.Rock:
                    currentJet = "edfb";
                    break;
                case Move.Paper:
                    currentJet = "thmgxz";
                    break;
                case Move.Scissors:
                    currentJet = "aruwkj";
                    break;
                default:
                case Move.Spock:
                    currentJet = "oslpq";
                    break;
                case Move.Lizard:
                    currentJet = "incyv";
                    break;
            }
            theArtist.Add(currentJet);
            if (turns > 5)
            {
                divines.Clear();
                var amateurPeotry = ShakespeareAI.SonnetXVII.ToLower();
                string divineComedy = "";
                foreach (var item in amateurPeotry)
                {
                    if (Char.IsLetter(item))
                    {
                        divineComedy += item;
                    }
                }
                string verse;
                for (int letter = 0; letter < divineComedy.Length - 1; letter++)
                {
                    verse = "";
                    int tempCount = letter;
                    int validationCount = 0;
                    for (int artI = 0; artI < theArtist.Count - 1; artI++)
                    {
                        string test = verse;
                        foreach (var item in theArtist[artI])
                        {
                            if (tempCount > divineComedy.Length - 1)
                            {
                                tempCount -= divineComedy.Length;
                            }
                            if (divineComedy[tempCount] == item)
                            {
                                validationCount++;
                                tempCount++;
                                verse += item;
                                break;
                            }
                        }
                        if (verse == test)
                        {
                            tempCount++;
                        }
                        if (validationCount > (theArtist.Count * .40) & !bannedIndexes.Contains(letter))
                        {
                            divines.Add(new Divine(verse, tempCount, validationCount));
                            divines[divines.Count - 1].Verse = verse;
                            divines[divines.Count - 1].TempCount = tempCount;
                            divines[divines.Count - 1].Validation = validationCount;
                        }
                    }
                }
                divines.Sort((a, b) => (a.Validation.CompareTo(b.Validation)));
                if (divines.Count > 0)
                {
                    int c = divines[divines.Count - 1].TempCount;
                    // Console.WriteLine(divines[divines.Count - 1].Verse);
                    c++;
                    if (c < divineComedy.Length)
                    {
                        char d = divineComedy[c];
                        return choiceC(ShakespeareAI.CharToMove(d));
                    }
                }
            }
            return Move.Rock;
        }

        #endregion
        #region misc
        private Move Records()
        {
            felixAi.Add(opMove);
            return choiceC(Frequent(felixAi));
        }
        private Move PVP1()
        {
            if (turns > 6)
                return choice(MarkovKiller(myPlays));
            else
                return Move.Rock;
        }
        private Move PVP2()
        {
            if (turns > 6)
                return choice(MarkovKiller2(myPlays));
            else
                return Move.Rock;
        }
        private Move MarkovKiller(List<Move> moves)
        {
            if (turns > 3)
            {

                int r = 0;
                int p = 0;
                int sc = 0;
                int l = 0;
                int sp = 0;

                for (int i = 0; i < moves.Count - 1; i++)
                {
                    if (moves[i] == opMove)
                    {

                        switch (moves[i + 1])
                        {
                            case Move.Rock:
                                r++;
                                break;
                            case Move.Paper:
                                p++;
                                break;
                            case Move.Scissors:
                                sc++;
                                break;
                            case Move.Spock:
                                sp++;
                                break;
                            case Move.Lizard:
                                l++;
                                break;
                            default:
                                break;
                        }
                    }

                }
                int[] freq = new int[5];
                freq[0] = r;
                freq[1] = p;
                freq[2] = sc;
                freq[3] = l;
                freq[4] = sp;

                int position = 0;
                int count = 0;
                for (int i = 0; i < freq.Length; i++)
                {
                    //  Console.WriteLine(freq[i]);
                    for (int q = 0; q < freq.Length; q++)
                    {
                        if (count < freq[q])
                        {

                            count = freq[q];
                            position = q;

                        }

                    }

                }
                //   Console.WriteLine(opMove);
                // Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Move move = Move.Rock;
                switch (position)
                {
                    case 0:
                        move = Move.Rock;
                        break;
                    case 1:
                        move = Move.Paper;
                        break;
                    case 2:
                        move = Move.Scissors;
                        break;
                    case 3:
                        move = Move.Lizard;
                        break;
                    case 4:
                        move = Move.Spock;
                        break;
                    default:
                        break;
                }
                return choiceC(move);
            }

            return Move.Rock;
        }
        private Move MarkovKiller2(List<Move> moves)
        {
            if (turns > 1)
            {

                int r = 0;
                int p = 0;
                int sc = 0;
                int l = 0;
                int sp = 0;

                for (int i = 1; i < moves.Count - 1; i++)
                {

                    if (moves[i] == opMove)
                    {
                        if (beforeOpMove == moves[i - 1])
                        {
                            switch (moves[i + 1])
                            {
                                case Move.Rock:
                                    r++;
                                    break;
                                case Move.Paper:
                                    p++;
                                    break;
                                case Move.Scissors:
                                    sc++;
                                    break;
                                case Move.Spock:
                                    sp++;
                                    break;
                                case Move.Lizard:
                                    l++;
                                    break;
                                default:
                                    break;
                            }
                        }

                    }

                }
                int[] freq = new int[5];
                freq[0] = r;
                freq[1] = p;
                freq[2] = sc;
                freq[3] = l;
                freq[4] = sp;

                int position = 0;
                int count = 0;
                for (int i = 0; i < freq.Length; i++)
                {

                    for (int q = 0; q < freq.Length; q++)
                    {
                        if (count < freq[q])
                        {

                            count = freq[q];
                            position = q;

                        }

                    }

                }


                Move move = Move.Rock;
                switch (position)
                {
                    case 0:
                        move = Move.Rock;
                        break;
                    case 1:
                        move = Move.Paper;
                        break;
                    case 2:
                        move = Move.Scissors;
                        break;
                    case 3:
                        move = Move.Lizard;
                        break;
                    case 4:
                        move = Move.Spock;
                        break;
                    default:
                        break;
                }
              //  Console.WriteLine(move+ " " + opMove);
                return choiceC(move);
            }

            return Move.Rock;
        }
        private Move Frequent(List<Move> localMoves)
        {

            int tempCount = 0;
            int count = 1;
            Move frequent = localMoves[0];
            for (int i = 0; i < localMoves.Count; i++)
            {
                Move move = localMoves[i];
                tempCount = 0;
                for (int j = 0; j < localMoves.Count; j++)
                {
                    if (move == localMoves[j])
                    {
                        tempCount++;
                    }
                }
                if (tempCount > count)
                {
                    frequent = move;
                    count = tempCount;
                }
            }
            return frequent;
        }
        private Move TreatData(List<List<Move>> list, int position)
        {

            int rocks = 0;
            int scissors = 0;
            int papers = 0;
            int lizards = 0;
            int spocks = 0;

            foreach (var item in list)
            {

                switch (item[position].ToString())
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
        private Move Sequencer(int len, Move move)
        {
            if (sequencer.Sequence == sequencer.IToDo)
            {
                sequencer.IToDo = len;
                sequencer.Play = move;
                sequencer.Sequence = 0;
            }
            else
                sequencer.Sequence++;

            return sequencer.Play;
        }
        private Move First()
        {
            Move toReturn = Move.Spock;
            toReturn = choice(opMove);


            return toReturn;
        }
        private Move Second()
        {
            Move toReturn = Move.Spock;
            toReturn = TreatData(listMove, index);
            return toReturn;
        }
        private Move Third()
        {
            Move toReturn = opMove;
            return toReturn;
        }
        private Move Fourth()
        {
            Move move = (Move)random.Next(0, 4);
            return Sequencer(4, move);
        }
        private Move Fifth()
        {
            Move toReturn = 0;
            if (turns > 0)
            {
                felixAiPatternDB.Add(opMove);

                if (felixAiPatternDB[fifthIndex] == opMove)
                {
                    //
                    if (felixAiPatternDB.Count > fifthIndex + 1)
                    {
                        toReturn = felixAiPatternDB[fifthIndex + 1];

                        fifthIndex++;
                    }
                    else
                    {
                        fifthIndex = 0;
                    }
                }
                else if (felixAiPatternDB[0] == opMove)
                {
                    fifthIndex = 1;
                }
                else if (felixAiPatternDB[fifthIndex + 1] == opMove)
                {
                    fifthIndex += 1;
                }
                else
                {
                    fifthIndex = 0;
                }
            }

            return choice(toReturn);
        }
        private Move Sixth()
        {
            Move hisMove = choice(myLastMove);
            return choice(opMove) + 2;

        }
        private Move Seventh()
        {
            List<Move> localMoves = new List<Move>();
            localMoves.Add(first);
            localMoves.Add(second);
            localMoves.Add(third);
            localMoves.Add(fourth);
            localMoves.Add(fifth);
            localMoves.Add(sixth);

            Move frequent = Frequent(localMoves);
            return frequent;
        }
        private Move Eigth()
        {
            //Shotgun
            Move moveLocal = Seventh();
            Move toReturn = Sequencer(20, moveLocal);
            return toReturn;
        }
        private Move C1()
        {
            return choiceC(first);

        }
        private Move C2()
        {

            return choiceC(second);

        }
        private Move C3()
        {
            return choiceC(third);
        }
        private Move C4()
        {
            return choiceC(fourth);
        }
        private Move C5()
        {
            return choiceC(fifth);
        }
        private Move C6()
        {
            return choiceC(sixth);
        }
        private Move C7()
        {
            return choiceC(seventh);
        }
        private Move C8()
        {
            return choiceC(eigth);
        }
        #endregion
        private Move Advisers()
        {
            if (turns == 0)
                return Move.Paper;

            aILeaderboards.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            //
            //first = First();
            //aILeaderboards[0].Wins += CheckWin(olfirst);
            //aILeaderboards[0].Play = first;

            //if (wins + loses > 4)
            //{
            //    second = Second();
            //    second = choice(second);
            //    aILeaderboards[1].Wins += CheckWin(olsecond);
            //    aILeaderboards[1].Play = second;

            //}

            //third = Third();
            //aILeaderboards[2].Wins += CheckWin(olthird);
            //aILeaderboards[2].Play = third;

            //fourth = Fourth();
            //aILeaderboards[3].Wins += CheckWin(olFourth);
            //aILeaderboards[3].Play = fourth;
            //////
            //fifth = Fifth();
            //aILeaderboards[4].Wins += CheckWin(olFifth);
            //aILeaderboards[4].Play = fifth;
            ////
            ////sixth = Sixth();
            ////aILeaderboards[5].Wins += CheckWin(olSixth);
            ////aILeaderboards[5].Play = sixth;

            //seventh = Seventh();
            //aILeaderboards[6].Wins += CheckWin(olSeventh);
            //aILeaderboards[6].Play = seventh;

            //eigth = Eigth();
            //aILeaderboards[7].Wins += CheckWin(olEigth);
            //aILeaderboards[7].Play = eigth;


            ////c1 = C1();
            ////aILeaderboards[8].Wins += CheckWin(oc1);
            ////aILeaderboards[8].Play = c1;

            ////c2 = C2();
            ////aILeaderboards[9].Wins += CheckWin(oc2);
            ////aILeaderboards[9].Play = c2;

            ////c3 = C3();
            ////aILeaderboards[10].Wins += CheckWin(oc3);
            ////aILeaderboards[10].Play = c3;

            ////c4 = C4();
            ////aILeaderboards[11].Wins += CheckWin(oc4);
            ////aILeaderboards[11].Play = c4;




            records = Records();
            aILeaderboards[16].Wins += CheckWin(olRecords);
            aILeaderboards[16].Play = records;

            c5 = PVP1();
            aILeaderboards[12].Wins += CheckWin(oc5);
            aILeaderboards[12].Play = c5;

            c6 = PVP2();
            aILeaderboards[13].Wins += CheckWin(oc6);
            aILeaderboards[13].Play = c6;

            c8 = MarkovKiller(felixAi);
            aILeaderboards[15].Wins += CheckWin(oc8);
            aILeaderboards[15].Play = c8;

            c7 = MarkovKiller2(felixAi);
            aILeaderboards[14].Wins += CheckWin(oc7);
            aILeaderboards[14].Play = c7;




            virgil = Virgil();
            aILeaderboards[17].Wins += CheckWin(olVirgil);
            aILeaderboards[17].Play = virgil;



            aILeaderboards.Sort((a, b) => (a.Wins.CompareTo(b.Wins)));

            olfirst = first;
            olsecond = second;
            olthird = third;
            olFourth = fourth;
            olFifth = fifth;
            olSixth = sixth;
            olSeventh = seventh;
            olEigth = eigth;
            oc1 = c1;
            oc2 = c2;
            oc3 = c3;
            oc4 = c4;
            oc5 = c5;
            oc6 = c6;
            oc7 = c7;
            oc8 = c8;
            olRecords = records;
            olVirgil = virgil;

            //debug scores

            //foreach (var item in aILeaderboards)
            //{
            //    Console.WriteLine(" algorithm name : " + item.Name + ", algorithm wins :" + item.Wins + "  Mine " + item.Play + " , his : " + opMove);
            //}

            //Console.WriteLine("_________________________________________________________________________________________" + aILeaderboards[aILeaderboards.Count - 1].Name + "---");

            ////

            // in case of tie

            if (aILeaderboards[aILeaderboards.Count - 1].Wins == aILeaderboards[aILeaderboards.Count - 2].Wins)
            {
                List<Move> localMoves = new List<Move>();
                foreach (var item in aILeaderboards)
                {
                    if (item.Wins == aILeaderboards[aILeaderboards.Count - 1].Wins)
                    {
                        localMoves.Add(item.Play);
                    }
                }
                return Frequent(localMoves);
            }

            //

            switch (aILeaderboards[aILeaderboards.Count - 1].Name)
            {
                case "AFirst":
                    return first;
                case "BSecond":
                    return second;
                case "CThird":
                    return third;
                case "DFourth":
                    return fourth;
                case "EFifth":
                    return fifth;
                case "FSixth":
                    return sixth;
                case "GSeventh":
                    return seventh;
                case "HEigth":
                    return seventh;
                case "IC1":
                    return c1;
                case "JC2":
                    return c2;
                case "KC3":
                    return c3;
                case "LC4":
                    return c4;
                case "MC5":
                    return c5;
                case "NC6":
                    return c6;
                case "OC7":
                    return c7;
                case "PC8":
                    return c8;
                case "QRecords":
                    return records;
                case "Virgil":
                    return virgil;
                default:
                    return first;
            }

        }
        private int CheckWin(Move move)
        {
            switch (move.CompareWith(opMove))
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

        private bool UseSpockTooMany(List<Move> moves)
        {
            int rocks = 0;
            int papers = 0;
            int scissors = 0;
            int spocks = 0;
            int lizards = 0;
            foreach (var item in moves)
            {
                switch (item.ToString())
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
            if ((spocks + lizards) / (papers + rocks + scissors) > 0.5)
            {
                return true;
            }
            else
                return false;

        }

        public override Move Play()
        {
            aILeaderboards.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            EnnemyMoves.Add(opMove);
            if (turns > 1)
            {
                beforeOpMove = EnnemyMoves[EnnemyMoves.Count - 2];
            }

            if (moves.Count < 4)
            {
                moves.Add(opMove);
                listMove.Add(moves);
            }
            else
            {
                listMove.Add(moves);
                moves.Clear();
                moves.Add(opMove);
                index = 0;
            }
            if (index == 4)
            {
                index = 3;
            }

            //FELIX 
            switch (myLastMove.CompareWith(opMove))
            {
                case 0:
                    draw++;
                    break;
                case 1:
                    wins++;
                    break;
                case -1:
                    loses++;
                    break;
            }


            overRuleMove = Advisers();

            aILeaderboards.Sort((a, b) => (a.Wins.CompareTo(b.Wins)));

            index++;

            myLastMove = overRuleMove;



            turns++;
            //if (turns == 100)
            //{
            //    Console.WriteLine("won : " + wins + ", lost : " + loses + ", draws : " + draw);
            //    aILeaderboards.Sort((a, b) => (a.Wins.CompareTo(b.Wins)));
            //    foreach (var item in aILeaderboards)
            //    {
            //        Console.WriteLine(" algorithm name : " + item.Name + ", algorithm wins :" + item.Wins);
            //    }

            //    Console.WriteLine("_________________________________________________________________________________________" + aILeaderboards[aILeaderboards.Count - 1].Name + "--- " + " ---");
            //}
            ////Console.WriteLine(" my move " +overRuleMove + " his last " + opMove);
            myPlays.Add(overRuleMove);
            return overRuleMove;
        }

        private Move choice(Move OppMove)
        {
            string a = OppMove.ToString();
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
        private Move choiceC(Move OppMove)
        {
            string a = OppMove.ToString();
            switch (a)
            {
                case "Rock":
                    return Move.Spock;
                case "Paper":
                    return Move.Lizard;
                case "Scissors":
                    return Move.Spock;
                case "Spock":
                    return Move.Lizard;

                case "Lizard":
                    return Move.Scissors;
                default:
                    return Move.Lizard;
            }
        }

        public override string ToString()
        {
            return "David Daniel";
        }

    }
    class Sequencer
    {
        public int Sequence { get; set; }
        public int IToDo { get; set; }
        public Move Play { get; set; }

        public Sequencer(int sequence, int iToDo, Move play)
        {
            sequence = Sequence;
            iToDo = IToDo;
            play = Play;
        }
    }
    class AILeaderboard
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public Move Play { get; set; }

        public AILeaderboard(string name, int wins, Move play = Move.Rock)
        {
            name = Name;
            wins = Wins;
            play = Play;
        }

    }

}
