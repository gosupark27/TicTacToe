using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Board
	{
		private char[,] boardState;
		private bool turn;

		public bool Turn => turn;

		public char[,] BoardState
		{
			set => boardState = value;
			get => boardState;
		}

		public Board()
		{
			boardState = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
			turn = true;
		}

		public Board(char[,] board)
		{
			boardState = board;
			turn = true;
		}

		public void UpdateBoardState(char mark, Position position)
		{
			boardState.SetValue(mark, position.Row, position.Column);
			SetTurn();
		}

		private void SetTurn()
		{
			turn = !turn;
		}
	}
}
