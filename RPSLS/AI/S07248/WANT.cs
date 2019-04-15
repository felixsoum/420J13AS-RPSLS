using System;
using System.Collections.Generic;

namespace RPSLS
{
    class WANT : StudentAI
    {
        List<Move> oppoMove = new List<Move>();
        Move lastMove;
        int sci;
        int rock;
        int pap;
        int spo;
        int liz;
        public WANT()
        {
            Nickname = "Wubu";
            CourseSection = Section.S07248; 
        }

        public override Move Play()
        {
            if (sci>15)
            {
                return Move.Rock;
            }
            else if (rock>15)
            {
                return Move.Spock;
            }
            else if (pap>15)
            {
                return Move.Lizard;
            }
            else if (liz>15)
            {
                return Move.Scissors;
            }
            else if (spo>15)
            {
                return Move.Paper;
            }
            else if (rock+spo>(sci+liz+pap))
            {
                return Move.Paper;
            }
            else if (pap+liz>(rock+spo+sci) )
            {
                return Move.Scissors;
            }
            else if (sci+rock>(pap+liz+spo))
            {
                return Move.Spock;
            }
            else if (spo+pap>(rock+sci+liz))
            {
                return Move.Lizard;
            }
            else if (liz+sci>(spo+pap+rock))
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
            if (opponentMove==Move.Scissors)
            {
                sci++;
                oppoMove.Add(Move.Scissors);
                lastMove = Move.Scissors;
            }
            if (opponentMove == Move.Rock)
            {
                rock++;
                oppoMove.Add(Move.Rock);
                lastMove = Move.Rock;
            }
            if (opponentMove == Move.Paper)
            {
                pap++;
                oppoMove.Add(Move.Paper);
                lastMove = Move.Paper;
            }
            if (opponentMove == Move.Spock)
            {
                spo++;
                oppoMove.Add(Move.Spock);
                lastMove = Move.Spock;
            }
            if (opponentMove == Move.Lizard)
            {
                liz++;
                oppoMove.Add(Move.Lizard);
                lastMove = Move.Lizard;
            }
        }
    }
}
