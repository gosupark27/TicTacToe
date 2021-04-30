using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class ConditionsCheckerTests
	{
		[Theory, MemberData(nameof(BoardWinData))]
		public void CheckForWin_All8Combinations(String[,] testBoard, bool expected)
		{
			// Arrange
			EndGameEvaluator checker = new ConditionsChecker();
			// Act
			var actual = checker.CheckForWin(testBoard);
			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> BoardWinData
		{

			get
			{
				Board board = new Board();

				return new[]
				{
					new object[]
					{
						new string[,]{ { "X", "X", "X" }, { " ", " ", " " }, { " ", " ", " " } },
						true
					},
					new object[]
					{
						new string[,]{ { " ", " ", " " }, { "X", "X", "X" }, { " ", " ", " " } },
						true
					},
					new object[]
					{
						new string[,]{ { " ", " ", " " }, { " ", " ", " " }, { "X", "X", "X" } },
						true
					},
					new object[]
					{
						new string[,]{ { " ", "X", " " }, { " ", "X", " " }, { " ", "X", " " } },
						true
					},
					new object[]
					{
						new string[,]{ { "X", " ", " " }, { "X", " ", " " }, { "X", " ", " " } },
						true
					},
					new object[]
					{
						new string[,]{ { " ", " ", "X" }, { " ", " ", "X" }, { " ", " ", "X" } },
						true
					},
					new object[]
					{
						new string[,]{ { "X", " ", " " }, { " ", "X", " " }, { " ", " ", "X" } },
						true
					},
					new object[]
					{
						new string[,]{ { " ", " ", "X" }, { " ", "X", " " }, { "X", " ", " " } },
						true
					},
					new object[]
					{
						new string[,]{ { "X", "O", "X" }, { "X", "X", "O" }, { " O", "X", "O" } },
						false
					},

				};
			}
		}

		[Theory, MemberData(nameof(BoardTieData))]
		public void CheckForTie_FullBoardIsTie(String[,] testBoard, bool expected)
		{
			// Arrange
			EndGameEvaluator checker = new ConditionsChecker();
			// Act
			var actual = checker.CheckForTie(testBoard);
			// Assert 
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> BoardTieData
		{

			get
			{
				Board board = new Board();

				return new[]
				{
					new object[]
					{
						board.BoardState = new string[,]{ { "X", "O", "X" }, { "X", "X", "O" }, { " O", "X", "O" } },
						true
					},
					new object[]
					{
						board.BoardState = new string[,]{ { "X", " ", "X" }, { " ", "O", " " }, { " ", "X", " " } },
						false
					},
				};
			}
		}
	}
}
