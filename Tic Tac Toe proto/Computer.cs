using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Computer
	{
		List<int> options = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		String[,] boardState;
		//Board board;
		private readonly IBoard _board;
		private readonly IPlayer _player;
		private readonly IPosition _position;
		public Computer(IBoard board, IPlayer player, IPosition position)
		{
			_board = board;
			_player = player;
			_position = position;
			this.boardState = _board.BoardState;

		}

		public String[,] MakeMove()
		{
			Random random = new Random();
			int col = random.Next(0, 2);
			int row = random.Next(0, 2);

			while (!_board.CheckPosition(this.boardState))
			{
				col = random.Next(0, 2);
				row = random.Next(0, 2);
			}


			return _board.UpdateBoardState();
		}


	}
}

