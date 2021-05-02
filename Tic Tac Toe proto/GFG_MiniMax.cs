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
		public bool isMovesLeft(char[,] board)
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

		// MiniMax Evaluate Func
		// Refactor: Need to have another player?? Or just pass in the player...to the func
		public double minimax(char[,] board, int depth, bool isMaximizer)
		{
			player = (isMaximizer) ? new HumanPlayer(new GetHumanInput()) : new EasyComputerPlayer(new GetEasyComputerInput());
			
			// Based on the current boardState see if the game is in a tie, win, or loss 
			var lineBoardEval = new LineBoard(board);
			double value = lineBoardEval.Evaluate();

			if (value == 0 )
			{
				return value;
			}
			else if (value%10 == 0)
			{
				return value / Math.Pow(10, (double)depth);
			}

			if (isMaximizer)
			{
				double maxEval = double.NegativeInfinity;
				int index = 0;
				foreach (var square in board)
				{
					// Pretty sure we are DRY & making an extra move for the player 
					if (char.IsWhiteSpace(square))
					{
						var position = converter.ConvertSquareToPosition(index);
						// HumanPlayer.Mark or player1.Mark
						board[position.Row, position.Column] = player.Mark;
						var eval = minimax(board, depth + 1, !isMaximizer);
						board[position.Row, position.Column] = ' ';
						maxEval = Math.Max(maxEval, eval);
					}
					index++;
				}
				return maxEval;
			}
			else
			{
				double minEval = double.PositiveInfinity;
				int index = 0;
				foreach (var square in board)
				{
					if (char.IsWhiteSpace(square))
					{
						var position = converter.ConvertSquareToPosition(index);
						// ComputerPlayer.Mark or player2.Mark
						board[position.Row, position.Column] = player.Mark;
						var eval = minimax(board, depth + 1, !isMaximizer);
						board[position.Row, position.Column] = ' ';
						minEval = Math.Min(minEval, eval);
					}
					index++;
				}
				return minEval;
			}
		}

		public Position FindBestMove(char[,] board, bool isMaximizer, IPlayer player = null)
		{
			// Since this is for the computer, e.g.the 'minimizer' we want the 
			// loweest possible score!
			double bestValue = double.PositiveInfinity;	
			var bestMove = new Position();
			if (player == null)
			{
				player = (isMaximizer) ? new HumanPlayer(new GetHumanInput()) : new EasyComputerPlayer(new GetEasyComputerInput());
			}

			int index = 0;
			foreach (var square in board)
			{
				if (char.IsWhiteSpace(square))
				{
					var position = converter.ConvertSquareToPosition(index);
					board[position.Row, position.Column] = player.Mark;
					// depth should be player.Turn 
					double nextMoveValue = minimax(board, 0, isMaximizer);
					board[position.Row, position.Column] = ' ';
					if (nextMoveValue <= bestValue)
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
			double boardValue = 7;
			if (CheckWin())
			{
				boardValue = (this.mark == 'X') ? Math.Pow(10,9) : Math.Pow(-10, 9);
			}
			else if (!gfg.isMovesLeft(board))
			{
				boardValue = 0;
			}
			return boardValue;
		}
	}
}
