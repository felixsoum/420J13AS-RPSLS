using System;
using System.Collections.Generic;
using System.Linq;
namespace RPSLS
{
    class BOLU : StudentAI
    {

        List<Move> poetMove;
        public BOLU()
        {

            Nickname = "Baba is Mittens Two";
            CourseSection = Section.S07049;
            for (int i = 0; i < 5; i++)
            {
                posMoves.Add(new List<int[]>());
                for (int j = 0; j < 5; j++)
                {
                    posMoves[i].Add(new int[5]);
                }
            }
            poetMove = ShakespeareAI.CreateSequence();
        }
        List<Move> opMoves = new List<Move>();
        List<List<int[]>> posMoves = new List<List<int[]>>();
        int turn = 0;
        Move previousMove;
        Move previousBeforeMove;

        Move currentMove;
        bool caughtShake = false;
        int indexShake = -1;
        
        public override void Observe(Move opponentMove)
        {

            if (!caughtShake)
            {
                opMoves.Add(opponentMove);
                turn++;
                currentMove = opponentMove;
                if (turn > 2)
                {
                    posMoves[(int)previousBeforeMove][(int)previousMove][(int)currentMove]++;
                }
                if (turn > 17)
                {
                    for (int i = 17; i < poetMove.Count; i++)
                    {
                        int count = 1;
                        if (poetMove[i] == opponentMove)
                        {
                            for (int j = 1; j < 17; j++)
                            {
                                if (poetMove[i - j] == opMoves[opMoves.Count - 1 - j])
                                {
                                    count++;

                                }

                            }
                            if (count > 11)
                            {
                               // Console.WriteLine("dead at " + turn);
                                caughtShake = true;
                                indexShake = i;
                                break;

                            }
                        }


                    }
                }
            }
            else {

                


            }
        }

        Move myMove;
        Move[,] calculatedMoves = new Move[5, 5];
        Move touch;
        public override Move Play()
        {
            if (caughtShake)
            {
                indexShake++;
               touch = poetMove[indexShake%=poetMove.Count];
               //Console.WriteLine(ShakespeareAI.SonnetXVII[indexShake] + " at " + (indexShake));
                myMove = (Move)(((int)touch + 1) % 5);
                return myMove;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int max = posMoves[i][j].Max();

                    calculatedMoves[i, j] = (Move)Array.FindIndex(posMoves[i][j], a => a == max);
                }

            }
            previousBeforeMove = previousMove;
            previousMove = currentMove;
            if (turn > 2)
            {
                return (Move)(((int)calculatedMoves[(int)previousBeforeMove, (int)currentMove] + 1) % 5);
            }
            else
            {
                return Move.Scissors;
            }
        }

    }
}
