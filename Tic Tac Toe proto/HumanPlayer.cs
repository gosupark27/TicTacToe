using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class HumanPlayer : IPlayer
	{
		private String mark;
		private readonly IGetInput _iGetInput;
		private DualConverter converter;
		public string Mark => mark;

		public HumanPlayer(IGetInput iGetInput)
		{
			mark = Marks.Cross;
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
