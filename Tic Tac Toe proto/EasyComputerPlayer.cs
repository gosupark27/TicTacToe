using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class EasyComputerPlayer : IPlayer
	{
		private char mark;
		private DualConverter converter;
		private readonly IGetInput<int> _iGetInput;

		public char Mark => mark;

		public EasyComputerPlayer(IGetInput<int> iGetInput)
		{
			mark = Marks.Nought;
			_iGetInput = iGetInput;
			converter = new DualConverter();
		}

		public Position MakeMove()
		{
			var boardSquare = _iGetInput.GetGameBoardSquare();
			return converter.ConvertSquareToPosition(boardSquare);
		}
	}
}
