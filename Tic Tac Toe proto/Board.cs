using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Board
	{
		private String[,] boardState;
		private bool turn;

		public bool Turn => turn;

		public Board()
		{
			boardState =  new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
			turn = true;
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

		public void UpdateBoardState(IPlayer player, Position position)
		{
			boardState.SetValue(player.Mark, position.Row, position.Column);
			turn = !turn;
		}
	}
}
