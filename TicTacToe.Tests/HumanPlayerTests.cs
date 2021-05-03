using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class HumanPlayerTests
	{
		[Theory, MemberData(nameof(MakeMoveData))]

		public void MakeMove_CheckPosition(int testValue, Position expected)
		{
			// Arrange
			var humanInputMock = new Mock<IGetInput<int>>();
			humanInputMock.Setup(p => p.GetGameBoardSquare()).Returns(testValue);
			HumanPlayer player = new HumanPlayer(humanInputMock.Object);

			// Act 
			var actual = player.MakeMove();

			// Assert
			expected.Should().BeEquivalentTo(actual);
		}

		public static IEnumerable<object []> MakeMoveData
		{
			get
			{
				return new[]
				{
					new object[]
					{
						1,
						new Position(0,0)
					},
					new object[]
					{
						2,
						new Position(0,1)
					},
					new object[]
					{
						3,
						new Position(0,2)
					},
					new object[]
					{
						4,
						new Position(1,0)
					},
					new object[]
					{
						5,
						new Position(1,1)
					},
					new object[]
					{
						6,
						new Position(1,2)
					},
					new object[]
					{
						7,
						new Position(2,0)
					},
					new object[]
					{
						8,
						new Position(2,1)
					},
					new object[]
					{
						9,
						new Position(2,2)
					},
					new object[]
					{
						10,
						null
					},
				};
			}
		}
	}
}
