﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GetUserInput:IGetInput
	{
		private ErrorHandling errHandler;
		public GetUserInput()
		{
			errHandler = new ErrorHandling();
		}
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
