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

		// For now in order to see if the helper function will work...
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

		// Refactor: Need shallow copies of the board b/c we need to populate the child node list for possible boardstates
		public Board ShallowCopy()
		{
			return (Board)this.MemberwiseClone();
		}

		public void UpdateBoardState(char mark, Position position)
		{
			boardState.SetValue(mark, position.Row, position.Column);
			// Maybe call a SetTurn() method? instead of having this side effect yikes.
			turn = !turn;
		}
	}
}
