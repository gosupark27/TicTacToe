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

		/**
		 * Representation of a 2D board square. 
		 * @constructor
		 * @param {int} row - represents the x-coordinate.
		 * @param {int} column - represents the y-coordinate.
		 */
		public Position(int row = 0, int column = 0)
		{
			this.row = row;
			this.column = column;
		}

	}
}
