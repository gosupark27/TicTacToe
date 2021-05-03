using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GetHumanInput:IGetInput<int>
	{
		private ErrorHandling errHandler;
		public GetHumanInput()
		{
			errHandler = new ErrorHandling();
		}

		// Before testing this, make sure to refactor the
		// method signature as such: int GetGameBoardSquare(int)
		public int GetGameBoardSquare()
		{
			Console.WriteLine("\nMake a move:");
			var input = Console.ReadKey(true).KeyChar;

			if (!errHandler.IsValidNumber(input))
			{
				Console.WriteLine("[Error: please enter a valid number]");
				input = Console.ReadKey(true).KeyChar;
			}

			return (int)char.GetNumericValue(input);

		}
	}
}
