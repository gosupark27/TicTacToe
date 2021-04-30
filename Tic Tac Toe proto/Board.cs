using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Board:IBoard
	{
		private String[,] boardState = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
		private readonly IPlayer _player;
		private readonly IPosition _position;

		public Board(IPlayer player, IPosition position)
		{
			_player = player;
			_position = position;
		}
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

		public String[,] UpdateBoardState()
		{
			if (CheckPosition(this.boardState))
			{
				boardState.SetValue(_player.Mark, _position.Row, _position.Column);
			}
			return boardState;
		}

		public bool CheckPosition(String[,] board)
		{
			var square = board.GetValue(_position.Row, _position.Column).ToString();
			if (string.IsNullOrWhiteSpace(square))
			{
				return true;
			}
			//UpdateOptionsList();
			return false;
		}

		//private void UpdateOptionsList(Position position)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
