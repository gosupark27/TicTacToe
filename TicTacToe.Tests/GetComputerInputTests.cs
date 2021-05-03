using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class GetComputerInputTests
	{
		[Theory, MemberData(nameof(GetGameBoardSquareData))]
		public void GetGameBoardSquare_CheckBoard(char[,] testValue, char[,] expected)
		{
			// Arrange
			GetComputerInput computerInput = new GetComputerInput(testValue);

			// Act
			
			var actual = computerInput.GetGameBoardSquare();

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
						new char[,]{ { 'X', ' ', 'O' }, { ' ', 'X', ' ' }, { 'O', ' ', ' ' } }
					},
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } }
					},
				};
			}
		}
	}
}
