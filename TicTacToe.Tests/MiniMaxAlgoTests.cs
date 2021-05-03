using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class MiniMaxAlgoTests
	{

		[Theory, MemberData(nameof(FindBestMoveData))]
		public void FindBestMove_BasedOnBoardState(char[,] testValue, Position expected)
		{
			// Arrange
			MiniMaxAlgo miniMax = new MiniMaxAlgo();
			// Act
			var actual = miniMax.FindBestMove(testValue);
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
					// Check corner openings
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						new Position(1,1)
					},
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { 'X', ' ', ' ' } },
						new Position(1,1)
					},
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', 'X' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						new Position(1,1)
					},
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', 'X' } },
						new Position(1,1)
					},
					// Check center opening
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', 'X', ' ' }, { ' ', ' ', ' ' } },
						new Position(0,0)
					},
					// Check edge openings 
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', 'X', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						new Position(0,0)
					},
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { 'X', ' ', ' ' }, { ' ', ' ', ' ' } },
						new Position(0,0)
					},
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', 'X', ' ' } },
						new Position(0,1)
					},
					new object[]
					{
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', 'X' }, { ' ', ' ', ' ' } },
						new Position(0,2)
					},
					// Go for the win 
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', 'O', ' ' }, { ' ', 'O', 'X' }, { 'X', ' ', ' ' } },
						new Position(2,1)
					},
					// Block opponent from winning
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', 'O', ' ' }, { 'X', ' ', ' ' } },
						new Position(1,0)
					},


				};
			}
		}
	}
}
