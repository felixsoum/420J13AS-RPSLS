/// <summary>
/// Author: Alexanre Lepage
/// Date: 22 Feb 2019
/// College LaSalle
/// </summary>

using System;
using System.Collections.Generic;

namespace RPSLS
{

    class LEPA : StudentAI
    {
        /*
         * Rock, 0
         * Paper, 1
         * Scissors, 2
         * Spock, 3
         * Lizard, 4
         */

        public const string SonnetXVII = @"
        Who will believe my verse in time to come,
        If it were filled with your most high deserts?
        Though yet heaven knows it is but as a tomb
        Which hides your life, and shows not half your parts.
        If I could write the beauty of your eyes,
        And in fresh numbers number all your graces,
        The age to come would say 'This poet lies;
        Such heavenly touches ne'er touched earthly faces.'
        So should my papers, yellowed with their age,
        Be scorned, like old men of less truth than tongue,
        And your true rights be termed a poet's rage
        And stretched metre of an antique song:
        But were some child of yours alive that time,
        You should live twice, in it, and in my rhyme.
        ";

        private Random myRand = Game.SeededRandom;

        private Move chosenMove;
        List<Move> opponentMoves = new List<Move>();
        List<Move> playerMoves = new List<Move>();
        Move lastplayedMove;
        Move opponentLastplayedMove;
        Move opponentSecondLastplayedMove;
        Move opponentFavMove;
        Move opponentFavMove2;
        int opponentLastplayedMoveAgain = 0;
        float[] movePercentages = new float[5];
        int[] moveQty = new int[5];
        float[] playermovePercentages = new float[5];
        int[] playermoveQty = new int[5];
        static int version = 0;

        int[] movesOrder = new int[] { 0, 3, 1, 4, 2 };
        int movesQueueIndex = 0;
        bool inQueue = true;

        bool wonLast = false;
        int qtyWon = 0;
        int qtyLost = 0;
        int wonInRow = 0;
        int lostInRow = 0;
        int playedGames = 0;

        public static string opponentSequence = string.Empty;
        string opponentSequence2 = string.Empty;
        int sequenceIndex = 0;
        private bool inSquence;

        public LEPA()
        {
            opponentSequence = string.Empty;
            version++;
            Nickname = $"GrisWold Diablo";// {version%2}";
            CourseSection = Section.S07250;
            
        }

        static LEPA()
        {
            ConvertSS();
        }

        // Shakespeare
        private string ssOpSeq = string.Empty;
        public static string ssConverted = string.Empty;

        public void RecordShakespeare(Move playedMove)
        {
            ssOpSeq += (int)playedMove;
        }

        public int FindSS()
        {
            int highestIndex = 0;
            int highestValue = 0;

            if (ssOpSeq.Length >= 0)
            {
                for (int i = 0; i < ssConverted.Length; i++)
                {
                    int value = 0;
                    for (int j = 0; j < ssOpSeq.Length; j++)
                    {
                        if ((i + j < ssConverted.Length ? ssConverted[i + j] : ssConverted[i + j - ssOpSeq.Length]) == ssOpSeq[j])
                        {
                            value++;
                        }
                    }

                    if (highestValue < value)
                    {
                        highestValue = value;
                        highestIndex = i + ssOpSeq.Length;
                        if (highestIndex >= ssConverted.Length)
                        {
                            highestIndex -= ssConverted.Length;
                        }
                    }
                } 
            }
            return highestIndex;
        }

        static public void ConvertSS()
        {
            foreach (var item in SonnetXVII)
            {
                if (item >= 'A' && item <= 'z')
                {
                    ssConverted += (int)CharToMove(item);
                }
            }
        }

