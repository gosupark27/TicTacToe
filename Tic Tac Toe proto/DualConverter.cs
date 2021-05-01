using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class DualConverter
	{
		public int ConvertPositionToSquare(Position position)
		{
			if (position.Row == 0 && position.Column == 0) { return 1; }
			else if (position.Row == 0 && position.Column == 1) { return 2; }
			else if (position.Row == 0 && position.Column == 2) { return 3; }
			else if (position.Row == 1 && position.Column == 0) { return 4; }
			else if (position.Row == 1 && position.Column == 1) { return 5; }
			else if (position.Row == 1 && position.Column == 2) { return 6; }
			else if (position.Row == 2 && position.Column == 0) { return 7; }
			else if (position.Row == 2 && position.Column == 1) { return 8; }
			else if (position.Row == 2 && position.Column == 2) { return 9; }
			else { return -1; }
		}
		public Position ConvertSquareToPosition(int square)
		{
			switch (square)
			{
				case 0: return new Position(0, 0);
				case 1: return new Position(0, 1);
				case 2: return new Position(0, 2);
				case 3: return new Position(1, 0);
				case 4: return new Position(1, 1);
				case 5: return new Position(1, 2);
				case 6: return new Position(2, 0);
				case 7: return new Position(2, 1);
				case 8: return new Position(2, 2);
				default: return null;
			}
		}
	}
}
