using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class HumanPlayer : IPlayer
	{
		private char mark;
		private readonly IGetInput<int> _iGetInput;
		private DualConverter converter;

		public char Mark => mark;
		
		/**
		 * Represents the human player. 
		 * @constructor 
		 * @param {IGetInput<int>} iGetInput - Gets HumanInput. 
		 */
		public HumanPlayer(IGetInput<int> iGetInput)
		{
			mark = Marks.Cross;
			_iGetInput = iGetInput;
			converter = new DualConverter();
		}

		/**
		 * Gets the board square to place a marker. 
		 */
		public Position MakeMove()
		{
			var boardSquare = _iGetInput.GetGameBoardSquare();
			return converter.ConvertSquareToPosition(boardSquare);
		}
	}
}
