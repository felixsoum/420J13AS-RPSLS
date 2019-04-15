using System;
using System.Collections.Generic;

namespace RPSLS
{
    class GABC : StudentAI
    {
        Move a;
        Move b;
        bool c = false;
        int scissors, spock, paper, rock, lizard = 0;
        List<Move> moves = new List<Move>();
        bool repeatOn = false;

        public GABC()
        {
            Nickname = "Cookies";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return a;
        }

        public override void Observe(Move opponentMove)
        {
            if (!c)
            {
                b = opponentMove;
                c = true;
            }
            if (b != opponentMove)
            {
                switch (opponentMove)
                {
                    case Move.Scissors:
                        a = Move.Scissors;
                        scissors++;
                        break;
                    case Move.Paper:
                        a = Move.Paper;
                        paper++;
                        break;
                    case Move.Rock:
                        a = Move.Rock;
                        rock++;
                        break;
                    case Move.Lizard:
                        a = Move.Lizard;
                        lizard++;
                        break;
                    case Move.Spock:
                        a = Move.Spock;
                        spock++;
                        break;
                }
            }
            else
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        a = Move.Paper;
                        rock++;
                        break;
                    case Move.Paper:
                        paper++;
                        a = Move.Scissors;
                        break;
                    case Move.Scissors:
                        a = Move.Spock;
                        scissors++;
                        break;
                    case Move.Spock:
                        spock++;
                        a = Move.Lizard;
                        break;
                    case Move.Lizard:
                        lizard++;
                        a = Move.Rock;
                        break;
                }
            }

            if (repeatOn == false)
            {
                moves.Add(opponentMove);
            }
            else
            {
                foreach(var move in moves)
                {
                    switch (move)
                    {
                        case Move.Rock:
                            a = Move.Paper;
                            break;
                        case Move.Paper:
                            a = Move.Scissors;
                            break;
                        case Move.Scissors:
                            a = Move.Spock;
                            break;
                        case Move.Spock:
                            a = Move.Lizard;
                            break;
                        case Move.Lizard:
                            a = Move.Rock;
                            break;
                    }
                }
            }

            for (int i = 0; i <= 39; i++)
            {
                if (i >= 20)
                {
                    for (int j = 0; j <= 39; j++)
                    {
                        if (moves.Count > j && moves.Count > i)
                        {
                            if (moves[i] == moves[j])
                            {
                                repeatOn = true;
                            }
                            else
                            {
                                repeatOn = false;
                            }
                        }
                    }
                }
            }

            if (spock > rock && spock > paper && spock > scissors && spock > lizard)
            {
                a = Move.Lizard;
            }
            if (rock > spock && rock > paper && rock > scissors && rock > lizard)
            {
                a = Move.Paper;
            }
            if (paper > rock && paper > spock && paper > scissors && paper > lizard)
            {
                a = Move.Scissors;
            }
            if (scissors > rock && scissors > paper && scissors > spock && scissors > lizard)
            {
                a = Move.Spock;
            }
            if (lizard > spock && lizard > scissors && lizard > paper && lizard > rock)
            {
                a = Move.Rock;
            }
        }
    }
}
