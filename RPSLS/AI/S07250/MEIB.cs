using System;

namespace RPSLS
{

    class MEIB : StudentAI
    {
        Move? a = null;
        public float b = 0f;
        public float c = 0f;

        readonly Move[] myMoves = new Move[]
        {
            Move.Scissors,
            Move.Paper,
            Move.Rock,
            Move.Lizard,
            Move.Spock
        };






        public MEIB()
        {
            Nickname = "JusBieberFan";
            CourseSection = Section.S07250;

        }

        public override void Observe(Move opponentMove)
        {
            a = opponentMove;
        }

        public override Move Play()
        {
            if (a.HasValue)
            {


                if (a.Value == Move.Rock && a.Value == Move.Spock)
                {
                    return Move.Paper;
                }

                if (a.Value == Move.Paper && a.Value == Move.Lizard)
                {
                    return Move.Scissors;
                }


                if (a.Value == Move.Paper && a.Value == Move.Spock)
                {
                    return Move.Lizard;
                }
                if (a.Value == Move.Scissors && a.Value == Move.Lizard)
                {
                    return Move.Rock;
                }
                else
                {
                    return RandomMove();
                }
            }
            else
            {
                return RandomMove();
            }


        }















    }




}
