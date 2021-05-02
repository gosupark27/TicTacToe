using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tic_Tac_Toe_proto
{
	public class GFG_MiniMax
	{
		DualConverter converter = new DualConverter();
		IPlayer player;
		//same idea as isTie tbh


		public bool CheckTerminalNode(char[,] node)
		{
			var lineBoardEval = new LineBoard(node);
			return lineBoardEval.CheckWin() || !lineBoardEval.IsMovesLeft();
		}
		// MiniMax Evaluate Func
		// Refactor: Need to have another player?? Or just pass in the player...to the func
		public double MiniMax(char[,] node, int depth, bool isMaximizer)
		{
			//player = (isMaximizer) ? new HumanPlayer(new GetHumanInput()) : new EasyComputerPlayer(new GetEasyComputerInput());

			// Based on the current boardState see if the game is in a tie, win, or loss 

			// Base case: If depth is zero or the game is over in the current board state  or check for da win! 
			//if (value == 0)
			//{
			//	return value;
			//}
			//if(value > 0 && value <= 10)
			//{
			//	return value - depth - 1;
			//}
			//if (value < 0 && value >= -10)
			//{
			//	return value + depth + 1;
			//}

			// Base case for recursive function 
			if (CheckTerminalNode(node))
			{
				var lineBoardEval = new LineBoard(node);
				//var terminalValue = (lineBoardEval.Evaluate() > 0) ? lineBoardEval.Evaluate() - depth : lineBoardEval.Evaluate() + depth;
				if (lineBoardEval.Evaluate() == 0)
					return 0;
				return lineBoardEval.Evaluate();
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

	public class LineBoard
	{
		private char[] boardState = new char[9];
		private char mark;
		private char[,] board;
		private GFG_MiniMax gfg;

		public LineBoard(char[,] board)
		{
			this.board = board;
			InitalizeLineBoard(board);
			gfg = new GFG_MiniMax();
		}

		public void InitalizeLineBoard(char[,] board)
		{
			// Refactor to its own function: Line converter
			//boardState = board.Cast<char>.ToArray();
			int index = 0;
			foreach (var square in board)
			{
				boardState[index] = square;
				index++;
			}

		}

		public bool IsMovesLeft()
		{
			foreach (var square in board)
			{
				if (char.IsWhiteSpace(square))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsThreeInARow(int i, int j, int k, char mark)
		{

			if (char.IsWhiteSpace(mark))
			{
				return false;
			}
			else if (boardState[i] == mark && boardState[j] == mark && boardState[k] == mark && !char.IsWhiteSpace(boardState[i]))
			{
				this.mark = mark;
				return true;
			}
			return false;
		}

		private bool CheckAnyLine(int start, int increment)
		{
			return IsThreeInARow(start, start + increment, start + increment + increment, boardState[start]);
		}

		private bool CheckHorizontal(int start)
		{
			return CheckAnyLine(start, 1);
		}

		private bool CheckVertical(int start)
		{
			return CheckAnyLine(start, 3);
		}

		public bool CheckWin()
		{
			return CheckHorizontal(0) || CheckHorizontal(3) || CheckHorizontal(6) ||
				  CheckVertical(0) || CheckVertical(1) || CheckVertical(2) ||
				  CheckAnyLine(0, 4) || CheckAnyLine(2, 2);
		}

		public double Evaluate()
		{
			double boardValue = 100;
			if (CheckWin())
			{
				boardValue = (this.mark == 'X') ? 10 : -10; //Math.Pow(10,9) : Math.Pow(-10, 9);
			}
			else if (!IsMovesLeft())
			{
				boardValue = 0;
			}
			return boardValue;
		}
	}
}
