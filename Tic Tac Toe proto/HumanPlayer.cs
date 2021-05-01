using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class HumanPlayer : IPlayer
	{
		private char mark;
		private readonly IGetInput _iGetInput;
		private DualConverter converter;
		private int turn;
		public char Mark => mark;
		public int Turn
		{
			get => turn;
			set => turn = value;
		}
		

		public HumanPlayer(IGetInput iGetInput)
		{
			turn = 9;
			mark = Marks.Cross;
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
