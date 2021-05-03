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

		public GetComputerInput(char[,] board)
		{
			this.board = board;
		}
		public char[,] GetGameBoardSquare()
		{
			return board;
		}
	}
}
