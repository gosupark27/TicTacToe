using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GetHumanInput:IGetInput<int>
	{
		private ErrorHandling errHandler;

		/**
		 * Represents input from human player. 
		 * @constructor
		 */
		public GetHumanInput()
		{
			errHandler = new ErrorHandling();
		}

		/**
		 * Retrieves the square the player wants marked.
		 */
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
