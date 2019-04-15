using System;
using System.Collections.Generic;

namespace RPSLS {
    internal class RUAX : StudentAI {
        private readonly Move[] EnemyMoves;
        private int currentEnemyMove = -1;
        private List<Move> enemyMoveSequence;
        private bool listInitialized;

        private int[] moveStartIndexFrequency;
        private readonly int[,] statistics = new int[5, 5];
        private readonly int[,,] statisticsMarkovTwo = new int[5, 5, 5];

        public RUAX() {
            CourseSection = Section.S07250;
            Nickname = "Ruan Xun";
            EnemyMoves = new Move[100];
        }


        public override void Observe(Move opponentMove) {
            EnemyMoves[++currentEnemyMove] = opponentMove;
        }

        public override Move Play() {
            return AgainstMarkovEnemy();
//            return AgainstShakespeare();
        }

        private Move AgainstShakespeare() {
            if (!listInitialized) {
                listInitialized = true;
                enemyMoveSequence = ShakespeareAI.CreateSequence();
                moveStartIndexFrequency = new int[enemyMoveSequence.Count];
            }

            if (currentEnemyMove < 0) return RandomMove();

            for (var i = 0; i < moveStartIndexFrequency.Length; i++)
                if (i + currentEnemyMove < enemyMoveSequence.Count &&
                    enemyMoveSequence[i + currentEnemyMove] == EnemyMoves[currentEnemyMove])
                    moveStartIndexFrequency[i]++;

            var maxIndex = -1;
            var maxTimes = -1;
            for (var i = 0; i < moveStartIndexFrequency.Length; i++)
                if (moveStartIndexFrequency[i] >= maxTimes) {
                    maxTimes = moveStartIndexFrequency[i];
                    maxIndex = i;
                }

            //if (currentEnemyMove == 98) Console.WriteLine("Max times = " + maxTimes);

            if (maxIndex + currentEnemyMove + 1 > enemyMoveSequence.Count - 1) return RandomMove();

            return CounterMove(enemyMoveSequence[maxIndex + currentEnemyMove + 1]);
        }

        private Move AgainstMarkovEnemy() {
// Play against markov one ai
            if (currentEnemyMove <= 0) return RandomMove();

            statistics[(int) EnemyMoves[currentEnemyMove - 1], (int) EnemyMoves[currentEnemyMove]]++;
            var maxIndexMarkovOne = -1;
            var maxTimesMarkovOne = 0;

            var total = 0;
            for (var i = 0; i < 5; i++) {
                total += statistics[(int) EnemyMoves[currentEnemyMove], i];
                if (statistics[(int) EnemyMoves[currentEnemyMove], i] > maxTimesMarkovOne) {
                    maxTimesMarkovOne = statistics[(int) EnemyMoves[currentEnemyMove], i];
                    maxIndexMarkovOne = i;
                }
            }

//            if (currentEnemyMove >= 100) {
//                if ((double) maxTimesMarkovOne / total >= 0.5) return CounterMove((Move) maxIndexMarkovOne);
//            }

            if (currentEnemyMove <= 1) return RandomMove();

            statisticsMarkovTwo[(int) EnemyMoves[currentEnemyMove - 2], (int) EnemyMoves[currentEnemyMove - 1],
                (int) EnemyMoves[currentEnemyMove]]++;
            var maxIndexMarkovTwo = -1;
            var maxMarkovTwoTimes = 0;
            var totalMarkovTwo = 0;
            for (var i = 0; i < 5; i++) {
                totalMarkovTwo += statisticsMarkovTwo[(int) EnemyMoves[currentEnemyMove - 1],
                    (int) EnemyMoves[currentEnemyMove], i];
                if (statisticsMarkovTwo[(int) EnemyMoves[currentEnemyMove - 1], (int) EnemyMoves[currentEnemyMove], i] >
                    maxMarkovTwoTimes) {
                    maxMarkovTwoTimes = statisticsMarkovTwo[(int) EnemyMoves[currentEnemyMove - 1],
                        (int) EnemyMoves[currentEnemyMove], i];
                    maxIndexMarkovTwo = i;
                }
            }

//            if (currentEnemyMove == 98) Console.WriteLine(maxTimesMarkovOne + " " + maxMarkovTwoTimes * 5);
//            if (maxTimesMarkovOne > maxMarkovTwoTimes * 5) {
//                return CounterMove((Move) maxIndexMarkovOne);
//            }
//            else {

            if ((currentEnemyMove > 6 && currentEnemyMove <70) && (double) maxMarkovTwoTimes / totalMarkovTwo >= 0.5)
                return CounterMove((Move) maxIndexMarkovTwo);
            else {
            }
            
            return AgainstShakespeare();
        }

        private Move CounterMove(Move move) {
            switch (move) {
                case Move.Paper:
                case Move.Lizard:
                    return Move.Scissors;
                case Move.Scissors:
                    return Move.Rock;
                default:
                    return Move.Paper;
            }
        }
    }
}