namespace RPSLS
{
    public static class MoveComparator
    {
        public static int CompareWith(this Move move1, Move move2)
        {
            if (IsInvalid(move1) && IsInvalid(move2))
            {
                return 0;
            }
            else if (IsInvalid(move1))
            {
                return 1;
            }
            else if (IsInvalid(move2))
            {
                return -1;
            }
            switch ((move1 - move2 + 5) % 5)
            {
                default:
                case 0:
                    return 0;
                case 1:
                case 3:
                    return 1;
                case 2:
                case 4:
                    return -1;
            }
        }

        public static bool IsInvalid(Move move)
        {
            return move < 0 || (int)move > 4;
        }
    }
}
