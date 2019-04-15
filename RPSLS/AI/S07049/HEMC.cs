using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class HEMC : StudentAI
    {
        #region Variables.
        //Variables.//
        private const int ROCK = 0;
        private const int PAPER = 1;
        private const int SCISSORS = 2;
        private const int SPOCK = 3;
        private const int LIZARD = 4;
        private const int HIGHESTVALUE = 5;

        int[] ResultPrevMove = new int[5];
        List<int> AllMoves = new List<int>();

        int[][] move = new int[5][] //Thanks Alonso.//
        {
            new int[5],
            new int[5],
            new int[5],
            new int[5],
            new int[5]
        };

        private int previousMove;

        #endregion
        public HEMC()
        {
            Nickname = "The Leprauchaun 3.0";
            CourseSection = Section.S07049;
        }

        public override void Observe(Move opponentMove)
        {
            move[previousMove][(int)opponentMove]++; //Automatically adds each previous move to the corresponding index.//
            AllMoves.Add((int)opponentMove); //Fill in results - List//
            ResultFill((int)opponentMove); //Fill in results - Array[5]//

            previousMove = (int)opponentMove;
        }

        #region Results
        private int MostPlayedResult()
        {
            return Array.IndexOf(ResultPrevMove, ResultPrevMove.Max()); //Finds the highest array and returns the index of the highest one.//
        }

        private void ResultFill(int prevMove) //Increases each the value of each index corresponding to a move played.//
        {
            switch (prevMove)
            {
                case ROCK: ResultPrevMove[ROCK]++;
                    break;

                case PAPER: ResultPrevMove[PAPER]++;
                    break;

                case SCISSORS: ResultPrevMove[SCISSORS]++;
                    break;

                case SPOCK: ResultPrevMove[SPOCK]++;
                    break;

                case LIZARD: ResultPrevMove[LIZARD]++;
                    break;
            }
        }
        #endregion

        public override Move Play()
        {
            //return indexPlay(MostPlayedResult()); //Return the move played result to the index.//
            return (Move)MarkovTest();
        }

        #region Plays
        private Move indexPlay(int indexMove) //Depending on which move that's the most played, will play against that move.//
        {
            switch (indexMove)
            {
                case ROCK: return RockMove();
                case PAPER: return PaperMove();
                case SCISSORS: return ScissorsMove();
                case SPOCK: return SpockMove();
                case LIZARD: return SpockMove();

                default: return RandomMove();
            }
        }

        private Move RandomPlays(Move move1, Move move2) { return Game.SeededRandom.NextDouble() > 0.5 ? move1 : move2; } //Thank you Felix.// //Plays against the other move randomly against its 2 weaknessess.//

        private Move SpockMove() { return RandomPlays(Move.Paper, Move.Lizard); }
        private Move LizardMove() { return RandomPlays(Move.Scissors, Move.Rock); }
        private Move ScissorsMove() {return RandomPlays(Move.Rock, Move.Spock); }
        private Move PaperMove() { return RandomPlays(Move.Scissors, Move.Lizard); }
        private Move RockMove() { return RandomPlays(Move.Paper, Move.Spock); }

        #endregion
        private int MarkovTest()
        {
            int Move = Array.IndexOf(move[previousMove], move[previousMove].Max());
            Move++;

            if(Move == HIGHESTVALUE)
            {
                Move -= HIGHESTVALUE;
            }

            return Move;
        }

    }
}