        public static Move CharToMove(char c)
        {
            switch (char.ToLower(c))
            {
                case 'e':
                case 'd':
                case 'f':
                case 'b':
                    return Move.Rock;
                case 't':
                case 'h':
                case 'm':
                case 'g':
                case 'x':
                case 'z':
                    return Move.Paper;
                case 'a':
                case 'r':
                case 'u':
                case 'w':
                case 'k':
                case 'j':
                    return Move.Scissors;
                default:
                case 'o':
                case 's':
                case 'l':
                case 'p':
                case 'q':
                    return Move.Spock;
                case 'i':
                case 'n':
                case 'c':
                case 'y':
                case 'v':
                    return Move.Lizard;
            }
        }

        // Markov
        private int[,,] markovData = new int[5, 5, 5];
        private int ssIndex;
        private bool ssFound;

        public void RecordMarkov(Move prePrevious, Move previous, Move current)
        {
            markovData[(int)prePrevious, (int)previous, (int)current]++;
        }

        public Move HighestMarkov(Move previous, Move current)
        {
            int highestCount = -1;
            Move probMove = Move.Lizard;
            for (int i = 0; i < 5; i++)
            {
                int currentCount = markovData[(int)previous, (int)current, i];
                if (currentCount > highestCount)
                {
                    highestCount = currentCount;
                    probMove = (Move)i;
                }
            }
            return probMove;
        }
        

        public override Move Play()
        {

            #region SHOWMOVES
            //if (playerMoves.Count >= 99)
            //{
            //    showMoves();
            //}
            #endregion
            if (inQueue)
            {
                chosenMove = PlayFromQueue();
            }
            lastplayedMove = chosenMove;
            return chosenMove;
        }

        private Move PlayFromQueue()
        {
            //if (defaultMoveQueue.Count == 0)
            //{
            //    foreach (int moveNb in movesOrder)
            //    {
            //        defaultMoveQueue.Enqueue((Move)moveNb);
            //    } 
            //}
            if (movesQueueIndex > 4)
            {
                movesQueueIndex = 0;
            }
            return (Move)movesOrder[movesQueueIndex++];//defaultMoveQueue.Dequeue();
        }


