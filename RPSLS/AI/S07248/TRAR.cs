using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace RPSLS
{
    class TRAR : StudentAI
    {
        //rock beats lizard and scissor
        //paper beats rock and spock
        //scissor beats paper and lizard
        //lizard beats paper and spock
        //spock beats scissor and rock

        //string aligment
        //marvo chain
        
        int[,] data = new int[5, 5];


        Move? prev = null;
        Move? secondPrev = null;
        int[,,] dataOne = new int[5, 5, 5];


        private Move? lastMove = null;
        //private Move[] caseCircle = new Move[] { Move.Scissors, Move.Paper, Move.Rock, Move.Lizard, Move.Spock };
        private Move[] caseRock = new Move[] { Move.Rock, Move.Rock, Move.Rock, Move.Rock, Move.Rock };
        private Move[] casePaper = new Move[] { Move.Paper, Move.Paper, Move.Paper, Move.Paper, Move.Paper };
        private Move[] caseScissor = new Move[] { Move.Scissors, Move.Scissors, Move.Scissors, Move.Scissors, Move.Scissors };
        private Move[] caseLizard = new Move[] { Move.Lizard, Move.Lizard, Move.Lizard, Move.Lizard, Move.Lizard };
        private Move[] caseSpock = new Move[] { Move.Spock, Move.Spock, Move.Spock, Move.Spock, Move.Spock };
        private Move[] counterAtk = new Move[] { Move.Rock, Move.Paper, Move.Scissors, Move.Spock, Move.Lizard };
        private Move[] emptyMove = new Move[5];
        private Move[] testArray = new Move[10];


        private Dictionary<Move, int> counting = new Dictionary<Move, int>();
        private int rock = 0;
        private int paper = 0;
        private int scissor = 0;
        private int spock = 0;
        private int lizard = 0;
        private int bigestNumber = 0;
        private int secondNumber = 0;
        private int difference = 0;
        private int secondBigest = 0;
        private int[] countOfEach = new int[] { 0, 0, 0, 0, 0 };
        int secondArray = 0;
        private Move[] deux = new Move[5];
        private List<Move> secondList = new List<Move>();
        private List<Move> empty = new List<Move>();
        int moveIndex = 2;
        int switchMove = 0;
        int[] nombre = new int[5];
        bool firstAI;
        bool secondAI;
        int checking = 0;
        int position = 0;
        int rai = 0;
        int county = 0;
        bool SuperAI = false;
        int repeatCount;
        int repeatIndex;
        int g = 0;
        List<Move> movePattern = new List<Move>();

        List<Move> moves = new List<Move>();
        int index;
        //Dictionary<Move, Move> winning = new Dictionary<Move, Move>();
        int ww = 0;
        bool checkOnce = false;

        int counter = 0;
        int o = 0;


        public TRAR()
        {
            Nickname = "Robert";
            CourseSection = Section.S07248;

      


            
        }


        public override void Observe(Move opponentMove)
        {

            if (prev.HasValue)
            {
                data[(int)prev, (int)opponentMove]++;

                //dataOne[(int)prev, (int)secondPrev, (int)opponentMove]++;

            }

            prev = opponentMove;
            //secondPrev = prev;





            nombre[(int)opponentMove]++;


            switch (opponentMove)
            {
                case Move.Rock:
                    rock++;
                    break;
                case Move.Paper:
                    paper++;
                    break;
                case Move.Scissors:
                    scissor++;
                    break;
                case Move.Spock:
                    spock++;
                    break;
                case Move.Lizard:
                    lizard++;
                    break;
            }
            countOfEach[0] = rock;
            countOfEach[1] = paper;
            countOfEach[2] = scissor;
            countOfEach[3] = spock;
            countOfEach[4] = lizard;

            InsertionSortDescending(countOfEach);

            bigestNumber = countOfEach[0];
            secondNumber = countOfEach[1];





            lastMove = opponentMove;
            empty.Add(opponentMove);


        }

      



        public static void InsertionSortDescending(int[] A)
        {
            for (int j = 1; j <= A.Length - 1; j++)
            {
                int key = A[j];
                int i = j - 1;
                while (i > -1 && A[i] < key)
                {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = key;
            }
        }



        public static bool HalfList(List<Move> x)
        {

            int half = (x.Count / 2);
            if (x.TrueForAll(i => i.Equals(x.FirstOrDefault())))
            {
                return false;
            }


            for (int i = 0; i < half; i++)
            {
                if (x[i] != x[i + 5])
                {
                    return false;
                }
            }
            return true;
        }


        public static int Index(List<Move> x)
        {
            for (int i = 0; i <= 19; i++)
            {
                if (x[0] == x[i + 20] && x[1] == x[i + 21] && x[2] == x[i + 22] && x[3] == x[i + 23])
                {
                    return (i + 20);
                }

            }
            return 0;
        }


        public static bool PatternCheck(List<Move> x)
        {
         
            for (int i = 0; i <= 19; i++)
            {
                if (x[0] == x[i + 20] && x[1] == x[i+21] && x[2] == x[i+22] && x[3] == x[i + 23])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkForCir(List<Move> x)
        {
            if (x.Contains(Move.Scissors))
            {
                int num = x.IndexOf(Move.Scissors);
                if (num < 4)
                {
                    if (x[num + 1] != Move.Paper)
                    {
                        return false;
                    }

                }
                if (num == 4)
                {
                    if (x[0] != Move.Paper && x[1] != Move.Rock)
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        public static bool listCheck(List<Move> x, List<Move> y)
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }




        public static bool compareArray(Move[] x, Move[] y)
        {
            // return x.Count() == y.Count() && x.Intersect(y).Any();
            // Check count
            if (x.Count() != y.Count())
            {
                return false;
            }
            Array.Sort(x);
            Array.Sort(y);
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }









        public override Move Play()
        {

            if (empty.Count > 42)
            {


                Move bestMove = Move.Rock;
                int bestCount = -1;

            

                for (int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)prev, i];
                    if (currentCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currentCount;
                    }
                }




                switch (bestMove)
                {
                    case Move.Rock:
                    case Move.Scissors:
                        return Move.Spock;
                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;
                    case Move.Spock:
                        return Move.Lizard;


                }


                //if (HalfList(empty))
                //{
                //    Move opp = empty[checking];
                //    checking++;
                //    switch (opp)
                //    {
                //        case Move.Rock:
                //        default:
                //            return Move.Rock;

                //        case Move.Paper:
                //            return Move.Paper;

                //        case Move.Scissors:
                //            return Move.Scissors;

                //        case Move.Spock:
                //            return Move.Spock;

                //        case Move.Lizard:
                //            return Move.Lizard;
                //    }
                //}

                //Console.WriteLine(PatternCheck(empty));
                //if (PatternCheck(empty))
                //{

                //    // Console.WriteLine(Index(empty));
                //    // int k = 40 - position;
                //    if (!checkOnce)
                //    {
                //        checkOnce = true;
                //       // Console.WriteLine(Index(empty));
                //        ww = 42 - Index(empty);
                        
                //    }
                //    //Console.WriteLine(ww);
                //    Move op = empty[++ww];
                                                                           
                //    switch (op)
                //    {
                //        case Move.Rock:
                //        default:
                //            return Move.Paper;

                //        case Move.Paper:
                //            return Move.Rock;

                //        case Move.Scissors:
                //            return Move.Rock;

                //        case Move.Spock:
                //            return Move.Paper;

                //        case Move.Lizard:
                //            return Move.Scissors;
                //    }
                //}

                //paper beats rock and spock
                //scissor beats paper and lizard
                //spock beats scissor and rock
                //lizard beats paper and spock
                //rock beats lizard and scissor

                if (bigestNumber == rock && secondNumber == spock || bigestNumber == spock && secondNumber == rock)
                {
                    return Move.Paper;
                }
                if (bigestNumber == paper && secondNumber == lizard || bigestNumber == lizard && secondNumber == paper)
                {
                    return Move.Scissors;
                }
                if (bigestNumber == scissor && secondNumber == rock || bigestNumber == rock && secondNumber == scissor)
                {
                    return Move.Spock;
                }
                if (bigestNumber == paper && secondNumber == spock || bigestNumber == spock && secondNumber == paper)
                {
                    return Move.Lizard;
                }
                if (bigestNumber == lizard && secondNumber == scissor || bigestNumber == scissor && secondNumber == lizard)
                {
                    return Move.Rock;
                }
                if (bigestNumber == rock || bigestNumber == spock)
                {
                    return Move.Paper;
                }
                if (bigestNumber == paper || bigestNumber == lizard)
                {
                    return Move.Scissors;
                }
                if (bigestNumber == scissor)
                {
                    return Move.Rock;
                }
                else
                {
                    return RandomMove();
                }


            }
            else
            {
                return RandomMove();
            }
        }
    }
}
