using RPSLS;

class MarkovOneAI : DummyAI
{
    Move[] weightedMoves = new Move[5];
    Move prev;

    public MarkovOneAI()
    {
        Nickname = "Markov";

        prev = RandomMove();

        Shuffle();
        for (int i = 0; i < 5; i++)
        {
            weightedMoves[i] = shuffledMoves[i];
        }
    }

    public override Move Play()
    {
        Move move = GetWeightedMove(weightedMoves[(int)prev]);
        prev = move;
        return move;
    }

    public static Move GetWeightedMove(Move move)
    {
        Move[] moves = new Move[] { Move.Rock, Move.Paper, Move.Scissors, Move.Spock, Move.Lizard };

        int index = (int)move;
        Move temp = moves[index];
        moves[index] = moves[4];
        moves[4] = temp;

        double chance = Game.SeededRandom.NextDouble();
        for (int i = 0; i < 4; i++)
        {
            if (chance < (i + 1) * 0.1)
            {
                return moves[i];
            }
        }
        return moves[4];
    }
}
