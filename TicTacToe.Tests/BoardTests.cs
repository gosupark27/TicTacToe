using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class BoardTests
	{
		[Theory, MemberData(nameof(SplitBoardData))]
		public void CheckPosition_EmptyorTaken(Position testPosition, String[,] testBoard, bool expected)
		{
			// Arrange
			Board board = new Board();
			// Act
			var actual = board.CheckPosition(testPosition, testBoard);
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
						new Position(0,0),
						board.BoardState = new string[,]{ { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } },
						true
					},
					new object[]
					{
						new Position(0,0),
						board.BoardState = new string[,]{ { "X", " ", " " }, { " ", " ", " " }, { " ", " ", " " } },
						false
					},
					new object[]
					{
						new Position(1,1),
						board.BoardState = new string[,]{ { "X", "X", "O" }, { "O", "X", "O" }, { "X", "O", "O" } },
						false
					},

				};
			}
		}
	}
}

