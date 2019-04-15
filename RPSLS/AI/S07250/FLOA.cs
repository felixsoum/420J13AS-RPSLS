using System;
using System.Collections.Generic;

namespace RPSLS
{
    class FLOA : StudentAI
    {
        int[,,] markovData = new int[5, 5, 5];
        int counter = -1;

        List<Move> pastMoves = new List<Move>();
        Move currentMove = Move.Rock;
        Move nextMove = Move.Rock;

        public FLOA()
        {
            Nickname = "Sora";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            Move outPutMove = Move.Spock;
            int bestCount = -1;
            int currentCount = 0;

            for (int i = 0; i < 5; i++)
            {
                if (pastMoves.Count > 3)
                {
                    currentCount = markovData[(int)pastMoves[counter - 1], (int)currentMove, i];

                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        nextMove = (Move)i;
                    }
                }
            }

            switch (nextMove)
            {
                case Move.Rock:
                case Move.Scissors:
                    outPutMove = Move.Spock;
                    break;
                case Move.Paper:
                case Move.Lizard:
                    outPutMove = Move.Scissors;
                    break;
                case Move.Spock:
                    outPutMove = Move.Paper;
                    break;
            }

            counter++;
            return outPutMove;
        }

        public override void Observe(Move opponentMove)
        {
            currentMove = opponentMove;
            pastMoves.Add(currentMove);

            if (pastMoves.Count > 3)
                RecordData(pastMoves[counter - 2], pastMoves[counter - 1], currentMove);      
        }

        public void RecordData(Move pastPastMove, Move pastMove, Move currentMove)
        {
            markovData[(int)pastPastMove, (int)pastMove, (int)currentMove]++;
        }
    }
}