using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class LegalMoveEvaluator
	{
		private readonly string[,] board;
		private bool isLegal;

		public bool IsLegal => isLegal;

		public LegalMoveEvaluator(string[,] board)
		{
			this.board = board;
		}
		
		public void CheckPosition(Position position)
		{
			var square = board.GetValue(position.Row, position.Column).ToString();
			if (string.IsNullOrWhiteSpace(square))
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
