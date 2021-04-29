using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Board
	{
		String[,] boardState = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
		public void DrawBoard()
		{
			Console.WriteLine("   |   |   ");
			Console.WriteLine("---+---+---");
			Console.WriteLine("   |   |   ");
			Console.WriteLine("---+---+---");
			Console.WriteLine("   |   |   ");
		}

		public String[,] BoardState
		{
			get
			{
				return boardState;
			}
			set
			{
				boardState = value;
			}
		}

		public String[,] UpdateBoardState(Position position, Player player)
		{
			if (CheckPosition(position, this.boardState))
			{
				boardState.SetValue(player.Mark, position.Row, position.Column);
			}
			return boardState;
		}

		public bool CheckPosition(Position position, String[,] board)
		{
			var square = board.GetValue(position.Row, position.Column).ToString();
			if (string.IsNullOrWhiteSpace(square))
			{
				return true;
			}
			return false;
		}
	}
}
