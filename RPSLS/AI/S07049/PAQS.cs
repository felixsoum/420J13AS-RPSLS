using System;
using System.Collections.Generic;

namespace RPSLS
{
    class MoveInfo
    {
        public string a { get; set; }
        public List<Move> b { get; set; }
        public List<Move> c { get; set; }

        public MoveInfo (string moveName, List<Move> winAgainst, List<Move> loseAgainst)
        {
            a = moveName;
            b = winAgainst;
            c = loseAgainst;
        }

    }

    class PAQS : StudentAI
    {
        public const int c = 100;
        public const int d = 3;
        private readonly List<MoveInfo> e = new List<MoveInfo>();
        private Dictionary<int, Move> f = new Dictionary<int, Move>();
        private Dictionary<Move, int> g = new Dictionary<Move, int>();
        private int h { get; set; }
        private List<Move> i = new List<Move>();
        private int j { get; set; }

        public PAQS()
        {
            CourseSection = Section.S07049;
            Nickname = "The Master Chief";
            InitializeMoveInfo();
            InitializeNewBattle();
        }


        /// <summary>
        /// Play a move in a round
        /// </summary>
        /// <returns></returns>
        public override Move Play()
        {
            Move moveToPlay = Move.Spock;

            //Choose a move to play
            if ((h + 1) % d == 0)
            {
                i = ThinkAndFindPattern();
                j = h % i.Count;
            }
            else if (i.Count <= 0)
            {
                i.Add(ChooseRandomMove());
            }
            if (j >= i.Count)
            {
                j = 0;
            }
            moveToPlay = i[j++];
            h++;

            return moveToPlay;
        }

        /// <summary>
        /// Choose a seeded random move
        /// </summary>
        public Move ChooseRandomMove ()
        {
            return (Move)Game.SeededRandom.Next(0, e.Count);
        }

        /// <summary>
        /// Initialize a battle
        /// </summary>
        public void InitializeNewBattle ()
        {
            h = 0;
            j = 0;
        }

        /// <summary>
        /// Thinks and choose a move pattern to play
        /// </summary>
        private List<Move> ThinkAndFindPattern ()
        {
            RefreshCounts();

            //Find the trend, if its more than 50% (for us to win) then beat the trend
            Move trend = FindTrend();
            double trendPercentage = (g[trend] * 100f) / (h + 1);
            if (trendPercentage >= 50f)
            {
                return new List<Move>() { e.Find(x => x.a == trend.ToString()).c[0] };
            }

            //Find patterns and beat them if it exists
            for (int amountOfMoves = 3; amountOfMoves <= 10; amountOfMoves++)
            {
                if (h >= (amountOfMoves * 2))
                {
                    List<Move> pattern = FindPattern(amountOfMoves);
                    if (pattern != null)
                    {
                        return pattern;
                    }
                }
            }

            return new List<Move>() { Move.Lizard };
        }

        /// <summary>
        /// Look for a pattern of amountOfMoves in it
        /// </summary>
        private List<Move> FindPattern(int amountOfMoves)
        {
            List<Move> pattern = new List<Move>();
            for (int i = 0; i < amountOfMoves; i++)
            {
                if (f[i] != f[i + amountOfMoves])
                {
                    return null;
                }
                pattern.Add(e.Find(x => x.a == f[i].ToString()).c[Game.SeededRandom.Next(0, 2)]);
            }
            return pattern;
        }

        /// <summary>
        /// Actualize the counts of the moves
        /// </summary>
        private void RefreshCounts ()
        {
            g.Clear();
            foreach (var round in f.Keys)
            {
                Move move = f[round];
                switch (move)
                {
                    case Move.Scissors:
                        if (g.ContainsKey(Move.Scissors))
                        {
                            g[Move.Scissors]++;
                        }
                        else
                        {
                            g.Add(Move.Scissors, 1);
                        }
                        break;

                    case Move.Rock:
                        if (g.ContainsKey(Move.Rock))
                        {
                            g[Move.Rock]++;
                        }
                        else
                        {
                            g.Add(Move.Rock, 1);
                        }
                        break;

                    case Move.Paper:
                        if (g.ContainsKey(Move.Paper))
                        {
                            g[Move.Paper]++;
                        }
                        else
                        {
                            g.Add(Move.Paper, 1);
                        }
                        break;

                    case Move.Lizard:
                        if (g.ContainsKey(Move.Lizard))
                        {
                            g[Move.Lizard]++;
                        }
                        else
                        {
                            g.Add(Move.Lizard, 1);
                        }
                        break;

                    case Move.Spock:
                        if (g.ContainsKey(Move.Spock))
                        {
                            g[Move.Spock]++;
                        }
                        else
                        {
                            g.Add(Move.Spock, 1);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Finds the trend move of the opponent
        /// </summary>
        /// <returns></returns>
        private Move FindTrend ()
        {
            KeyValuePair<Move, int> trend = new KeyValuePair<Move, int>(Move.Spock, 0);
            foreach (var move in g)
            {
                if (trend.Value < move.Value)
                {
                    trend = move;
                }
            }
            return trend.Key;
        }

        /// <summary>
        /// Observe the move of the opponent in the last round. Saves that move 
        /// </summary>
        /// <param name="opponentMove"></param>
        public override void Observe(Move opponentMove)
        {
            f.Add((h - 1), opponentMove);
        }


        /// <summary>
        /// Initialize the info of the moves (what each move win or lose against)
        /// </summary>
        public void InitializeMoveInfo()
        {
            //Initialize info for scissors
            e.Add(new MoveInfo("Scissors", 
                new List<Move>() { Move.Paper, Move.Lizard }, 
                new List<Move>() { Move.Spock, Move.Rock }));

            //Initialize info for paper
            e.Add(new MoveInfo("Paper",
                new List<Move>() { Move.Rock, Move.Spock },
                new List<Move>() { Move.Scissors, Move.Lizard }));

            //Initialize info for rock
            e.Add(new MoveInfo("Rock",
                new List<Move>() { Move.Lizard, Move.Scissors },
                new List<Move>() { Move.Paper, Move.Spock }));

            //Initialize info for lizard
            e.Add(new MoveInfo("Lizard",
                new List<Move>() { Move.Spock, Move.Paper },
                new List<Move>() { Move.Rock, Move.Scissors }));

            //Initialize info for spock
            e.Add(new MoveInfo("Spock",
                new List<Move>() { Move.Scissors, Move.Rock },
                new List<Move>() { Move.Lizard, Move.Paper }));
        }


    }
}
