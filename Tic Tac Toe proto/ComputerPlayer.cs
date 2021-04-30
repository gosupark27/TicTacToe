using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ComputerPlayer : IPlayer
	{
		private string mark;
		private DualConverter converter;
		private LegalMoveEvaluator LegalMoveHandler;
		private readonly IGetInput _iGetInput;
		public string Mark => mark;

		public ComputerPlayer(IGetInput iGetInput)
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