        public override void Observe(Move opponentMove)
        {
            RecordMarkov(opponentSecondLastplayedMove, opponentLastplayedMove, opponentMove);
            RecordShakespeare(opponentMove);
            opponentSequence += (int)opponentMove;

            playedGames++;

            if (opponentLastplayedMove == opponentMove)
            {
                opponentLastplayedMoveAgain++;
            }
            else
            {
                opponentLastplayedMoveAgain = 0;
                //inQueue = true;
            }

            opponentSecondLastplayedMove = opponentLastplayedMove;
            opponentLastplayedMove = opponentMove;

            #region PreviousProject

            //if (opponentMove < 0)
            //{
            //    Console.WriteLine();
            //}
            #region QTYWINLOST
            if (WonLast(lastplayedMove, opponentMove))
            {
                wonLast = true;
                qtyWon++;
                wonInRow++;
                lostInRow = 0;
                //Console.WriteLine($"W:{qtyWon} WIR:{wonInRow}");
            }
            else
            {
                wonLast = false;
                qtyLost++;
                lostInRow++;
                wonInRow = 0;
                //Console.WriteLine($"L:{qtyLost} LIR:{lostInRow}");
            }
            #endregion

            opponentMoves.Add(opponentMove);

            #region CALC_PERCENTAGE
            if (opponentMove >= 0)
            {
                moveQty[(int)opponentMove]++;
                playermoveQty[(int)lastplayedMove]++;
                SetPercentage(opponentMove);
                playerMoves.Add(lastplayedMove);
                SetPlayerPercentage(lastplayedMove);
                GetHighestPercentageMove();
            }
            #endregion


            int minDist = MinDistance();
            chosenMove = GetCounterMove(opponentMove - minDist);


            if (playedGames >= 19)
            {
                opponentSequence2 += (int)opponentMove;
                if (int.Parse(opponentSequence[sequenceIndex].ToString()) == (int)opponentMove)
                {
                    inQueue = false;
                    chosenMove = GetCounterMove((Move)int.Parse(opponentSequence[++sequenceIndex].ToString()));
                }
                else
                {
                    inQueue = false;
                    chosenMove = GetCounterFavMove();
                    sequenceIndex = 0;
                    if (!wonLast)
                    {
                        int index = 0;
                        int sequenceLenght = 15;
                        if (opponentSequence2.Length > sequenceLenght)
                        {
                            string inRow5 = opponentSequence2.Remove(0, opponentSequence2.Length - sequenceLenght);

                            if (opponentSequence.Contains(inRow5))
                            {
                                index = opponentSequence.IndexOf(inRow5);
                                if (index > sequenceLenght)
                                {
                                    index = 0;
                                }
                            }
                        }
                        sequenceIndex = index + sequenceLenght;
                        if (int.Parse(opponentSequence[sequenceIndex].ToString()) == (int)opponentMove)
                        {
                            inQueue = false;
                            chosenMove = GetCounterMove((Move)int.Parse(opponentSequence[++sequenceIndex].ToString()));
                        }
                    }
                }
            }

            if (qtyLost > 20 && !wonLast || qtyLost < 40)
            {
                inQueue = false;
                chosenMove = GetCounterFavMove();
            }

            if (IsItCircular())
            {
                inQueue = false;
                chosenMove = opponentMove;
            }

            #endregion

            inQueue = false;
            if (playedGames <= 20)
            {
                ssIndex = FindSS();
                chosenMove = GetCounterMove((Move)int.Parse(ssConverted[ssIndex++].ToString()));
                ssFound = true;
                if (ssIndex >= ssConverted.Length)
                {
                    ssIndex = 0;
                }
            }
            else
            {
                chosenMove = GetCounterMove((Move)int.Parse(ssConverted[ssIndex].ToString())); 
                ssIndex++;
                if (ssIndex >= ssConverted.Length)
                {
                    ssIndex = 0;
                }
            }
            

            if (qtyLost > 30 && playedGames > 30)
            {
                chosenMove = GetCounterMove(HighestMarkov(opponentSecondLastplayedMove, opponentLastplayedMove));
            }
            else
            {
                ssIndex = FindSS();
                chosenMove = GetCounterMove((Move)int.Parse(ssConverted[ssIndex].ToString()));
            }
        
        }

        private bool FeelsRandom()
        {
            int diffPercentage = 0;
            float highest = 0;
            float lowest = int.MaxValue;
            for (int i = 0; i < movePercentages.Length; i++)
            {
                if (movePercentages[i] > highest)
                {
                    highest = movePercentages[i];
                }
                else if (movePercentages[i] < lowest)
                {
                    lowest = movePercentages[i];
                }
            }

            return highest - lowest < 0.2;
        }

        private Move GetHighestPercentageMove()
        {
            float highest = 0;

            int index = 0;
            int second = 0;
            for (int i = 0; i < movePercentages.Length; i++)
            {
                if (movePercentages[i] > highest)
                {
                    second = index;
                    highest = movePercentages[i];
                    index = i;
                }
                if (movePercentages[i] > movePercentages[second])
                {
                    second = i;
                }
            }
            opponentFavMove = (Move)index;
            opponentFavMove2 = (Move)second;
            return (Move)index;
        }

        public Move GetCounterMove(Move _move)
        {

            switch (_move)
            {
                case Move.Rock:
                case Move.Spock:
                    return Move.Paper;
                case Move.Paper:
                    return Move.Scissors;
                case Move.Scissors:
                default: //Move.Lizard
                    return Move.Rock;
            }
        }

