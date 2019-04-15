using System;
using System.Collections.Generic;

namespace RPSLS
{
    class MoveInfo
    {
        public string MoveName { get; set; }
        public List<Move> WinAgainst { get; set; }
        public List<Move> LoseAgainst { get; set; }
        public Move Move { get; set; }

        public MoveInfo (string moveName, Move move, List<Move> winAgainst, List<Move> loseAgainst)
        {
            MoveName = moveName;
            WinAgainst = winAgainst;
            LoseAgainst = loseAgainst;
            Move = move;
        }

    }

    class MoveDuo
    {
        public int Index { get; set; }
        public Move FirstMove { get; set; }
        public Move SecondMove { get; set; }
        public int Amount { get; set; }

        public MoveDuo() { }

        public MoveDuo (int index, Move firstMove, Move secondMove)
        {
            Index = index;
            FirstMove = firstMove;
            SecondMove = secondMove;
            Amount = 0;
        }
    }

    class PAQS : StudentAI
    {
        public const int MaxRound = 100;
        public const int ThinkingInterval = 1;
        private readonly List<MoveInfo> MoveInfos = new List<MoveInfo>();
        private Dictionary<int, Move> OpponentMoves = new Dictionary<int, Move>();
        private Dictionary<Move, int> MovesCount = new Dictionary<Move, int>();
        private Dictionary<Move, Dictionary<Move, int>> MovePreferences = new Dictionary<Move, Dictionary<Move, int>>();
        private Dictionary<Move, Dictionary<Move, Dictionary<Move, int>>> MovePreferencesTwo = new Dictionary<Move, Dictionary<Move, Dictionary<Move, int>>>();
        private int CurrentRound { get; set; }
        private List<Move> MovesPattern = new List<Move>();
        private int PatternPointer { get; set; }

        public PAQS()
        {
            CourseSection = Section.S07049;
            Nickname = "The Master Chief";
            InitializeMoveInfo();
            InitializeNewBattle();
            InitializeMarkov();
            InitializeMarkovTwo();
        }


        /// <summary>
        /// Play a move in a round
        /// </summary>
        /// <returns></returns>
        public override Move Play()
        {
            Move moveToPlay = ChooseRandomMove();

            //Find the markov two thinking
            MovesPattern = FindMarkovTwoThinking();         

            //shakespeare
            if (MovesPattern == null)
            {
                MovesPattern = FindShakespeare();
            }

            //pattern
            if (MovesPattern == null)
            {
                MovesPattern = ThinkAndFindPattern();
            }

            //markov
            if (MovesPattern == null)
            {
                MovesPattern = FindMarkovThinking();
            }

            //double trend
            if (MovesPattern == null)
            {
                MovesPattern = FindDoubleTrend();
            }

            //trend
            if (MovesPattern == null)
            {
                MovesPattern = FindTrend();
            }

            //random
            if (MovesPattern == null)
            {
                MovesPattern = new List<Move>() { ChooseRandomMove() };
            }

            //we loop through the moves if its a pattern
            PatternPointer = CurrentRound % MovesPattern.Count;
            moveToPlay = MovesPattern[PatternPointer++];
            CurrentRound++;

            return moveToPlay;
        }

