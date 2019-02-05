namespace RPSLS
{
    public static class MoveComparator
    {
        public static int CompareWith(this Move move1, Move move2)
        {
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
    }
}
