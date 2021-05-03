using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GameState
	{
		private LineBoard lineBoard;
		private readonly char[,] board;
		private char mark;
		public GameState(char[,] board)
		{
			lineBoard = new LineBoard(board);
			this.board = board;
		}

		public bool CheckEmptySquares()
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
			else if (lineBoard.BoardState[i] == mark && lineBoard.BoardState[j] == mark && lineBoard.BoardState[k] == mark && !char.IsWhiteSpace(lineBoard.BoardState[i]))
			{
				this.mark = mark;
				return true;
			}
			return false;
		}

		private bool CheckAnyLine(int start, int increment)
		{
			return IsThreeInARow(start, start + increment, start + increment + increment, lineBoard.BoardState[start]);
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
		public double EvaluateBoard()
		{
			double boardValue = 100;
			if (CheckWin())
			{
				boardValue = (this.mark == 'X') ? 10 : -10;
			}
			else if (!CheckEmptySquares())
			{
				boardValue = 0;
			}
			return boardValue;
		}
	}
}