        public Move GetCounterFavMove()
        {

            switch (opponentFavMove)
            {
                case Move.Rock:
                    switch (opponentFavMove2)
                    {
                        case Move.Spock:
                            return Move.Paper;
                        default:
                            return Move.Spock;
                    }
                case Move.Spock:
                    switch (opponentFavMove2)
                    {
                        case Move.Paper:
                        default:
                            return Move.Paper;
                    }
                case Move.Paper:
                    switch (opponentFavMove2)
                    {
                        case Move.Lizard:
                            return Move.Spock;
                        default:
                            return Move.Lizard;
                    }
                case Move.Scissors:
                    switch (opponentFavMove2)
                    {
                        case Move.Rock:
                            return Move.Spock;
                        default:
                            return Move.Rock;
                    }
                default: //Move.Lizard
                    switch (opponentFavMove2)
                    {
                        case Move.Scissors:
                            return Move.Rock;
                        default:
                            return Move.Scissors;
                    }
            }
        }

        public int MinDistance()
        {
            int minDistance = int.MaxValue;
            int prevNumber = (int)opponentMoves[0];
            for (int i = 1; i < opponentMoves.Count; i++)
            {
                int distance = Math.Abs(prevNumber - (int)opponentMoves[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
                prevNumber = (int)opponentMoves[i];
            }
            return minDistance;
        }

        private void SetPercentage(Move _move)
        {
            for (int i = 0; i < movePercentages.Length; i++)
            {
                movePercentages[i] = moveQty[i] / (float)opponentMoves.Count;
            }
            for (int i = 0; i < playermovePercentages.Length; i++)
            {
                playermovePercentages[i] = playermoveQty[i] / (float)opponentMoves.Count;
            }
        }

        private void SetPlayerPercentage(Move _move)
        {

            for (int i = 0; i < playermovePercentages.Length; i++)
            {
                playermovePercentages[i] = playermoveQty[i] / (float)playerMoves.Count;
            }
        }

        private Move HighestMovePlayed()
        {
            int higestIndex = 0;
            for (int i = 0; i < movePercentages.Length; i++)
            {
                if (movePercentages[i] > movePercentages[higestIndex])
                {
                    higestIndex = i;
                }
            }
            return (Move)higestIndex;
        }

        private Move HighestPlayerMovePlayed()
        {
            int higestIndex = 0;
            for (int i = 0; i < playermovePercentages.Length; i++)
            {
                if (playermovePercentages[i] >= playermovePercentages[higestIndex])
                {
                    higestIndex = i;
                }
            }
            return (Move)higestIndex;
        }

        private bool WonLast(Move playerMove, Move opMove)
        {
            if (playerMove == opMove)
            {
                return false;
            }
            switch (playerMove)
            {
                case Move.Rock:
                    if (opMove != Move.Spock && opMove != Move.Paper)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Move.Paper:
                    if (opMove != Move.Scissors && opMove != Move.Lizard)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Move.Scissors:
                    if (opMove != Move.Rock && opMove != Move.Spock)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Move.Spock:
                    if (opMove != Move.Lizard && opMove != Move.Paper)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: // Move.Lizard:
                    if (opMove != Move.Scissors && opMove != Move.Rock)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
        }

        private void showMoves()
        {
            if (this.playerMoves.Count != 0)
            {
                Console.WriteLine($"----{this.Nickname}----");
                for (int i = 0; i < playermovePercentages.Length; i++)
                {
                    Console.WriteLine($"{(Move)i} : {playermoveQty[i]} , {playermovePercentages[i].ToString("P2")}");
                }
                Console.WriteLine("*** OPPONENT ***");
                for (int i = 0; i < movePercentages.Length; i++)
                {
                    Console.WriteLine($"{(Move)i} : {moveQty[i]} , {movePercentages[i].ToString("P2")}");
                }
                Console.WriteLine($"--------");
            }
        }

        public bool IsItCircular()
        {
            if (opponentMoves.Count < 5)
            {
                return false;
            }
            bool circular = false;
            for (int i = 1; i < opponentMoves.Count; i++)
            {
                if (WonLast(opponentMoves[i - 1], opponentMoves[i]))
                {
                    circular = true;
                }
                else
                {
                    return false;
                }
            }
            return circular;
        }


    } // End Class
} //End Namespace