        /// <summary>
        /// Try to find a double trend
        /// </summary>
        public List<Move> FindDoubleTrend ()
        {
            RefreshCounts();
            MoveDuo[] duo = new MoveDuo[5];
            duo[0] = new MoveDuo(0, Move.Rock, Move.Spock);
            duo[1] = new MoveDuo(1, Move.Paper, Move.Lizard);
            duo[2] = new MoveDuo(2, Move.Scissors, Move.Rock);
            duo[3] = new MoveDuo(3, Move.Spock, Move.Paper);
            duo[4] = new MoveDuo(4, Move.Lizard, Move.Scissors);

            foreach (var move in MovesCount)
            {
                for (int index = 0; index < duo.Length; index ++)
                {
                    if (duo[index].FirstMove == move.Key || duo[index].SecondMove == move.Key)
                    {
                        duo[index].Amount += move.Value;
                    }
                }
            }
            MoveDuo winningDuo = new MoveDuo();
            for (int j = 0; j < duo.Length; j++)
            {
                if (duo[j].Amount > winningDuo.Amount)
                {
                    winningDuo = duo[j];
                }
            }

            List<Move> moves = new List<Move>();
            //double trend
            foreach (MoveInfo info in MoveInfos)
            {
                if ((info.WinAgainst[0] == winningDuo.FirstMove && info.WinAgainst[1] == winningDuo.SecondMove) ||
                    (info.WinAgainst[1] == winningDuo.FirstMove && info.WinAgainst[0] == winningDuo.SecondMove))
                {
                    moves.Add(info.Move);
                    if (((winningDuo.Amount * 100f) / OpponentMoves.Count) >= 55f)
                    {
                        return moves;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Initialize Markov
        /// </summary>
        public void InitializeMarkov()
        {
            for (int index = 0; index < MoveInfos.Count; index++)
            {
                MovePreferences.Add((Move)index, new Dictionary<Move, int>());
                for (int j = 0; j < MoveInfos.Count; j++)
                {
                    MovePreferences[(Move)index].Add((Move)j, 0);
                }
            }
        }

        /// <summary>
        /// Initialize MarkovTwo
        /// </summary>
        public void InitializeMarkovTwo()
        {
            for (int index = 0; index < MoveInfos.Count; index++)
            {
                MovePreferencesTwo.Add((Move)index, new Dictionary<Move, Dictionary<Move, int>>());
                for (int j = 0; j < MoveInfos.Count; j++)
                {
                    MovePreferencesTwo[(Move)index].Add((Move)j, new Dictionary<Move, int>());
                    for (int z = 0; z < MoveInfos.Count; z++)
                    {
                        MovePreferencesTwo[(Move)index][(Move)j].Add((Move)z, 0);
                    }
                }
            }
        }

        /// <summary>
        /// Find markov thinking and returns a list of moves to play
        /// </summary>
        /// <returns></returns>
        public List<Move> FindMarkovThinking()
        {
            if (CurrentRound >= 2)
            {
                Move firstMove = OpponentMoves[CurrentRound - 2];
                Move secondMove = OpponentMoves[CurrentRound - 1];
                MovePreferences[firstMove][secondMove]++;

                int amountOfMoves = 0;
                int maxValue = int.MinValue;
                Move moveLikelyToBePlayed = Move.Rock;
                foreach (var move in MovePreferences.Keys)
                {
                    if (move == OpponentMoves[CurrentRound - 1])
                    {
                        //Find the most probable 60% move that the AI will play
                        foreach (var pair in MovePreferences[move])
                        {
                            if (pair.Value > maxValue)
                            {
                                maxValue = pair.Value;
                                moveLikelyToBePlayed = pair.Key;
                            }
                            amountOfMoves += pair.Value;
                        }
                    }
                }
                //Get and return a move that wins against the most probable move the AI will do
                foreach (MoveInfo info in MoveInfos)
                {
                    if (info.WinAgainst[0] == moveLikelyToBePlayed || info.WinAgainst[1] == moveLikelyToBePlayed)
                    {
                        if ((maxValue * 100f) / amountOfMoves >= 60f)
                        {
                            return new List<Move>() { info.Move };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Find markovtwo thinking and returns a list of moves to play
        /// </summary>
        /// <returns></returns>
        public List<Move> FindMarkovTwoThinking()
        {
            if (CurrentRound >= 3)
            {
                Move firstMove = OpponentMoves[CurrentRound - 3];
                Move secondMove = OpponentMoves[CurrentRound - 2];
                Move thirdMove = OpponentMoves[CurrentRound - 1];
                MovePreferencesTwo[firstMove][secondMove][thirdMove]++;

                int amountOfMoves = 0;
                int maxValue = int.MinValue;
                Move moveLikelyToBePlayed = Move.Rock;
                foreach (var move in MovePreferencesTwo.Keys)
                {
                    if (move == OpponentMoves[CurrentRound - 2])
                    {
                        //Find the most probable 60% move that the AI will play
                        foreach (var move2 in MovePreferencesTwo[move].Keys)
                        {
                            if (move2 == OpponentMoves[CurrentRound - 1])
                            {
                                foreach (var pair in MovePreferencesTwo[move][move2])
                                {
                                    if (pair.Value > maxValue)
                                    {
                                        maxValue = pair.Value;
                                        moveLikelyToBePlayed = pair.Key;
                                    }
                                    amountOfMoves += pair.Value;
                                }
                            }
                        }
                    }
                }
                //Get and return a move that wins against the most probable move the AI will do
                foreach (MoveInfo info in MoveInfos)
                {
                    if (info.WinAgainst[0] == moveLikelyToBePlayed || info.WinAgainst[1] == moveLikelyToBePlayed)
                    {
                        if ((maxValue * 100f) / amountOfMoves >= 60f)
                        {
                            return new List<Move>() { info.Move };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the shakespeare thinking and returns a list of move to play
        /// </summary>
        /// <returns></returns>
        public List<Move> FindShakespeare()
        {
            List<Move> moves = new List<Move>();
            List<Move> shakespeareMoves = ShakespeareAI.CreateSequence();
            int correct = 0, alignementIndex = -1;
            
            if (CurrentRound >= 8)
            {
                for (int index = 0; index < shakespeareMoves.Count; index++)
                {
                    correct = 0;
                    for (int j = 0; j < OpponentMoves.Count; j++)
                    {
                        int shakespearePointer = index + j;
                        if (shakespearePointer >= shakespeareMoves.Count)
                        {
                            shakespearePointer = (index + j) - shakespeareMoves.Count;
                        }
                        if (shakespeareMoves[shakespearePointer] == OpponentMoves[j])
                        {
                            correct++;
                        }
                    }
                    if ((correct * 100f) / OpponentMoves.Count >= 50f)
                    {
                        alignementIndex = index;
                    }
                }

                if (alignementIndex == -1)
                {
                    return null;
                }

                for (int z = 0; z < MaxRound; z++)
                {
                    int ptr = alignementIndex + z;
                    if (ptr >= shakespeareMoves.Count)
                    {
                        ptr = (alignementIndex + z) - shakespeareMoves.Count;
                    }
                    foreach (MoveInfo info in MoveInfos)
                    {
                        if (info.WinAgainst[0] == shakespeareMoves[ptr] || info.WinAgainst[1] == shakespeareMoves[ptr])
                        {
                            moves.Add(info.Move);
                            break;
                        }
                    }
                }
                return moves;
            }
            
            return null;
        }

        /// <summary>
        /// Choose a seeded random move
        /// </summary>
        public Move ChooseRandomMove ()
        {
            return (Move)Game.SeededRandom.Next(0, MoveInfos.Count);
        }

        /// <summary>
        /// Initialize a battle
        /// </summary>
        public void InitializeNewBattle ()
        {
            CurrentRound = 0;
            PatternPointer = 0;
        }

        /// <summary>
        /// Thinks and choose a move pattern to play
        /// </summary>
        private List<Move> ThinkAndFindPattern ()
        {
            RefreshCounts();
            //Find patterns and beat them if it exists
            for (int amountOfMoves = 49; amountOfMoves >= 3; amountOfMoves--)
            {
                if (CurrentRound >= (amountOfMoves * 2))
                {
                    List<Move> pattern = FindPattern(amountOfMoves);
                    if (pattern != null)
                    {
                        return pattern;
                    }
                }
            }

            return null;
        }
        
        /// <summary>
        /// Look for a pattern of amountOfMoves in it
        /// </summary>
        private List<Move> FindPattern(int amountOfMoves)
        {
            List<Move> pattern = new List<Move>();
            for (int i = 0; i < amountOfMoves; i++)
            {
                if (OpponentMoves[i] != OpponentMoves[i + amountOfMoves])
                {
                    return null;
                }
                pattern.Add(MoveInfos.Find(x => x.MoveName == OpponentMoves[i].ToString()).LoseAgainst[Game.SeededRandom.Next(0, 2)]);
            }
            return pattern;
        }

        /// <summary>
        /// Actualize the counts of the moves
        /// </summary>
        private void RefreshCounts ()
        {
            MovesCount.Clear();
            foreach (var round in OpponentMoves.Keys)
            {
                Move move = OpponentMoves[round];
                switch (move)
                {
                    case Move.Scissors:
                        if (MovesCount.ContainsKey(Move.Scissors))
                        {
                            MovesCount[Move.Scissors]++;
                        }
                        else
                        {
                            MovesCount.Add(Move.Scissors, 1);
                        }
                        break;

                    case Move.Rock:
                        if (MovesCount.ContainsKey(Move.Rock))
                        {
                            MovesCount[Move.Rock]++;
                        }
                        else
                        {
                            MovesCount.Add(Move.Rock, 1);
                        }
                        break;

                    case Move.Paper:
                        if (MovesCount.ContainsKey(Move.Paper))
                        {
                            MovesCount[Move.Paper]++;
                        }
                        else
                        {
                            MovesCount.Add(Move.Paper, 1);
                        }
                        break;

                    case Move.Lizard:
                        if (MovesCount.ContainsKey(Move.Lizard))
                        {
                            MovesCount[Move.Lizard]++;
                        }
                        else
                        {
                            MovesCount.Add(Move.Lizard, 1);
                        }
                        break;

                    case Move.Spock:
                        if (MovesCount.ContainsKey(Move.Spock))
                        {
                            MovesCount[Move.Spock]++;
                        }
                        else
                        {
                            MovesCount.Add(Move.Spock, 1);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Finds the trend and returns a list of winning moves
        /// </summary>
        /// <returns></returns>
        private List<Move> FindTrend ()
        {
            RefreshCounts();
            KeyValuePair<Move, int> trend = new KeyValuePair<Move, int>(Move.Spock, 0);
            foreach (var move in MovesCount)
            {
                if (trend.Value < move.Value)
                {
                    trend = move;
                }
            }
            double percertange = (trend.Value * 100f) / OpponentMoves.Count;
            List<Move> moves = new List<Move>();
            MoveInfo trendInfo = MoveInfos.Find(x => x.MoveName == trend.Key.ToString());
            for (int index = 0; index < trendInfo.LoseAgainst.Count; index++)
            {
                moves.Add(trendInfo.LoseAgainst[index]);
            }
            return moves;
        }

        /// <summary>
        /// Observe the move of the opponent in the last round. Saves that move 
        /// </summary>
        /// <param name="opponentMove"></param>
        public override void Observe(Move opponentMove)
        {
            OpponentMoves.Add((CurrentRound - 1), opponentMove);
        }

        /// <summary>
        /// Initialize the info of the moves (what each move win or lose against)
        /// </summary>
        public void InitializeMoveInfo()
        {
            //Initialize info for scissors
            MoveInfos.Add(new MoveInfo("Scissors", Move.Scissors, 
                new List<Move>() { Move.Paper, Move.Lizard }, 
                new List<Move>() { Move.Spock, Move.Rock }));

            //Initialize info for paper
            MoveInfos.Add(new MoveInfo("Paper", Move.Paper, 
                new List<Move>() { Move.Rock, Move.Spock },
                new List<Move>() { Move.Scissors, Move.Lizard }));

            //Initialize info for rock
            MoveInfos.Add(new MoveInfo("Rock", Move.Rock, 
                new List<Move>() { Move.Lizard, Move.Scissors },
                new List<Move>() { Move.Paper, Move.Spock }));

            //Initialize info for lizard
            MoveInfos.Add(new MoveInfo("Lizard", Move.Lizard, 
                new List<Move>() { Move.Spock, Move.Paper },
                new List<Move>() { Move.Rock, Move.Scissors }));

            //Initialize info for spock
            MoveInfos.Add(new MoveInfo("Spock", Move.Spock,
                new List<Move>() { Move.Scissors, Move.Rock },
                new List<Move>() { Move.Lizard, Move.Paper }));
        }


    }
}
