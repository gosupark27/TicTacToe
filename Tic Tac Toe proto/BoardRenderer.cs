using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class BoardRenderer
	{
		/**
		 * Displays game board of a new game.
		 */
		public void DrawEmptyBoard()
		{
			Console.WriteLine("   |   |   ");
			Console.WriteLine("---+---+---");
			Console.WriteLine("   |   |   ");
			Console.WriteLine("---+---+---");
			Console.WriteLine("   |   |   ");
		}

		/**
		 * Renders a new board that reflect the board state.
		 * @param {char[,]} board - the current board state. 
		 */
		public void RenderBoard(char[,] board)
		{
			Console.WriteLine($" {board[0,0]} | {board[0,1]} | {board[0,2]} ");
			Console.WriteLine("---+---+---");
			Console.WriteLine($" {board[1,0]} | {board[1,1]} | {board[1,2]} ");
			Console.WriteLine("---+---+---");
			Console.WriteLine($" {board[2,0]} | {board[2,1]} | {board[2,2]} ");
		}
	}
}
