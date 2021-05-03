using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class GameStateTests
	{

		[Theory, MemberData(nameof(CheckWinData))]
		public void CheckWin_CurrentBoardState(char[,] testValue, bool expected)
		{
			// Arrange 
			GameState game = new GameState(testValue);
			// Act
			var actual = game.CheckWin();
			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> CheckWinData
		{
			get
			{
				return new[]
				{
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						false
					},
					// Check vertical row win 
					new object[]
					{
						new char[,]{ { 'X', 'O', ' ' }, { 'X', 'O', ' ' }, { 'X', ' ', ' ' } },
						true
					},
					// Check horizontal row win 
					new object[]
					{
						new char[,]{ { 'X', ' ', 'X' }, { 'O', 'O', 'O' }, { 'X', 'X', ' ' } },
						true
					},
					// Check diagonal row win 
					new object[]
					{
						new char[,]{ { 'X', 'O', ' ' }, { ' ', 'X', ' ' }, { 'O', ' ', 'X' } },
						true
					},
				};
			}
		}

		[Theory, MemberData(nameof(EvaluateBoardData))]
		public void EvaluateBoard_CurrentBoardState(char[,] testValue, double expected)
		{
			// Arrange 
			GameState game = new GameState(testValue);
			// Act
			var actual = game.EvaluateBoard();
			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> EvaluateBoardData
		{
			get
			{
				return new[]
				{
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						100
					},
					// Check 'X' win 
					new object[]
					{
						new char[,]{ { 'X', 'O', ' ' }, { 'X', 'O', ' ' }, { 'X', ' ', ' ' } },
						10
					},
					// Check 'O' win
					new object[]
					{
						new char[,]{ { 'X', ' ', 'X' }, { 'O', 'O', 'O' }, { 'X', 'X', ' ' } },
						-10
					},
					// Check for tie
					new object[]
					{
						new char[,]{ { 'X', 'O', 'X' }, { 'X', 'O', 'O' }, { 'O', 'X', 'O' } },
						0
					},
				};
			}
		}

		[Theory, MemberData(nameof(CheckEmptySquaresData))]
		public void CheckEmptySquares_CurrentBoardState(char[,] testValue, bool expected)
		{
			// Arrange 
			GameState game = new GameState(testValue);
			// Act
			var actual = game.CheckEmptySquares();
			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> CheckEmptySquaresData
		{
			get
			{
				return new[]
				{
					new object[]
					{
						new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						true
					},
					// 'X' wins but board is still not empty
					new object[]
					{
						new char[,]{ { 'X', 'O', ' ' }, { 'X', 'O', ' ' }, { 'X', ' ', ' ' } },
						true
					},
					new object[]
					{
						new char[,]{ { 'X', 'O', 'X' }, { 'X', 'O', 'O' }, { 'O', 'X', 'O' } },
						false
					},
				};
			}
		}
	}
}
