using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RPSLS
{
    class SLAC : StudentAI
    {


        bool printedLast20 = false;

        Move nextToPlay = Move.Rock;

        Move? b = null;
        

        Move?[] prevMoves = new Move?[40];

        int[,,] intarray = new int[5, 5, 5];
        
        int firpos;

        int secpos;
        //shakespeare
        List<Move> movePattern = new List<Move>();

        bool isShakespeare = false;

        bool sonnetSequenced = false;

        int totalGames;

        int located;

        int correctlinks = 0;
       
        public const string SonnetXVII = @"
    Who will believe my verse in time to come,
    If it were filled with your most high deserts?
    Though yet heaven knows it is but as a tomb
    Which hides your life, and shows not half your parts.
    If I could write the beauty of your eyes,
    And in fresh numbers number all your graces,
    The age to come would say 'This poet lies;
    Such heavenly touches ne'er touched earthly faces.'
    So should my papers, yellowed with their age,
    Be scorned, like old men of less truth than tongue,
    And your true rights be termed a poet's rage
    And stretched metre of an antique song:
    But were some child of yours alive that time,
    You should live twice, in it, and in my rhyme.
    ";

        public SLAC()
        {
            Nickname = "awesome possum";
            CourseSection = Section.S07248;
        }

        void SequenceSonnet()
        {
            for (int p = 0; p < 2; p++)
            {
                foreach (char v in SonnetXVII)
                {
                    if (v >= 'A' && v <= 'z')
                    {
                        movePattern.Add(CharToMove(v));
                    }
                }
            //Console.WriteLine("Movepattern size: " + movePattern.Count);
            }
        }



        public static Move CharToMove(char c)
        {
           
            switch (char.ToLower(c))
            {
                case 'e':
                case 'd':
                case 'f':
                case 'b':
                    return Move.Rock;
                case 't':
                case 'h':
                case 'm':
                case 'g':
                case 'x':
                case 'z':
                    return Move.Paper;
                case 'a':
                case 'r':
                case 'u':
                case 'w':
                case 'k':
                case 'j':
                    return Move.Scissors;
                default:
                case 'o':
                case 's':
                case 'l':
                case 'p':
                case 'q':
                    return Move.Spock;
                case 'i':
                case 'n':
                case 'c':
                case 'y':
                case 'v':
                    return Move.Lizard;
            }
        }

            Move CounterPick2(int x, int y)
        {
           
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 2:
                            return Move.Spock;
                            break;
                        case 3:
                            return Move.Paper;
                            break;
                        default:
                            return Move.Paper;
                            break;
                    }
                    break;

                case 1:
                    switch (y)
                    {
                        case 3:
                            return Move.Lizard;
                            break;
                        case 4:
                            return Move.Scissors;
                            break;
                        default:
                            return Move.Scissors;
                            break;
                    }
                    break;

                case 2:
                    switch (y)
                    {
                        case 4:
                            return Move.Rock;
                            break;
                        case 0:
                            return Move.Spock;
                            break;
                        default:
                            return Move.Spock;
                            break;
                    }
                    break;

                case 3: //rock, paper scissors spock lizard
                    switch (y)
                    {
                        case 0:
                            return Move.Paper;
                            break;
                        case 1:
                            return Move.Lizard;
                            break;
                        default:
                            return Move.Lizard;
                            break;
                    }
                    break;

                case 4: //rock, paper scissors spock lizard
                    switch (y)
                    {
                        case 1:
                            return Move.Scissors;
                            break;
                        case 2:
                            return Move.Rock;
                            break;
                        default:
                            return Move.Rock;
                            break;
                    }
                    break;

                default:
                    return Move.Rock;
                    break;
            }
        }

       


        public override Move Play()
        {


            if (!isShakespeare)
            {
                if (prevMoves[0].HasValue && prevMoves[1].HasValue)
                {


                    int highestNum = -1;

                    int secondHighestNum = -1;

                    for (int i = 0; i < 5; i++)
                    {
                        if (intarray[(int)prevMoves[1], (int)prevMoves[0], i] > highestNum)
                        {
                            highestNum = intarray[(int)prevMoves[1], (int)prevMoves[0], i];
                            firpos = i; 
                        }
                    }

                    for (int j = 0; j < 5; j++)
                    {
                        if (intarray[(int)prevMoves[1], (int)prevMoves[0], j] > secondHighestNum && highestNum != intarray[(int)prevMoves[1], (int)prevMoves[0], j])
                        {
                            secondHighestNum = intarray[(int)prevMoves[1], (int)prevMoves[0], j];
                            secpos = j;
                        }
                    }

                }

                nextToPlay = CounterPick2(firpos, secpos);



            }
            else
            {

               
                if (located < 500)
                {
                    nextToPlay = CounterPick2((int)movePattern[located], 0);
                    located++;
                }
                else
                {
                    nextToPlay = CounterPick2((int)movePattern[located], 0);
                    located = 0;
                }

            }
            
            if(totalGames == 0)
            {
                nextToPlay = Move.Rock;
            }
            if (totalGames == 1)
            {
                nextToPlay = Move.Lizard;
            } else if (totalGames == 2)
            {
                nextToPlay = Move.Rock;
            }
            return nextToPlay;
        }

        public override void Observe(Move opponentMove)
        {

            if (prevMoves[0].HasValue && prevMoves[1].HasValue)
            {
                intarray[(int)prevMoves[1], (int)prevMoves[0], (int)opponentMove]++;
            }

            totalGames++;
            

            if (!sonnetSequenced)
            {
                SequenceSonnet();
                sonnetSequenced = true;
            }

            if (totalGames > prevMoves.Length)
            {
                


                for (int m = (prevMoves.Length - 1); m < movePattern.Count; m++)
                {
                    correctlinks = 0;
                    for (int x = 0;  x <= (prevMoves.Length - 2); x++)
                    {
                        if (movePattern[m - (x + 1)] == prevMoves[x])
                        {
                            correctlinks++;
                        }
                    }

                    
                    if (movePattern[m] == opponentMove)
                    {
                        correctlinks++;
                    } 

                    if (!isShakespeare && correctlinks > 19)
                    {
                        isShakespeare = true;
                        located = m + 1;
                       
                    }
                }
            } 

            


            
            for (int i = (prevMoves.Length - 2); i >= 0; i--)
            {
               prevMoves[i + 1] = prevMoves[i];
            }


            
            prevMoves[0] = opponentMove;
            
        }
    }
}