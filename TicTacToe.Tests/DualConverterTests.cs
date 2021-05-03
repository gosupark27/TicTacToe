using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;

namespace TicTacToe.tests
{
	public class DualConverterTests
	{
		[Theory, MemberData(nameof(ConvertPositionToSquareData))]
		public void ConvertPositionToSquare_CheckSquare(Position testValue, int expected)
		{
			// Arrange 
			DualConverter converter = new DualConverter();
			// Act
			var actual = converter.ConvertPositionToSquare(testValue);
			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> ConvertPositionToSquareData
		{
			get
			{
				return new[]
				{
					new object[]
					{
						new Position(0,0),
						1
					},
					new object[]
					{
						new Position(0,1),
						2
					},
					new object[]
					{
						new Position(0,2),
						3
					},
					new object[]
					{
						new Position(1,0),
						4
					},
					new object[]
					{
						new Position(1,1),
						5
					},
					new object[]
					{
						new Position(1,2),
						6
					},
					new object[]
					{
						new Position(2,0),
						7
					},
					new object[]
					{
						new Position(2,1),
						8
					},
					new object[]
					{
						new Position(2,2),
						9
					},
					new object[]
					{
						new Position(-1,-1),
						-1
					},
				};
			}
		}

		[Theory, MemberData(nameof(ConvertSquareToPositionData))]
		public void ConvertSquareToPosition_CheckPosition(int testValue, Position expected)
		{
			// Arrange 
			DualConverter converter = new DualConverter();
			// Act
			var actual = converter.ConvertSquareToPosition(testValue);
			// Assert
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> ConvertSquareToPositionData
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
