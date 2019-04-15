using System;

namespace RPSLS
{
    class DUXM : StudentAI
    {
        Move[] m_vOpponentMoves = new Move[100];
        int m_nSumMoves = 0;
        int circularAI = 0;
        int circularMoveIndex = 0;
        Move favorite = Move.Paper;
        int hasFavorite = 0;
        int repeater = 0;
        int repeatLen = 0;

        public DUXM()
        {
			Nickname = "mw";
			CourseSection = Section.S07250;
        }

        public override void Observe(Move opponentMove)
        {
            m_vOpponentMoves[m_nSumMoves++] = opponentMove;
        }

        private int IsCircularAI()
        {
            for (int i = 0; i < 10; i++)
                if (m_vOpponentMoves[i] != m_vOpponentMoves[i + 5]) return 0;
            return 1;
        }

        private int same(int index)
        {
            Move flag = (Move)Enum.ToObject(typeof(Move), index);
            for (int i = 0; i < 20; i++)
                if (m_vOpponentMoves[i] != flag)
                    return 0;
            return 1;
        }

        private int HasFavorite()
        {
            for (int i = 0; i < 5; i++)
                if (same(i) == 1)
                {
                    favorite = (Move)Enum.ToObject(typeof(Move), i);
                    return 1;
                }
            return 0;
        }

        private void CheckIfRepeat()
        {
            for (int i = 0; i < m_nSumMoves / 2; ++i)
                if (m_vOpponentMoves[i] != m_vOpponentMoves[i + m_nSumMoves / 2]) return;
            repeater = 1;
            repeatLen = m_nSumMoves / 2;
        }

        public override Move Play()
        {
            if (m_nSumMoves < 10)
            {
                int index = Game.SeededRandom.Next(m_nSumMoves) % 5;
                return (Move)Enum.ToObject(typeof(Move), index);
            }

            if (m_nSumMoves == 10)
            {
                if (IsCircularAI() == 1)
                {
                    circularAI = 1;
                }
            }

            if (circularAI == 1)
            {
                switch (m_vOpponentMoves[m_nSumMoves % 5])
                {
                    case Move.Paper: return Move.Scissors;
                    case Move.Rock: return Move.Paper;
                    case Move.Scissors: return Move.Rock;
                    case Move.Lizard: return Move.Rock;
                    case Move.Spock: return Move.Paper;
                    default: return Move.Paper;
                }
            }

            int[] sum = new int[5];
            int max = 0;
            int sel = 0;
            if (m_nSumMoves < 20)
            {
                Move flag = m_vOpponentMoves[m_nSumMoves - 1];

                for (int i = 0; i < 5; i++)
                    sum[i] = 0;
                for (int i = 0; i < m_nSumMoves - 1; i++)
                    if (m_vOpponentMoves[i] == flag)
                    {
                        Move nextTurn = m_vOpponentMoves[i + 1];
                        int index = (int)(nextTurn);
                        sum[index]++;
                    }
                for (int i = 0; i < 5; i++)
                    if (sum[i] > max)
                    {
                        max = sum[i];
                        sel = i;
                    }
                switch (sel)
                {
                    case 0:
                        {
                            if (Game.SeededRandom.Next(m_nSumMoves) % 2 == 0) return Move.Paper;
                            return Move.Spock;
                        }
                    case 1:
                        {
                            if (Game.SeededRandom.Next(m_nSumMoves) % 2 == 0) return Move.Scissors;
                            return Move.Lizard;
                        }
                    case 2:
                        {
                            if (Game.SeededRandom.Next(m_nSumMoves) % 2 == 0) return Move.Rock;
                            return Move.Spock;
                        }
                    case 3:
                        {
                            if (Game.SeededRandom.Next(m_nSumMoves) % 2 == 0) return Move.Paper;
                            return Move.Lizard;
                        }
                    case 4:
                        {
                            if (Game.SeededRandom.Next(m_nSumMoves) % 2 == 0) return Move.Rock;
                            return Move.Scissors;
                        }
                    default: return Move.Rock;
                }
            }

            if (m_nSumMoves == 20)
            {
                if (HasFavorite() == 1)
                {
                    hasFavorite = 1;
                }
            }

            if (hasFavorite == 1)
            {
                switch (favorite)
                {
                    case Move.Paper: return Move.Scissors;
                    case Move.Rock: return Move.Paper;
                    case Move.Scissors: return Move.Rock;
                    case Move.Lizard: return Move.Rock;
                    case Move.Spock: return Move.Paper;
                    default: return Move.Paper;
                }
            }

            if (m_nSumMoves % 2 == 0 && m_nSumMoves >= 40 && m_nSumMoves <= 78 && repeater == 0)
            {
                CheckIfRepeat();
            }

            if (repeater == 1)
            {
                Move toWin = m_vOpponentMoves[m_nSumMoves % repeatLen];
                switch (toWin)
                {
                    case Move.Paper: return Move.Scissors;
                    case Move.Rock: return Move.Paper;
                    case Move.Scissors: return Move.Rock;
                    case Move.Lizard: return Move.Rock;
                    case Move.Spock: return Move.Paper;
                    default: return Move.Paper;
                }
            }

            for (int i = 0; i < 5; i++)
                sum[i] = 0;
            for (int i = 0; i < m_nSumMoves - 1; i++)
            {
                int index = 0;
                switch (m_vOpponentMoves[i])
                {
                    case Move.Paper:
                        {
                            index = (int)(Move.Scissors);
                            sum[index]++;
                            index = (int)(Move.Lizard);
                            sum[index]++;
                            break;
                        }
                    case Move.Rock:
                        {
                            index = (int)(Move.Paper);
                            sum[index]++;
                            index = (int)(Move.Spock);
                            sum[index]++;
                            break;
                        }
                    case Move.Scissors:
                        {
                            index = (int)(Move.Rock);
                            sum[index]++;
                            index = (int)(Move.Spock);
                            sum[index]++;
                            break;
                        }
                    case Move.Lizard:
                        {
                            index = (int)(Move.Rock);
                            sum[index]++;
                            index = (int)(Move.Scissors);
                            sum[index]++;
                            break;
                        }
                    case Move.Spock:
                        {
                            index = (int)(Move.Paper);
                            sum[index]++;
                            index = (int)(Move.Lizard);
                            sum[index]++;
                            break;
                        }
                    default: break;
                }
            }
            max = 0;
            sel = 0;
            for (int i = 0; i < 5; i++)
                if (sum[i] > max)
                {
                    max = sum[i];
                    sel = i;
                }
            return (Move)Enum.ToObject(typeof(Move), sel);
        }
    }
}
