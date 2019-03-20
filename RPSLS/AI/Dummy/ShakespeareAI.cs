using RPSLS;

class ShakespeareAI : DummyAI
{
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

    int index;

    public ShakespeareAI()
    {
        Nickname = "William Shakespeare";
        index = Game.SeededRandom.Next(SonnetXVII.Length);
    }

    public override Move Play()
    {
        index %= SonnetXVII.Length;
        while (SonnetXVII[index] < 'A' || SonnetXVII[index] > 'z')
        {
            index++;
            index %= SonnetXVII.Length;
        }
        return Game.SeededRandom.NextDouble() > 0.2 ? CharToMove(SonnetXVII[index++]) : RandomMove();
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
}
