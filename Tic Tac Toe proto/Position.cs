using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Position
	{
		int row;
		int column;

		public int Row
		{
			get
			{
				return row;
			}
		}

		public int Column
		{
			get
			{
				return column;
			}
		}

		public Position(int row, int column)
		{
			this.row = row;
			this.column = column;
		}

	}
}
