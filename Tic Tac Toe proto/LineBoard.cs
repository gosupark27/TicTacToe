using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class LineBoard
	{
		private char[] boardState = new char[9];
		
		public char[] BoardState { get => boardState; }

		public LineBoard(char[,] board)
		{
			FlatBoard(board);
		}

		public void FlatBoard(char[,] board)
		{
			int index = 0;
			foreach (var square in board)
			{
				boardState[index] = square;
				index++;
			}

		}
	}
}
