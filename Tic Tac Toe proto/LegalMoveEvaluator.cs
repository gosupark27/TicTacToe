using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class LegalMoveEvaluator
	{
		private readonly char[,] board;
		private bool isLegal;

		public bool IsLegal => isLegal;

		public LegalMoveEvaluator(char[,] board)
		{
			this.board = board;
		}
		
		public void CheckPosition(Position position)
		{
			var square = (char)board.GetValue(position.Row, position.Column);
			if (char.IsWhiteSpace(square))
			{
				isLegal = true;
			}
			else
			{
				isLegal = false;
			}
			
		}
	}
}
