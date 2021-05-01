using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class EndGameEvaluator
	{
		private bool isAWin;
		private char[,] board;
		private char mark;

		public char Mark => mark;

		public EndGameEvaluator(char[,] board)
		{
			this.board = board;
		}

		public bool IsAWin => isAWin;
		public bool Check()
		{
			if(CheckForTie())
			{
				isAWin = false;
				return true;
			}
			if (CheckForWin())
			{
				isAWin = true;
				return true;
			}
			return false;
		}
		
		public bool CheckForTie()
		{ 
			foreach(char square in board)
			{
				if (string.IsNullOrWhiteSpace(square.ToString()))
				{
					return false;
				}
			}
			return true;
		}

		public bool CheckForWin()
		{
			bool checkWin = false;
			var oneDimBoard = board.Cast<char>().ToList<char>();
			var test = oneDimBoard.Distinct().ToList<char>();

			if (oneDimBoard.Distinct().ToList<char>().Count == 1)
			{
				return checkWin;
			}

			var winningCombo = new List<List<char>>();
			// Check the 3 rows for win 
			winningCombo.Add(oneDimBoard.Take(oneDimBoard.Count - 6).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y)).ToList<char>());
			winningCombo.Add(oneDimBoard.Skip(3).Take(oneDimBoard.Count - 6).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y)).ToList<char>());
			winningCombo.Add(oneDimBoard.Skip(6).Take(oneDimBoard.Count - 1).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y)).ToList<char>());

			var arr4 = new List<char>();
			var arr5 = new List<char>();
			var arr6 = new List<char>();

			for (int row = 0; row < board.GetLength(0); ++row)
			{
				arr4.Add(board[row, 0]);
				arr5.Add(board[row, 1]);
				arr6.Add(board[row, 2]);
			}
			// Check the 3 columns for win 
			winningCombo.Add(arr4.GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y)).ToList<char>());
			winningCombo.Add(arr5.GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y)).ToList<char>());
			winningCombo.Add(arr6.GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y)).ToList<char>());

			// Check the 2 diagonals for win 
			var arr7 = string.Concat(arr4[0].ToString(),arr5[1].ToString(),arr6[2].ToString()).ToCharArray().GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y));
			var arr8 = string.Concat(arr4[2].ToString(),arr5[1].ToString(),arr6[0].ToString()).ToCharArray().GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !char.IsWhiteSpace(y));
			if (arr7.Count() == 1)
			{
				mark = arr7.ElementAt(0);
				checkWin = true;
			}
			else if (arr8.Count() == 1)
			{
				mark = arr8.ElementAt(0);
				checkWin = true;
			}

			winningCombo.ForEach(combo => 
			{ if (combo.Count == 1) 
				{ 
					checkWin = true;
					mark = combo[0];
				}   
			});

			return checkWin;
		}
	}
}
