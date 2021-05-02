using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ComputerPlayer : IPlayer
	{
		private char mark;
		private DualConverter converter;
		private LegalMoveEvaluator LegalMoveHandler;
		private readonly IGetInput _iGetInput;
		private int turn;
		public char Mark => mark;
		public int Turn
		{
			get => turn;
			set => turn = value;
		}

		public ComputerPlayer(IGetInput iGetInput)
		{
			turn = 8;
			mark = Marks.Nought;
			_iGetInput = iGetInput;
			converter = new DualConverter();
		}

		public Position MakeMove()
		{
			var boardSquare = _iGetInput.GetGameBoardSquare();
			return converter.ConvertSquareToPosition(boardSquare);
		}

		

		public void NextTurn()
		{
			turn -= 2;
		}
	}
}
