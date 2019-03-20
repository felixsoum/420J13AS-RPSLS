using RPSLS;

class MarkovTwoAI : DummyAI
{
    Move[,] weightedMoves = new Move[5, 5];
    Move prev;
    Move prevPrev;

    public MarkovTwoAI()
    {
        Nickname = "Super Markov";
        prev = RandomMove();
        prevPrev = RandomMove();

        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                weightedMoves[i, j] = RandomMove();
            }
        }
    }

    public override Move Play()
    {
        Move move = MarkovOneAI.GetWeightedMove(weightedMoves[(int)prevPrev, (int)prev]);
        prevPrev = prev;
        prev = move;
        return move;
    }
}
