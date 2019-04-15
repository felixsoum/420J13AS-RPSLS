//<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;

namespace RPSLS
{
    class GRAJ : StudentAI
    {
        int[,,] moveRecord = new int[5,5,5]; // 3dimensional array

        Move? previous = null;
        Move? Secondprevious = null;


        public GRAJ()
        {
            Nickname = "AI McLovin";
            CourseSection = Section.S07250;

        }

        public override Move Play()
        {
            if (!previous.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move greatestMove = Move.Paper;
                int bestMoveCount = -1;

                for(int i = 0; i <5; i++)
                {
                    int count = moveRecord[(int)previous, (int)Secondprevious, i];
                    if(count > bestMoveCount)
                    {
                        greatestMove = (Move)i;
                        bestMoveCount = count;
                    }
                }
                //MyMove(greatestMove);  don't know why I can't use it as a function that 
                //returns a move

                switch (greatestMove)
                {
                    case Move.Rock:
                    case Move.Scissors:
                        return Move.Spock;

                    case Move.Paper:
                    case Move.Lizard:
                        return Move.Scissors;

                    case Move.Spock:
                        return Move.Lizard;
                    default:
                        return Move.Lizard;
                }
            }
        }
       
        public override void Observe(Move botMove)
        {
            if (previous.HasValue)
            {
                moveRecord[(int)previous, (int)Secondprevious, (int)botMove]++;
            }

            previous = Secondprevious;
            Secondprevious = botMove;
        }
      
        public Move MyMove(Move semiPredictedMove)
            {
                switch (semiPredictedMove)
                {
                default:
                return Move.Lizard;

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
    }
}



