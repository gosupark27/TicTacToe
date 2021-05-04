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

		/**
		 * Represents the board configuration.
		 * @constructor
		 * @param {char[,]} board - current board state.
		 */
		public GameState(char[,] board)
		{
			lineBoard = new LineBoard(board);
			this.board = board;
		}

		/**
		 * Check to see if board is full or not.
		 */
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

		/**
		 * Verifies if there is a winning row for player.
		 * @param {int} i - index of first square. 
		 * @param {int} j - index of second square.
		 * @param {int} k - index of third square.
		 * @param {char} mark - an 'X' or 'O'.
		 */
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

		/**
		 * Finds a row and checks to see if it is a winning row.
		 * @param {int} start - the starting point of row/line.
		 * @param {int} increment - determines which row to inspect.
		 */
		private bool CheckAnyLine(int start, int increment)
		{
			return IsThreeInARow(start, start + increment, start + increment + increment, lineBoard.BoardState[start]);
		}

		/**
		 * Retrieves one of the three horizontal rows.
		 * @param {int} start - starting point of row.
		 */
		private bool CheckHorizontal(int start)
		{
			return CheckAnyLine(start, 1);
		}

		/**
		 * Retrieves one of the three vertical rows.
		 * @param {int} start - starting point of row.
		 */
		private bool CheckVertical(int start)
		{
			return CheckAnyLine(start, 3);
		}

		/**
		 * Check all eight winning rows.
		 */
		public bool CheckWin()
		{
			return CheckHorizontal(0) || CheckHorizontal(3) || CheckHorizontal(6) ||
				  CheckVertical(0) || CheckVertical(1) || CheckVertical(2) ||
				  CheckAnyLine(0, 4) || CheckAnyLine(2, 2);
		}

		/**
		 * Returns a value for terminal game state or default value if 
		 * the game can be continued. 
		 */
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
