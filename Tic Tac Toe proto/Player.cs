using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Player
	{
		string mark;
		bool turn;

		public Player(String mark)
		{
			this.mark = mark;
		}

		public bool Turn
		{
			get
			{
				return turn;
			}
			set
			{
				turn = value;
			}
		}

		public String Mark
		{
			get
			{
				return mark;
			}
		}
		public Position GetPosition(int selectedNum)
		{
			switch (selectedNum)
			{
				case 1: return new Position(0, 0);
				case 2: return new Position(0, 1);
				case 3: return new Position(0, 2);
				case 4: return new Position(1, 0);
				case 5: return new Position(1, 1);
				case 6: return new Position(1, 2);
				case 7: return new Position(2, 0);
				case 8: return new Position(2, 1);
				case 9: return new Position(2, 2);
				default: return null;
			}
		}
	}
}
