using System;
using System.Linq;

namespace RPSLS
{
    class SIVA : StudentAI
    {
        /// <summary>
        /// Set up winning scenarios against the AI where properties include the oppnonent's move, their probabilities of occuring, and their countermoves.
        /// </summary>
        private sealed class WinningScenario
        {
            public Move OpponentMove { get; }
            public Move FirstMoveToPlay { get; }
            public Move SecondMoveToPlay { get; }
            public int Probability { get; set; }

            private WinningScenario()
            {
                this.Probability = 0;   // default probability
            }

            public WinningScenario(Move opponentMove, Move firstMoveToPlay, Move secondMoveToPlay) : this()
            {
                this.OpponentMove = opponentMove;
                this.FirstMoveToPlay = firstMoveToPlay;
                this.SecondMoveToPlay = secondMoveToPlay;
            }
        }

        /// <summary>
        /// Circular array of a chosen size to store generic elements.
        /// When the array is full, assign newest element to the oldest element in order to implement the circular storage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private sealed class CircularArray<T>
        {
            public int Oldest { get; private set; }
            public int Newest { get; private set; }
            public T[] Array { get; }

            public CircularArray(int size)
            {
                this.Oldest = 0;
                this.Newest = 0;
                this.Array = new T[size];
            }

            public void AddElement(T element)   // Method to store the elements depending on whether the array is full or not
            {
                if (Newest == Array.Length)
                {
                    Newest = 0;
                    Oldest++;
                }
                if (Oldest != 0)
                {
                    Oldest++;
                    if (Oldest == Array.Length)
                    {
                        Oldest = 0;
                    }
                }
                Array[Newest] = element;
                Newest++;
            }
        }


        //PROPERTIES
        private const int MOVEBUFFERSIZE = 15;      // Circular array size
        private WinningScenario[] winningScenarios;
        private int moveCount;
        private CircularArray<Move> recentMoves;

        /// <summary>
        /// Initializing the constructor
        /// </summary>
        public SIVA()
        {
            CourseSection = Section.S07248;
            Nickname = "Hello There, General Kenobi";

            /*Paper kills Rock and Spock
            Rock kills Scissors and Lizard
            Scissors kills Paper and Lizard
            Lizard kills Paper and Spock
            Spock kills Rock and Scissors*/
            winningScenarios = new WinningScenario[]    // create an array to store possible winning scenarios
            {
                new WinningScenario(Move.Rock, Move.Paper, Move.Spock),
                new WinningScenario(Move.Paper, Move.Scissors, Move.Lizard),
                new WinningScenario(Move.Scissors, Move.Spock, Move.Rock),
                new WinningScenario(Move.Spock, Move.Paper, Move.Lizard),
                new WinningScenario(Move.Lizard, Move.Rock, Move.Scissors)
            };
            recentMoves = new CircularArray<Move>(MOVEBUFFERSIZE);
            this.moveCount = 0;
        }

        /// <summary>
        /// To reset this object
        /// </summary>
        public void Reset()
        {
            this.moveCount = 0;
            foreach (WinningScenario scenario in winningScenarios)
            {
                scenario.Probability = 0;
            }
            recentMoves = new CircularArray<Move>(MOVEBUFFERSIZE);
        }

        /// <summary>
        /// Observe opponent's moves and increment the probability of that move played. 
        /// Store the move in the circular array.
        /// </summary>
        /// <param name="opponentMove"></param>
        public override void Observe(Move opponentMove)
        {
            this.moveCount++;      // for every opponent move played, increase its probability
            this.winningScenarios[(int)opponentMove].Probability++;
            recentMoves.AddElement(opponentMove);
        }

        /// <summary>
        /// Look for Move patterns, where patterns can be of 2 to 5 elements
        /// Returns the move to play against opponent according to the most probable move played
        /// </summary>
        /// <returns>one of the two winning moves</returns>
        public override Move Play()
        {
            if (moveCount == 0)     // no moves played yet
            {
                return RandomMove();
            }

            WinningScenario mostLikely = null;

            if (moveCount >= 10 && (mostLikely = FindPattern()) != null)    // if there is a pattern, we return the move to play winning scenario according to that pattern
            {
                return Game.SeededRandom.Next() % 2 == 0 ? mostLikely.FirstMoveToPlay : mostLikely.SecondMoveToPlay;   
            }

            foreach (WinningScenario scenario in winningScenarios)
            {
                if (mostLikely == null || mostLikely.Probability < scenario.Probability)    //  if there is no pattern, return the counter of the most frequent move the opponent will play next
                {
                    mostLikely = scenario;
                }
            }
            return Game.SeededRandom.Next() % 2 == 0 ? mostLikely.FirstMoveToPlay : mostLikely.SecondMoveToPlay;         // pick one of the two moves to counter (should make it into a function)
        }

        private WinningScenario FindPattern()
        {
            for (int patternLength = 5; patternLength >= 2; patternLength--)    // itirate through assumed possible pattern lengths
            {
                int firstIndex = recentMoves.Newest - patternLength;    // if any of the starting indices are negative, wrap back the circular array
                int secondIndex = firstIndex - patternLength;
                if (firstIndex < 0) 
                {
                    firstIndex += recentMoves.Array.Length;
                }
                if (secondIndex < 0)
                {
                    secondIndex += recentMoves.Array.Length;
                }

                bool isEqual = true;    // true when pattern is found
                for (int i = 0; i < patternLength; i++)
                {
                    int i1 = i + firstIndex;    
                    int i2 = i + secondIndex;
                    if (i1 >= recentMoves.Array.Length)     // checking for indices larger than the array length
                    {
                        i1 -= recentMoves.Array.Length;
                    }
                    if (i2 >= recentMoves.Array.Length)
                    {
                        i2 -= recentMoves.Array.Length;
                    }

                    if (recentMoves.Array[i1] != recentMoves.Array[i2])     // if any elements are not the same, then there is no pattern within that pattern length
                    {
                        isEqual = false;    
                        break;
                    }
                }

                if (isEqual)
                {
                    return winningScenarios[(int)recentMoves.Array[firstIndex]];    // return winning scenario of the first element of the pattern
                }
            }
            return null;    // no pattern found
        }
    }
}
