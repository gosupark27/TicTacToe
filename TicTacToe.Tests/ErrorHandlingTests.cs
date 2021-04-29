using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Tic_Tac_Toe_proto;

namespace TicTacToe.tests
{
	public class ErrorHandlingTests
	{
		[Theory]
		[InlineData('1',true)]
		[InlineData('z', false)]
		[InlineData('@', false)]
		public void IsValidNumber_CheckBool(char testValue ,bool expected)
		{
			// Arrange
			ErrorHandling eHandler = new ErrorHandling();
			// Act
			var actual = eHandler.IsValidNumber(testValue);
			// Assert
			Assert.Equal(expected, actual);
		}
	}
}
