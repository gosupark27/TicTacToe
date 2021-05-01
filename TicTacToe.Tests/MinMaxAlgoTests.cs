using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class MinMaxAlgoTests
	{
		[Theory, MemberData(nameof(SplitBoardData))]
		public void CheckMiniMax_Score(char[,] board, int depth, bool isMaximizingPlayer, int expected)
		{
			// Arrange
			MiniMaxAlgo miniMax = new MiniMaxAlgo();

			// Act
			var actual = miniMax.MiniMax(board, depth, isMaximizingPlayer);

			// Assert 
			Assert.Equal(expected, actual);
		}


		public static IEnumerable<object[]> SplitBoardData
		{

			get
			{
				Board board = new Board();

				return new[]
				{
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						9,
						true,
						0
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', 'O' }, { ' ', 'X', ' ' }, { 'O', ' ', ' ' } },
						true,
						10
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', 'X', 'O' }, { 'O', 'X',' ' }, { 'X', 'O', 'O' } },
						true,
						0
					},

				};
			}
		}
	}
}
