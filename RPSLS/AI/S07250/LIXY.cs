using System;
using System.Collections.Generic;

namespace RPSLS
{
    class LIXY : StudentAI
    {
        static int BattleCount = 1;
        public LIXY()
        {
            Nickname = "I'm too good at this game";
            CourseSection = Section.S07250;
            BattleCount++;
        }

        public const string SonnetXVII = @"WhowillbelievemyverseintimetocomeIfitwerefilledwithyourmosthighdesertsThoughyetheavenknowsitisbutasatombWhichhidesyourlifeandshowsnothalfyourpartsIfIcouldwritethebeautyofyoureyesAndinfreshnumbersnumberallyourgracesTheagetocomewouldsayThispoetliesSuchheavenlytouchesneertouchedearthlyfacesSoshouldmypapersyellowedwiththeirageBescornedlikeoldmenoflesstruththantongueAndyourtruerightsbetermedapoetsrageAndstretchedmetreofanantiquesongButweresomechildofyoursalivethattimeYoushouldlivetwiceinitandinmyrhymeWhowillbelievemyverseintimetocomeI";

        int length = SonnetXVII.Length;
        List<Move> Sonnet = new List<Move>();
        public void InplementList()
        {
            foreach (char c in SonnetXVII)
            {
                Sonnet.Add(CharToMove(c));
            }
        }
        int Choice;
        int startingindex = 0;
        int round = 1;
        public Move aLIEzAldnoah, HiroyukiSawano;
        public int[,,] Bloodyf8 = new int[5, 5, 5];// Lizard|Spock|Scissors|Paper|Rock so doe the vertical way from 1 to 5// Doesn't matter how we store values in a 3d array
        public int c = 0;
        public Move[] a = new Move[100];
        public Move[] temparray = new Move[100];

        public override void Observe(Move opponentMove)
        {
            a[c++] = opponentMove;
            if (round == 1)
            {
                aLIEzAldnoah = opponentMove;
                round++;
            }
            else if (round == 2)
            {
                HiroyukiSawano = aLIEzAldnoah;
                aLIEzAldnoah = opponentMove;
                round++;
            }
            else if (round > 2)//change to 2 when doing the second AI
            {
                switch (opponentMove)
                {
                    case Move.Rock:
                        Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, 0] += 1;
                        break;
                    case Move.Paper:
                        Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, 1] += 1;
                        break;
                    case Move.Scissors:
                        Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, 2] += 1;
                        break;
                    case Move.Spock:
                        Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, 3] += 1;
                        break;
                    case Move.Lizard:
                        Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, 4] += 1;
                        break;
                    default:
                        Console.WriteLine("StupidAI");
                        break;
                }
            HiroyukiSawano = aLIEzAldnoah;
            aLIEzAldnoah = opponentMove;
            round++;
            }

        }
        public Move BeatMarkovAIs()
        {
            int ProofOfHero = -1;
            int Zinogre = 0;
            for (int i = 0; i < 5; i++)
            {
                if (ProofOfHero < Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, i])
                {
                    Zinogre = i;
                    ProofOfHero = Bloodyf8[(int)HiroyukiSawano, (int)aLIEzAldnoah, i];
                }
            }
            Move Boom = CounterByNumber(Zinogre);
            return Boom;
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
        public Move CounterByNumber(int i)
        {
            switch (i)
            {
                default:
                case 0:
                    return Move.Paper;
                case 1:
                    return Move.Scissors;
                case 2:
                    return Move.Spock;
                case 3:
                    return Move.Lizard;
                case 4:
                    return Move.Rock;
            }
        }
        public Move Countermove(Move enemymove)
        {
            switch (enemymove)
            {
                default:
                case Move.Rock:
                    return Move.Paper;
                case Move.Paper:
                    return Move.Scissors;
                case Move.Scissors:
                    return Move.Spock;
                case Move.Spock:
                    return Move.Lizard;
                case Move.Lizard:
                    return Move.Rock;
            }
        }

        public int IfShakes()
        {
            InplementList();
            int currentindex;
            int i, j = 0;
            for (i = 0; i < length - round; i++)//the sonnet
            {
                int RepeatTime = 0;
                for (j = 0; j < c; j++)
                {
                    if (a[j] == Sonnet[i + j])
                    {
                        RepeatTime++;
                        if (RepeatTime >= (round / 2) - 2)
                        {
                            currentindex = i;
                            return currentindex;
                        }
                    }
                }
            }
            return 0;
        }
        public override Move Play()
        {
            int index;
            Move ct;

              if (round == 40)
            {
                if (IfShakes() != 0)
                {
                    Choice = 1;
                    startingindex = IfShakes();
                }
                else Choice = 0;
            }
            switch (Choice)
            {
                default:
                case 0:
                    return BeatMarkovAIs();
                case 1:
                    {
                        index = startingindex + c;
                        Move re = Sonnet[index];
                        ct = Countermove(Sonnet[index]);
                        temparray[round - 18] = ct;
                        return Countermove(Sonnet[index]);
                    }
            }
        }
    }
}