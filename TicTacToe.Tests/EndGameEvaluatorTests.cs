using System;
using System.Collections.Generic;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class EndGameEvaluatorTests
	{
		[Theory, MemberData(nameof(BoardWinData))]
		public void CheckForWin_All8Combinations(char[,] testBoard, bool expected)
		{
			// Arrange
			EndGameEvaluator gameHandler = new EndGameEvaluator(testBoard);
			// Act
			var actual = gameHandler.CheckForWin();
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
						new char[,]{ { 'X', 'X', 'X' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						true
					},
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { 'X', 'X', 'X' }, { ' ', ' ', ' ' } },
						true
					},
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { 'X', 'X', 'X' }},
						true
					},
					new object[]
					{
						new char[,]{ { ' ', 'X', ' ' }, { ' ', 'X', ' ' }, { ' ', 'X', ' ' } },
						true
					},
					new object[]
					{
						new char[,]{ { 'X', ' ', ' ' }, { 'X', ' ', ' ' }, { 'X', ' ', ' ' } },
						true
					},
					new object[]
					{
						new char[,]{ { ' ', ' ', 'X' }, { ' ', ' ', 'X' }, { ' ', ' ', 'X' } },
						true
					},
					new object[]
					{
						new char[,]{ { 'X', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', 'X' } },
						true
					},
					new object[]
					{
						new char[,]{ { ' ', ' ', 'X' }, { ' ', 'X', ' ' }, { 'X', ' ', ' ' } },
						true
					},
					new object[]
					{
						new char[,]{ { 'X', 'O', 'X' }, { 'X', 'X', 'O' }, { 'O', 'X', 'O' } },
						false
					},

				};
			}
		}

		[Theory, MemberData(nameof(BoardTieData))]
		public void CheckForTie_FullBoardIsTie(char[,] testBoard, bool expected)
		{
			// Arrange
			EndGameEvaluator checker = new EndGameEvaluator(testBoard);
			// Act
			var actual = checker.CheckForTie();
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
						board.BoardState = new char[,]{ { 'X', 'O', 'X' }, { 'X', 'X', 'O' }, { 'O', 'X', 'O' } },
						true
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', 'X' }, { 'X', ' ', 'O' }, { ' ', 'X', 'O' } },
						false
					},
				};
			}
		}
	}
}
