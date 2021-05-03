using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ComputerPlayer : IPlayer
	{
		private char mark;
		private readonly IGetInput<char[,]> _iGetInput;
		private MiniMaxAlgo miniMax;
		private char[,] board;
		public char Mark => mark;


		public ComputerPlayer(IGetInput<char[,]> iGetInput)
		{
			mark = Marks.Nought;
			_iGetInput = iGetInput;
			miniMax = new MiniMaxAlgo();
			board = _iGetInput.GetGameBoardSquare();
		}


		public Position MakeMove()
		{
			return miniMax.FindBestMove(board);
		}

	}
}
