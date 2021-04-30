using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class EndGameEvaluator
	{
		private bool isAWin;
		private String[,] board;

		public EndGameEvaluator(String[,] board)
		{
			this.board = board;
		}

		public bool IsAWin => isAWin;
		public bool Check()
		{
			if(CheckForTie(this.board))
			{
				isAWin = false;
				return true;
			}
			if (CheckForWin(this.board))
			{
				isAWin = true;
				return true;
			}
			return false;
		}
		
		public bool CheckForTie(String[,] board)
		{ 
			foreach(string square in board)
			{
				if (string.IsNullOrWhiteSpace(square))
				{
					return false;
				}
			}
			return true;
		}

		public bool CheckForWin(String[,] board)
		{
			bool checkWin = false;
			var oneDimBoard = board.Cast<String>().ToList<String>();
			var test = oneDimBoard.Distinct().ToList<String>();

			if (oneDimBoard.Distinct().ToList<String>().Count == 1)
			{
				return checkWin;
			}

			var winningCombo = new List<List<String>>();
			// Check the 3 rows for win 
			winningCombo.Add(oneDimBoard.Take(oneDimBoard.Count - 6).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y)).ToList<String>());
			winningCombo.Add(oneDimBoard.Skip(3).Take(oneDimBoard.Count - 6).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y)).ToList<String>());
			winningCombo.Add(oneDimBoard.Skip(6).Take(oneDimBoard.Count - 1).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y)).ToList<String>());

			var arr4 = new List<String>();
			var arr5 = new List<String>();
			var arr6 = new List<String>();

			for (int row = 0; row < board.GetLength(0); ++row)
			{
				arr4.Add(board[row, 0]);
				arr5.Add(board[row, 1]);
				arr6.Add(board[row, 2]);
			}
			// Check the 3 columns for win 
			winningCombo.Add(arr4.GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y)).ToList<String>());
			winningCombo.Add(arr5.GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y)).ToList<String>());
			winningCombo.Add(arr6.GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y)).ToList<String>());

			// Check the 2 diagonals for win 
			if(string.Concat(arr4[0].Concat(arr5[1]).Concat(arr6[2])).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y.ToString())).Count() == 1)
			{
				checkWin = true;
			}
			else if (string.Concat(arr4[2].Concat(arr5[1]).Concat(arr6[0])).GroupBy(x => x).Where(g => g.Count() == 3).Select(x => x.Key).Where(y => !string.IsNullOrWhiteSpace(y.ToString())).Count() == 1)
			{
				checkWin = true;
			}

			winningCombo.ForEach(combo => { if (combo.Count == 1) checkWin = true; });

			return checkWin;
		}
	}
}
