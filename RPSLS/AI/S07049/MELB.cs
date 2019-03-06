using System;
using System.Collections.Generic;
namespace RPSLS
{
    class MELB : StudentAI
    {
        public MELB()
        {
            Nickname = "Nanith Omicron";
            a = 69420;
            CourseSection = Section.S07049;
        }
        int a = 0;
        int b = 1;
        int c = 0;


        Move counterMove(Move z)
        {

            int ah = ((int)z - 1);
            ah %= 5;


            return (Move)Math.Abs(ah);
        }

        Move[] lol = new Move[3];

        public override void Observe(Move opponentMove)
        {

            for (int i = 1; i < lol.Length; i++)
                lol[i - 1] = lol[i];


            lol[lol.Length - 1] = opponentMove;
            var z = true;
            foreach (var item in lol)
                if (item != Move.Rock) z = false;
            if (z) { c = 3; return; }
            if (b <= 2) return;
            if (((int)lol[0] + (int)lol[1] + (int)lol[2]) / 3 == (int)lol[0]) c = 1;
            if (lol[2] == (counterMove(lol[1])))
                ok++;
            if (ok >= 3) { c = 2; rr = (int)opponentMove; }





        }
        int ok = 0;
        int rr = 0;
        public override Move Play()
        {
            b++;
            if (b % 10 == 0) return RandomMove();

            if (b == 1) Console.WriteLine("Nanith Omicron: From now on, Alea iacta est. There is little to no random tho. /n");
            if (b <= 2)
                return Move.Scissors;

            switch (c)
            {
                case 1:
                    return counterMove(lol[0] - 1);
                case 2:
                    return counterMove((Move)rr++ + 1);
                case 3:
                    return counterMove(lol[1] + 2);
                default:
                    return counterMove(lol[1]);
            }


        }


    }
}
