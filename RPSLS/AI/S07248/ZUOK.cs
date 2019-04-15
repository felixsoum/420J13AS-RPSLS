using System;
using System.Collections.Generic;
using System.Collections;

namespace RPSLS
{
    class ZUOK : StudentAI
    {
        public ZUOK()
        {
            Nickname = "KaiWen";
            CourseSection = Section.S07248;
        }
        int[] history = new int[5];
        //count of 
        
        

        public override Move Play()
        {
            //Challenge FavoriteTwoAI
            Move mostMove = Move.Rock;
            Move secondMostMove = mostMove;
            int secondMostMoveCount = history[1];
            int mostMoveCount = history[0];
            for (int i = 0 ; i < 5; i++)
            {
                if (history[i] > mostMoveCount)
                {
                    secondMostMoveCount = mostMoveCount;
                    secondMostMove = mostMove;
                    mostMove = (Move)i;
                    mostMoveCount = history[i];
                }
                else if (history[i] > secondMostMoveCount)
                {
                    secondMostMove = (Move)i;
                    secondMostMoveCount = history[i];
                }
            }
            
            if (mostMove == Move.Rock && secondMostMove == Move.Spock)
            {
                return Move.Paper;
            }
            if (mostMove == Move.Paper && secondMostMove == Move.Lizard)
            {
                return Move.Scissors;
            }
            if (mostMove == Move.Scissors && secondMostMove == Move.Rock)
            {
                return Move.Spock;
            }
            if (mostMove == Move.Spock  && secondMostMove == Move.Paper)
            {
                return Move.Lizard;
            }
            if (mostMove == Move.Lizard && secondMostMove == Move.Scissors)
            {
                return Move.Rock;
            }
            else
            {
                return RandomMove();
            }
        }
        public override void Observe(Move opponentMove)
        {
            history[(int)opponentMove]++;

        }
    }
}
