using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class LineBoard
	{
		private char[] boardState = new char[9];
		
		public char[] BoardState { get => boardState; }

		/**
		 * Represents a flatten version of 2D gameboard 
		 * @constructor 
		 * @param {char[,]} board - current board state
		 */
		public LineBoard(char[,] board)
		{
			FlatBoard(board);
		}

		/**
		 * Transforms 2D board to a 1D board
		 * @param {char[,]} board - current board state
		 */
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
