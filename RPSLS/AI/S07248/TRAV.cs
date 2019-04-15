using System;
using System.Collections.Generic;

namespace RPSLS
{
    class TRAV : StudentAI
    {
        //rock beats lizard and scissor
        //paper beats rock and spock
        //scissor beats paper and lizard
        //lizard beats paper and spock
        //spock beats scissor and rock

        int[,] data = new int[5, 5];
        Move? prev = null;
        //int[] history = new int[5];
        //int rCounter = 0;
        //int pCounter = 0;
        //int scCounter = 0;
        //int lCounter = 0;
        //int spCounter = 0;
        //int mostplayedcount = 0;
        //int secondmostplayedcount = 0;

        public TRAV()
        {
            Nickname = "minecraftplayer";
            CourseSection = Section.S07248;
        }


        //public static void Sorting(int[] A)
        //{
        //    for (int j = 1; j <= A.Length - 1; j++)
        //    {
        //        int key = A[j];
        //        int i = j - 1;
        //        while (i > -1 && A[i] < key)
        //        {
        //            A[i + 1] = A[i];
        //            i--;
        //        }
        //        A[i + 1] = key;
        //    }
        //}


        public override Move Play()
        {
            Move bestMove = Move.Rock;
            int bestCount = -1;
            if (prev.HasValue)
            {

                for (int i = 0; i < 5; i++)
                {
                    int currCount = data[(int)prev, i];
                    if (currCount > bestCount)
                    {
                        bestMove = (Move)i;
                        bestCount = currCount;
                    }
                }

            }
            switch (bestMove)
            {
                default:
                case Move.Rock:
                case Move.Scissors:
                    return Move.Spock;
                case Move.Paper:
                case Move.Lizard:
                    return Move.Scissors;
                case Move.Spock:
                    return Move.Lizard;
                
            }
        }

        public override void Observe(Move opponentMove)
        {
            if (prev.HasValue)
            {
                data[(int)prev, (int)opponentMove]++;
            }
            prev = opponentMove;
        }
    }
}