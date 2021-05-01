using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class MiniMaxAlgo
	{
		private EndGameEvaluator gameEval;
		private Test createBranch;

		// Need to define what type is 'position' from the video 
		// I think 'position' in the context of my program is the 'board'
		// player should be a bool? instead of IPlayer...
		// Eval should return an int!
		// Depth will start at 9 and the depth itself will decrement everytime a move is being made
		// Are we always gonna set maximingPlayer to true?

		// Rename: Evaluate()?
		public int MiniMax(char[,] board, int depth, bool isMaximizingPlayer = true)
		{
			IPlayer player = (isMaximizingPlayer) ? new HumanPlayer(new GetUserInput()) : new ComputerPlayer(new GetComputerInput());
			gameEval = new EndGameEvaluator(board);
			createBranch = new Test();
			var childNodes = createBranch.GetChildNodes(board, player);

			// Base Case
			if(depth == 0 || gameEval.Check())
			{
				return MiniMaxEvaluator.Evaluate(board);
			}
			if(isMaximizingPlayer)
			{
				int maxEval = int.MinValue;

				foreach(var node in childNodes)
				{
					// Recursive call goes here...
					var eval = MiniMax(node, depth - 1, false);
					maxEval = Math.Max(maxEval, eval);
				}
				return maxEval;
			}
			else
			{
				int minEval = int.MaxValue;
				foreach (var node in childNodes)
				{
					var eval = MiniMax(node, depth - 1, true);
					minEval = Math.Min(minEval, eval);
				}
				return minEval;
			}


		}
	}
}
