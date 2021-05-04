using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GetComputerInput : IGetInput<char[,]>
	{
		private char[,] board;

		public char[,] Board
		{
			get => board;
		}

		/**
		 * Represents the input from computer. 
		 * @constructor
		 */
		public GetComputerInput(char[,] board)
		{
			this.board = board;
		}

		/**
		 * Gets the current board state.
		 */
		public char[,] GetGameBoardSquare()
		{
			return board;
		}
	}
}
