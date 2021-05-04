using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tic_Tac_Toe_proto
{
	public class MiniMaxAlgo
	{
		DualConverter converter = new();
		
		/**
		 * Checks to see if current board state ends in a tie or a win.
		 * @param {char[,]} node - The current board state. 
		 */
		private bool CheckTerminalNode(char[,] node)
		{
			var gameState = new GameState(node);
			return gameState.CheckWin() || !gameState.CheckEmptySquares();
		}
		
		/**
		 * MiniMax Algorithm
		 * @param {char[,]} node - The current board state.
		 * @param {int} depth - The depth or level of the decision tree. 
		 * @param {bool} isMaximizer - Determines whether to get max or min value.
		 */
		private double MiniMax(char[,] node, int depth, bool isMaximizer)
		{
			// Base case 
			if (CheckTerminalNode(node))
			{
				var gameState = new GameState(node);
				if (gameState.EvaluateBoard() == 0)
					return 0;
				return gameState.EvaluateBoard();
			}

			if (isMaximizer)
			{
				double maxValue = double.NegativeInfinity;
				int index = 1;
				foreach (var child in node)
				{
					if (char.IsWhiteSpace(child))
					{
						var position = converter.ConvertSquareToPosition(index);
						node[position.Row, position.Column] = 'X';
						maxValue = Math.Max(maxValue, MiniMax(node, depth + 1, false));
						node[position.Row, position.Column] = ' ';
					}
					index++;
				}
				return maxValue;
			}
			else
			{
				double minValue = double.PositiveInfinity;
				int index = 1;
				foreach (var child in node)
				{
					if (char.IsWhiteSpace(child))
					{
						var position = converter.ConvertSquareToPosition(index);
						node[position.Row, position.Column] = 'O';
						minValue = Math.Min(minValue, MiniMax(node, depth + 1, true));
						node[position.Row, position.Column] = ' ';
					}
					index++;
				}
				return minValue;
			}
		}

		/**
		 * Given the current board state, find the most optimal move.
		 * @param {char[,]} board - The current board state.
		 */
		public Position FindBestMove(char[,] board)
		{
			double bestValue = double.PositiveInfinity;
			var bestMove = new Position(-1,-1);
			int index = 1;

			foreach (var square in board)
			{
				if (char.IsWhiteSpace(square))
				{
					var position = converter.ConvertSquareToPosition(index);
					board[position.Row, position.Column] = 'O';
					double nextMoveValue = MiniMax(board, 0, true);
					board[position.Row, position.Column] = ' ';
					if (nextMoveValue < bestValue)
					{
						bestMove = position;
						bestValue = nextMoveValue;
					}
				}
				index++;
			}
			return bestMove;
		}
	}

}
