using System;

namespace RPSLS
{
    class COSJ : StudentAI
    {
        private int[,] markovCount = new int[5, 5];
        private int[,,] markovcountTwo = new int[5, 5, 5];
        private Move _oponentMove;
        private Move _oponentMovePlus;
        private Move _opponentMovePlusPlus;
        private int round = 1;

        public COSJ()
        {
            Nickname = "CosmoBot";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            return MyMove(MarkovOneMove());
        }

        private Move MarkovTwoMove()
        {
            Move chance = Move.Lizard;
            int temp = 0;
            int temp2 = 0;
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                if (temp < markovcountTwo[i, (int)_oponentMove, j])
                {
                    temp = markovcountTwo[i, (int)_oponentMove, j];
                    for (; j < 5; j++)
                    {
                        if (temp2 < markovcountTwo[i, (int)_oponentMove, j])
                        {
                            temp2 = markovcountTwo[i, (int)_oponentMove, j];
                            //To do.
                        }
                    }
                }            
            }
            return RandomMove();
        }

        private Move MarkovOneMove()
        {
            Move chance = Move.Lizard;
            int temp = 0;
            for (int i= 0; i < 5; i++)
            {
                if (temp < markovCount[i, (int)_oponentMove])
                {
                    temp = markovCount[i, (int)_oponentMove];
                    chance = (Move)i;
                }
            }
            return chance;
        }

        public override void Observe(Move opponentMove)
        {
            _opponentMovePlusPlus = _oponentMovePlus;
            _oponentMovePlus = _oponentMove;
            _oponentMove = opponentMove;
            markovCount[(int)opponentMove, (int)_oponentMovePlus]++;
            markovcountTwo[(int)opponentMove, (int)_oponentMovePlus, (int)_opponentMovePlusPlus]++;
        }

        private Move MyMove(Move _spectedMove)
        {
            switch (_spectedMove)
            {
                case Move.Rock:
                    return Move.Paper;

                case Move.Lizard:
                    return Move.Rock;

                case Move.Spock:
                    return Move.Lizard;

                case Move.Scissors:
                    return Move.Spock;

                case Move.Paper:
                    return Move.Scissors;
                default:
                    return Move.Scissors;
            }
        }

        private Move GetWhoBeats(Move move)
        {
            switch (move)
            {
                case Move.Rock:
                    return Move.Lizard;

                case Move.Lizard:
                    return Move.Spock;

                case Move.Spock:
                    return Move.Scissors;

                case Move.Scissors:
                    return Move.Paper;

                case Move.Paper:
                    return Move.Rock;
                default:
                    return Move.Scissors;

            }
        }
    }
}
