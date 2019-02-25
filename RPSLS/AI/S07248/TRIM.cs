using System;
using System.Collections.Generic;

namespace RPSLS
{

	class TRIM : StudentAI
	{

		public Move a;
		public int b;
		public int c = 0;
		public Move[] d = new Move[5];
		public Move e;

		public TRIM()
		{
			this.Nickname = "Minh";
			this.CourseSection = Section.S07248;
		}

		public override void Observe(Move opponentMove)
		{
			c++;
			a = opponentMove;            
		}

		private void GetOpponentCurrentMove()
		{
			b = c % 5;
			d[b] = a;
            
			if (b < d.Length - 1) {
				e = d[b + 1];
			} else {
				e = d[0];
			}
            
		}


		public override Move Play()
		{
			GetOpponentCurrentMove();

			if (e == Move.Rock) {
				return Move.Paper;
			}
			else if (e == Move.Paper)
			{
				return Move.Scissors;
			}
			else if (e == Move.Scissors)
			{
				return Move.Rock;
			}
			else if (e == Move.Lizard)
			{
				return Move.Rock;
			}
			else if (e == Move.Spock)
			{
				return Move.Paper;
			} else {
				return RandomMove();
			}
		}
	}
}
