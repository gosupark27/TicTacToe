using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class LegalMoveEvaluatorTests
	{
		[Theory, MemberData(nameof(SplitBoardData))]
		public void CheckPosition_EmptyOrTaken(Position testPosition, char[,] testBoard, bool expected)
		{
			// Arrange
			LegalMoveEvaluator moveHandler = new LegalMoveEvaluator(testBoard);
			// Act
			moveHandler.CheckPosition(testPosition);
			var actual = moveHandler.IsLegal;
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
						board.BoardState = new char[,]{ { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						true
					},
					new object[]
					{
						new Position(0,0),
						board.BoardState = new char[,]{ { 'X', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } },
						false
					},
					new object[]
					{
						new Position(1,1),
						board.BoardState = new char[,]{ { 'X', 'O', 'X' }, { 'X', 'X', 'O' }, { 'O', 'X', 'O' } },
						false
					},

				};
			}
		}
	}
}
