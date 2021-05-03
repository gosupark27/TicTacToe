using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tic_Tac_Toe_proto
{
	public class MiniMaxAlgo
	{
		DualConverter converter = new();
		
		public bool CheckTerminalNode(char[,] node)
		{
			var gameState = new GameState(node);
			return gameState.CheckWin() || !gameState.CheckEmptySquares();
		}
		// MiniMax Evaluate Func
		// Refactor: Need to have another player?? Or just pass in the player...to the func
		public double MiniMax(char[,] node, int depth, bool isMaximizer)
		{
			// Base case 
			if (CheckTerminalNode(node))
			{
				var gameState = new GameState(node);
				//var terminalValue = (lineBoardEval.Evaluate() > 0) ? lineBoardEval.Evaluate() - depth : lineBoardEval.Evaluate() + depth;
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
						// HumanPlayer.Mark or player1.Mark ('X')
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
						// ComputerPlayer.Mark or player2.Mark ('O')
						node[position.Row, position.Column] = 'O';
						minValue = Math.Min(minValue, MiniMax(node, depth + 1, true));
						node[position.Row, position.Column] = ' ';
					}
					index++;
				}
				return minValue;
			}
		}

		// Is IPlayer param necessary? Can just use isMaximizer to initialize the player type
		public Position FindBestMove(char[,] board)
		{
			// Since this is for the computer, e.g.the 'minimizer' we want the 
			// lowest possible score!
			double bestValue = double.PositiveInfinity;
			var bestMove = new Position(-1,-1);
			//if (player == null)
			//{
			//	player = (isMaximizer) ? new HumanPlayer(new GetHumanInput()) : new EasyComputerPlayer(new GetEasyComputerInput());
			//}

			int index = 1;
			foreach (var square in board)
			{
				if (char.IsWhiteSpace(square))
				{
					var position = converter.ConvertSquareToPosition(index);
					board[position.Row, position.Column] = 'O';
					// depth should be player.Turn 
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
