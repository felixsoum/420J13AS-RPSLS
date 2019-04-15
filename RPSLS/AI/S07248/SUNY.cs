
﻿using System;
using System.Collections.Generic;
namespace RPSLS
{
    class SUNY : StudentAI
    {
        int[,,] data = new int[5, 5, 5];
        Move? prev = null;
        List<Move> oppoMove = new List<Move>();
        Move lastMove;
        Move SecondMove = Move.Rock;
        //int sci;
        //int rock;
        //int pap;
        //int spo;
        //int liz;
       

        public SUNY()
        {
            Nickname = "BaBa";
            CourseSection = Section.S07248;
        }

        public override Move Play()
        {
            if (!prev.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move bestMove = Move.Rock;
                int bestCount = -1;
                for (int i = 0; i < 5; i++)
                {
                    int currentCount = data[(int)prev, (int)SecondMove, i];
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
                        default:return Move.Lizard;
                    }
                
            }
              
        }

        public override void Observe(Move opponentMove)
        {
            //if (opponentMove == Move.Scissors)
            //{
            //    sci++;
            //    oppoMove.Add(Move.Scissors);
            //    SecondMove = Move.Scissors;
            //    lastMove = Move.Scissors;
            //}
            //if (opponentMove == Move.Rock)
            //{
            //    rock++;
            //    oppoMove.Add(Move.Rock);
            //    SecondMove = Move.Rock;
            //    lastMove = Move.Rock;
            //}
            //if (opponentMove == Move.Paper)
            //{ 
            //    pap++;
            //    oppoMove.Add(Move.Paper);
            //    SecondMove = Move.Paper;
            //    lastMove = Move.Paper;
            //}

            //if (opponentMove == Move.Lizard)
            //{
            //    liz++;
            //    oppoMove.Add(Move.Lizard);
            //    SecondMove = Move.Lizard;
            //    lastMove = Move.Lizard;
            //}
            //if (opponentMove == Move.Spock)
            //{
            //    spo++;
            //    oppoMove.Add(Move.Spock);
            //    SecondMove = Move.Spock;
            //    lastMove = Move.Spock;
            //}

            if (prev.HasValue)
            {
                data[(int)prev,(int) SecondMove, (int)opponentMove]++;
            }
            prev = SecondMove;
            SecondMove = opponentMove;
        }
    }

   
}

