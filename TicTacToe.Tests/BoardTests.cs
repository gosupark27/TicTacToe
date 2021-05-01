using FluentAssertions;
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
		public void UpdateBoardState_WithMarker(char[,] testBoard, char[,] expected, Position testPosition, IPlayer player)
		{
			// Arrange
			Board board = new Board();
			board.BoardState = testBoard;
			// Act
			board.UpdateBoardState(player.Mark, testPosition);
			var actual = board.BoardState;
			// Assert 
			expected.Should().BeEquivalentTo(actual);
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
						board.BoardState = new char[,]{ { 'X', ' ', 'O' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						board.BoardState = new char[,]{ { 'X', ' ', 'O' }, { 'X', ' ', ' ' }, { ' ', ' ', ' ' } },
						new Position(1,0),
						new HumanPlayer(new GetUserInput())
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', 'O', ' ' }, { ' ', ' ', ' ' } },
						new Position(1,1),
						new ComputerPlayer(new GetComputerInput())
					},
					new object[]
					{
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						board.BoardState = new char[,]{ { 'O', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						new Position(0,0),
						new ComputerPlayer(new GetComputerInput())
					},
				};
			}
		}
	}
}

