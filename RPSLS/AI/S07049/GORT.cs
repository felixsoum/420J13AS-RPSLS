using System;

namespace RPSLS
{
    class GORT : StudentAI
    {
        int[] a;
        Move b;
        Move c;
        int d = 0;
        Move e;
        bool f = false;

        public GORT()
        {
            Nickname = "Le meilleur rat";
            CourseSection = Section.S07049;
            a = new int[1000];
        }


        public override void Observe(Move opponentMove)
        {
            c = opponentMove;
        }

        public override Move Play()
        {
            d++;
            a[d] = (int)c;
            int iWonLastRound = MoveComparator.CompareWith(b, (Move)a[d - 1]);
            if (f == true)
            {
                return (Move)a[d - 5];
            }
            if (d > 99)
            {
                f = false;
            }
            if (a[d] == a[d - 1])
            {
                DidIWinGenericAI(iWonLastRound, e);
            }
            else if (a[d] != a[d - 1] && d >= 5 && a[d] == a[d - 5])
            {
                f = true;
                e = CheckValue(a[d - 4]);                
            }
            else if (a[d] != a[d - 2] && d > 2)
            {
                Random random = Game.SeededRandom;
                int random2 = random.Next();
                if (random2 > 4)
                {
                    random2 = random.Next(3, 4);
                }
                else if (random2 < 0)
                {
                    random2 = random.Next(0, 3);
                }
                e = CheckValue(random2);
            }
            b = e;
            return e;
        }

        private void DidIWinGenericAI(int iWonLastRound, Move myNewMove)
        {
            if (iWonLastRound != 1)
            {
                myNewMove = CheckValue(a[d]);
            }
            else
            {
                myNewMove = CheckValue(a[d - 1]);
            }
        }
        Move CheckValue(int opponentMove)
        {
            switch (opponentMove)
            {
                case 4:
                    e = Lizard();
                    break;
                case 1:
                    e = Paper();
                    break;
                case 0:
                    e = Rock();
                    break;
                case 2:
                    e = Scissors();
                    break;
                case 3:
                    e = Spock();
                    break;
                default:
                    e = Rock();
                    break;
            }
            return RandomMove();
        }
        Move Lizard()
        {
            Random random = Game.SeededRandom;
            int random2 = random.Next(0, 2);
            return (random2 > 0) ? Move.Rock : Move.Scissors;
        }
        Move Scissors()
        {
            Random random = Game.SeededRandom;
            int random2 = random.Next(0, 2);
            return (random2 > 0) ? Move.Rock : Move.Spock;
        }
        Move Paper()
        {
            Random random = Game.SeededRandom;
            int random2 = random.Next(0, 2);
            return (random2 > 0) ? Move.Lizard : Move.Scissors;
        }
        Move Rock()
        {
            Random random = Game.SeededRandom;
            int random2 = random.Next(0, 2);
            return (random2 > 0) ? Move.Paper : Move.Spock;
        }
        Move Spock()
        {
            Random random = Game.SeededRandom;
            int random2 = random.Next(0, 2);
            return (random2 > 0) ? Move.Lizard : Move.Paper;
        }
    }
}
