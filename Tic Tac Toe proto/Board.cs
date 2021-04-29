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
		}

		public String[,] UpdateBoardState(Position position, Player player)
		{
			if (CheckPosition(position))
			{
				boardState.SetValue(player.Mark, position.Row, position.Column);
			}
			return boardState;
		}

		public bool CheckPosition(Position position)
		{
			var square = boardState.GetValue(position.Row, position.Column).ToString();
			if (string.IsNullOrWhiteSpace(square))
			{
				return true;
			}
			return false;
		}
	}
}
