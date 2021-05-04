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

		/**
		 * A 2D array representation of game board.
		 * @constructor
		 */
		public Board()
		{
			boardState = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
			turn = true;
		}

		/**
		 * 
		 * @param {char} mark - an 'X' or 'O'.
		 * @param {Position} position - a (row, column) representation of a board square. 
		 */
		public void UpdateBoardState(char mark, Position position)
		{
			boardState.SetValue(mark, position.Row, position.Column);
			SetTurn();
		}

		/**
		 * Keeps track of player's turns. 
		 */
		private void SetTurn()
		{
			turn = !turn;
		}
	}
}
