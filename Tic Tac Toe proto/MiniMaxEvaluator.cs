using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	// Make this class static? :O 
	// Rename: BoardValueEvaluator
	public static class MiniMaxEvaluator
	{
		private static EndGameEvaluator gameEval;

		public static int Evaluate(char[,] board)
		{
			int score = 0;
			gameEval = new EndGameEvaluator(board);
			if (gameEval.CheckForWin())
			{
				score = (gameEval.Mark == 'X') ? 10 : -10;
			}
			else if(gameEval.CheckForTie())
			{
				return score;
			}

			return score;
		}


	}
}
