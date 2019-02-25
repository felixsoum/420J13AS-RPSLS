using System;

namespace RPSLS
{
    class DUXM : StudentAI
    {
		Move[] a = new Move[100];
		int b = 0;


		public DUXM()
        {
			Nickname = "mw";
			CourseSection = Section.S07250;
        }
		public override void Observe(Move opponentMove)
		{
			a[b++] = opponentMove;
		}

		public override Move Play()
		{
			if (b < 10)
			{
				int index = Game.SeededRandom.Next(b) % 5;
				return (Move)Enum.ToObject(typeof(Move), index);
			}
			Move flag = a[b - 1];
			int[] sum = new int[5];
			for (int i = 0; i < 5; i++)
				sum[i] = 0;
			for (int i = 0; i < b - 1; i++)
				if (a[i] == flag)
				{
					Move nextTurn = a[i + 1];
					int index = (int)(nextTurn);
					sum[index]++;
				}
			int max = 0;
			int sel = 0;
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
						if (Game.SeededRandom.Next(b) % 2 == 0) return Move.Paper;
						return Move.Spock;
					}
				case 1:
					{
						if (Game.SeededRandom.Next(b) % 2 == 0) return Move.Scissors;
						return Move.Lizard;
					}
				case 2:
					{
						if (Game.SeededRandom.Next(b) % 2 == 0) return Move.Rock;
						return Move.Spock;
					}
				case 3:
					{
						if (Game.SeededRandom.Next(b) % 2 == 0) return Move.Paper;
						return Move.Lizard;
					}
				case 4:
					{
						if (Game.SeededRandom.Next(b) % 2 == 0) return Move.Rock;
						return Move.Scissors;
					}
				default:
					break;
			}
			return Move.Rock;
		}
	}
}
