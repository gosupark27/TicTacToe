using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe_proto;
using Xunit;
using Xunit.Extensions;

namespace TicTacToe.tests
{
	public class PlayerTests
	{
		//[Theory, MemberData(nameof(SplitPlayerData))]
		public void GetPosition_ReturnsCorrectPosition(int testValue, Position expected)
		{
			// Arrange
			Player player = new Player(' ');
			// Act
			//var actual = player.GetPosition(testValue);
			// Assert 
			//Assert.Equal(expected.Row, actual.Row);
			//Assert.Equal(expected.Column, actual.Column);
		}

		public static IEnumerable<object[]> SplitPlayerData
		{
			get
			{
				return new[]
				{
					new object[] {1, new Position(0,0)},
					new object[] {2, new Position(0,1)},
					new object[] {3, new Position(0,2)},
					new object[] {5, new Position(1,1)},
					new object[] {6, new Position(1,2)},
					new object[] {7, new Position(2,0)},
					new object[] {8, new Position(2,1)},
					new object[] {9, new Position(2,2)}
				};
			}
		}
	}
}
