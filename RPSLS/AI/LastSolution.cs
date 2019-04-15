using System.Collections.Generic;

namespace RPSLS
{
    class LastSolution : StudentAI
    {
        List<Move> history = new List<Move>();

        // Markov fields
        readonly int[,,] frequencyTable = new int[5, 5, 5];
        Move? prevPrev = null;
        Move? prev = null;

        // Shakespeare fields
        List<Move> sonnetSequence = new List<Move>();
        int sonnetAlignmentScore;

        public LastSolution()
        {
            Nickname = "Sensei";

            sonnetSequence = ShakespeareAI.CreateSequence();
            int n = sonnetSequence.Count;
            for (int i = 0; i < n; i++)
            {
                sonnetSequence.Add(sonnetSequence[i]);
            }
        }

        public override Move Play()
        {
            if (history.Count < 5 || history.Count == 20) // Bait move at 20
            {
                return RandomMove();
            }
            else
            {
                Move shakespeareMove = PlayShakespeare();
                return sonnetAlignmentScore > 40 ? shakespeareMove : PlayMarkov();
            }
        }

        public override void Observe(Move opponentMove)
        {
            history.Add(opponentMove);

            if (prev.HasValue && prevPrev.HasValue)
            {
                frequencyTable[(int)prevPrev, (int)prev, (int)opponentMove]++;
            }
            prevPrev = prev;
            prev = opponentMove;
        }

        Move Counter(Move mostFrequent, Move secondFrequent)
        {
            switch (mostFrequent)
            {
                case Move.Rock:
                    return secondFrequent == Move.Scissors ? Move.Spock : Move.Paper;
                case Move.Spock:
                    return secondFrequent == Move.Paper ? Move.Lizard : Move.Paper;
                case Move.Paper:
                    return secondFrequent == Move.Lizard ? Move.Scissors : Move.Lizard;
                case Move.Lizard:
                    return secondFrequent == Move.Paper ? Move.Scissors : Move.Rock;
                case Move.Scissors:
                default:
                    return secondFrequent == Move.Lizard ? Move.Rock : Move.Spock;
            }
        }

        Move PlayShakespeare()
        {
            sonnetAlignmentScore = -1;

            int bestIndex = 0;
            for (int i = 0; i < sonnetSequence.Count - history.Count; i++)
            {
                int score = 0;
                for (int j = 0; j < history.Count; j++)
                {
                    if (history[j] == sonnetSequence[i + j])
                    {
                        score++;
                    }
                }
                if (score > sonnetAlignmentScore)
                {
                    sonnetAlignmentScore = score;
                    bestIndex = i;
                }
            }

            Move bestGuess = sonnetSequence[bestIndex + history.Count];
            return Counter(bestGuess, bestGuess);
        }

        Move PlayMarkov()
        {
            Move mostFrequent = Move.Rock;
            Move secondFrequent = Move.Scissors;
            int count1 = -1;
            int count2 = -1;

            for (int i = 0; i < 5; i++)
            {
                int currentFrequency = frequencyTable[(int)prevPrev, (int)prev, i];

                if (count1 < currentFrequency)
                {
                    count2 = count1;
                    secondFrequent = mostFrequent;
                    count1 = currentFrequency;
                    mostFrequent = (Move)i;
                }
                else if (count2 < currentFrequency)
                {
                    count2 = currentFrequency;
                    secondFrequent = (Move)i;
                }
            }

            return Counter(mostFrequent, secondFrequent);
        }
    }
}
