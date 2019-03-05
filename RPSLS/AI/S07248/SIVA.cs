namespace RPSLS
{
    class SIVA : StudentAI
    {
        private sealed class WinningScenario
        {
            public Move a { get; }
            public Move b { get; }
            public Move c { get; }
            public int d { get; set; }

            private WinningScenario()
            {
                this.d = 0;     
            }

            public WinningScenario(Move a, Move b, Move c) : this()
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
        }

        private sealed class CircularArray<T>
        {
            public int a { get; private set; }
            public int b { get; private set; }
            public T[] c { get; }

            public CircularArray(int size)
            {
                this.a = 0;
                this.b = 0;
                this.c = new T[size];
            }

            public void AddElement(T element)                 
            {
                if (b == c.Length)
                {
                    b = 0;
                    a++;
                }
                if (a != 0)
                {
                    a++;
                    if (a == c.Length)
                    {
                        a = 0;
                    }
                }
                c[b] = element;
                b++;
            }
        }


        private const int d = 15;         
        private WinningScenario[] e;
        private int f;
        private CircularArray<Move> g;

        public SIVA()
        {
            CourseSection = Section.S07248;
            Nickname = "Hello There, General Kenobi";

            e = new WinningScenario[]            
            {
                new WinningScenario(Move.Rock, Move.Paper, Move.Spock),
                new WinningScenario(Move.Paper, Move.Scissors, Move.Lizard),
                new WinningScenario(Move.Scissors, Move.Spock, Move.Rock),
                new WinningScenario(Move.Spock, Move.Paper, Move.Lizard),
                new WinningScenario(Move.Lizard, Move.Rock, Move.Scissors)
            };
            g = new CircularArray<Move>(d);
            this.f = 0;
        }

        public void Reset()
        {
            this.f = 0;
            foreach (WinningScenario scenario in e)
            {
                scenario.d = 0;
            }
            g = new CircularArray<Move>(d);
        }

        public override void Observe(Move opponentMove)
        {
            this.f++;              
            this.e[(int)opponentMove].d++;
            g.AddElement(opponentMove);
        }

        public override Move Play()
        {
            if (f == 0)         
            {
                return RandomMove();
            }

            WinningScenario mostLikely = null;

            if (f >= 10 && (mostLikely = FindPattern()) != null)                     
            {
                return Game.SeededRandom.Next() % 2 == 0 ? mostLikely.b : mostLikely.c;
            }

            foreach (WinningScenario scenario in e)
            {
                if (mostLikely == null || mostLikely.d < scenario.d)                       
                {
                    mostLikely = scenario;
                }
            }
            return Game.SeededRandom.Next() % 2 == 0 ? mostLikely.b : mostLikely.c;                       
        }

        private WinningScenario FindPattern()
        {
            for (int patternLength = 5; patternLength >= 2; patternLength--)          
            {
                int firstIndex = g.b - patternLength;                 
                int secondIndex = firstIndex - patternLength;
                if (firstIndex < 0)
                {
                    firstIndex += g.c.Length;
                }
                if (secondIndex < 0)
                {
                    secondIndex += g.c.Length;
                }

                bool isEqual = true;         
                for (int i = 0; i < patternLength; i++)
                {
                    int i1 = i + firstIndex;
                    int i2 = i + secondIndex;
                    if (i1 >= g.c.Length)             
                    {
                        i1 -= g.c.Length;
                    }
                    if (i2 >= g.c.Length)
                    {
                        i2 -= g.c.Length;
                    }

                    if (g.c[i1] != g.c[i2])                     
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (isEqual)
                {
                    return e[(int)g.c[firstIndex]];              
                }
            }
            return null;       
        }
    }
}
