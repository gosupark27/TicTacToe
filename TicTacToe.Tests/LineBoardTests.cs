using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class LineBoardTests
	{
		[Theory, MemberData(nameof(GetGameBoardSquareData))]
		public void FlatBoard_CheckBoard(char[,] testValue, char[] expected)
		{
			// Arrange
			LineBoard lineBoard = new LineBoard(testValue);

			// Act
			lineBoard.FlatBoard(testValue);
			var actual = lineBoard.BoardState;

			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetGameBoardSquareData
		{
			get
			{
				return new[]
				{
					new object[]
					{
						new char[,]{ { 'X', ' ', 'O' }, { ' ', 'X', ' ' }, { 'O', ' ', ' ' } },
						new char[]{ 'X', ' ', 'O' , ' ', 'X', ' ' , 'O', ' ', ' '  }
					},
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						new char[]{  ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
					},
				};
			}
		}
	}
}
