using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class GFG_MiniMaxTests
	{
		[Theory, MemberData(nameof(CheckMiniMaxData))]
		public void CheckMiniMax_Score(char[,] board, int depth, bool isMaximizingPlayer, int expected)
		{
			// Arrange
			GFG_MiniMax miniMax = new GFG_MiniMax();

			// Act
			var actual = miniMax.minimax(board, depth, isMaximizingPlayer);

			// Assert 
			Assert.Equal(expected, actual);
		}


		public static IEnumerable<object[]> CheckMiniMaxData
		{

			get
			{
				Board board = new Board();

				return new[]
				{
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						0,
						true,
						0
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						0,
						false,
						0
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', 'O' }, { ' ', 'X', ' ' }, { 'O', ' ', ' ' } },
						0,
						true,
						10
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', 'X', 'O' }, { 'O', 'X',' ' }, { 'X', 'O', 'O' } },
						0,
						true,
						0
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'O', ' ', 'O' }, { ' ', 'X', ' ' }, { ' ', ' ', 'X' } },
						0,
						false,
						-10
					},

				};
			}
		}

		[Theory, MemberData(nameof(FindBestMoveData))]
		public void CheckFindBestMove(char[,] board, bool isMaximizingPlayer, Position expected, IPlayer player)
		{
			// Arrange
			GFG_MiniMax miniMax = new GFG_MiniMax();
			// Act
			var actual = miniMax.FindBestMove(board, isMaximizingPlayer, player);
			// Assert
			expected.Should().BeEquivalentTo(actual);
		}

		public static IEnumerable<object[]> FindBestMoveData
		{

			get
			{
				Board board = new Board();
				return new[]
				{
					new object[]
					{
						board.BoardState = new char[,]{{ 'X', 'O', 'X' },{ 'O', 'O', 'X' },{ 'X', ' ', ' ' }},
						false,
						new Position(2,1),
						new EasyComputerPlayer(new GetHumanInput())
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', 'O', 'O' }, { 'X', 'O', ' ' }, { ' ', 'X', 'X' } },
						false,
						new Position(2,0),
						new EasyComputerPlayer(new GetHumanInput())
					},
					
					
				};
			}
		}
	}
}
