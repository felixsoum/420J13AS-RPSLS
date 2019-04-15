using System;
using System.Collections.Generic;


namespace RPSLS
{
    class ZHAB : StudentAI
    {
        private Move a;
        private List<Move> moveList = new List<Move>();

        private Move[] moveSet = { Move.Scissors, Move.Spock, Move.Rock, Move.Lizard, Move.Paper };
        Move? prev = null;
        Move? prev2 = Move.Rock;
        int[,,] previousMoves = new int[5, 5, 5];

        public ZHAB()
        {
            Nickname = "BBB";
            CourseSection = Section.S07250;
        }

        public override Move Play()
        {
            if (!prev.HasValue)
            {
                return RandomMove();
            }
            else
            {
                Move possibleMove = Move.Rock;
                int highestCount = -1;
                for(int i = 0; i < 5; i++)
                {
                    int currentCount = previousMoves[(int)prev, (int)prev2, i];
                    if (currentCount > highestCount)
                    {
                        possibleMove = (Move)i;
                        highestCount = currentCount;
                    }
                }
               // Console.WriteLine("possibleMove:" + possibleMove);
                return Fight(possibleMove);
            }
         
        }
        public override void Observe(Move oppo)
        {
            a = oppo;
            moveList.Add(oppo);
            if (prev.HasValue)
            {
                previousMoves[(int)prev, (int)prev2, (int)oppo]++;
            }
            prev = prev2;
            prev2 = oppo;
          //  Console.WriteLine("oppo:" + oppo);
        }
            
        public Move Fight(Move a)
        {
            switch (a)
            {
                default:
                case Move.Lizard:
                    return Move.Rock;
                case Move.Rock:
                    return Move.Paper;
                case Move.Paper:
                    return Move.Scissors;
                case Move.Scissors:
                    return Move.Spock;
                case Move.Spock:
                    return Move.Lizard;
            }
        }
    }
}
