using System;
using System.Collections.Generic;

namespace RPSLS
{
    class TAVS : StudentAI
    {
        //Moves enum:
        //      [0] = ROCK
        //      [1] = PAPER
        //      [2] = SCISSORS
        //      [3] = SPOCK
        //      [4] = LIZZARD
        //Shakespare:
        //    case 'e''d''f''b': return Move.Rock;
        //    case 't''h''m''g''x''z': return Move.Paper;
        //    case 'a''r''u''w''k''j': return Move.Scissors;
        //    case 'o''s''l''p''q': return Move.Spock;
        //    case 'i''n''c''y''v': return Move.Lizard;

        public TAVS()
        {
            Nickname = "Origami";
            CourseSection = Section.S07248;
        }
        int[,] arrayList = new int[5, 5];
        //int[,,] arrayList2 = new int[5, 5, 5];
        public List<Move> playerMoveList = new List<Move>();
        Move? prevMove = null;
        public override Move Play()
        {
            if (!prevMove.HasValue)
            {
                return Move.Paper;
            }
            else
            {
                Move favMove = Move.Paper;
                //Move favMove2 = Move.Lizard;
                int maxCount = 1;
                //int maxCount2 = 1;
                if (playerMoveList.Count > 2)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (arrayList[(int)prevMove, j] > maxCount)
                        {
                            favMove = (Move)j;
                            //maxCount2 = maxCount;
                            maxCount = arrayList[(int)prevMove, j];
                            //for (int i = 0; i < 5; i++)
                            //{
                            //    if (arrayList[(int)favMove, i] > maxCount2)
                            //    {
                            //        favMove2 = (Move)i;
                            //        maxCount2 = arrayList2[(int)prevMove, (int)favMove, i];
                            //    }
                            //}
                        }                                     
                    }
                }               
                switch (favMove)
                {
                    case Move.Scissors:
                        //switch (favMove2)
                        //{
                        //    case Move.Scissors:
                        //        return Move.Rock;
                        //    case Move.Lizard:
                        //        return Move.Scissors;
                        //    case Move.Paper:
                        //        return Move.Scissors;
                        //    case Move.Rock:
                        //        return Move.Paper;
                        //    case Move.Spock:
                        //        return Move.Paper;
                        //    default:
                                return Move.Rock;
                        //}
                    case Move.Lizard:
                        //switch (favMove2)
                        //{
                        //    case Move.Scissors:
                        //        return Move.Rock;
                        //    case Move.Lizard:
                        //        return Move.Scissors;
                        //    case Move.Paper:
                        //        return Move.Scissors;
                        //    case Move.Rock:
                        //        return Move.Paper;
                        //    case Move.Spock:
                        //        return Move.Paper;
                        //    default:
                                return Move.Scissors;
                        //}
                    case Move.Paper:
                        //switch (favMove2)
                        //{
                        //    case Move.Scissors:
                        //        return Move.Rock;
                        //    case Move.Lizard:
                        //        return Move.Scissors;
                        //    case Move.Paper:
                        //        return Move.Scissors;
                        //    case Move.Rock:
                        //        return Move.Paper;
                        //    case Move.Spock:
                        //        return Move.Paper;
                        //    default:
                                return Move.Scissors;
                        //}
                    case Move.Rock:
                                //switch (favMove2)
                                //{
                                //    case Move.Scissors:
                                //        return Move.Rock;
                                //    case Move.Lizard:
                                //        return Move.Scissors;
                                //    case Move.Paper:
                                //        return Move.Scissors;
                                //    case Move.Rock:
                                //        return Move.Paper;
                                //    case Move.Spock:
                                //        return Move.Paper;
                                    //default:
                                        return Move.Paper;
                                //}
                            case Move.Spock:
                                //switch (favMove2)
                                //{
                                //    case Move.Scissors:
                                //        return Move.Rock;
                                //    case Move.Lizard:
                                //        return Move.Scissors;
                                //    case Move.Paper:
                                //        return Move.Scissors;
                                //    case Move.Rock:
                                //        return Move.Paper;
                                //    case Move.Spock:
                                //        return Move.Paper;
                                    //default:
                                        return Move.Paper;
                                //}
                            default:
                                return Move.Paper;
                        }
                }
            }
        public override void Observe(Move opponentMove)
        {
            if (prevMove.HasValue)
            {
                arrayList[(int)prevMove, (int)opponentMove]++;
            }
            playerMoveList.Add(opponentMove);
            prevMove = opponentMove;
            //if (playerMoveList.Count > 2) {arrayList2[playerMoveList.Count - 2, (int)prevMove, (int)opponentMove]++;  }
        }
    }
}

