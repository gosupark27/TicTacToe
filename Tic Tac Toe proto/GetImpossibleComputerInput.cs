using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GetImpossibleComputerInput : IGetInput<char[,]>
	{
		private char[,] board;

		public GetImpossibleComputerInput(char[,] board)
		{
			this.board = board;
		}
		public char[,] GetGameBoardSquare()
		{
			return board;
		}

	}
}
