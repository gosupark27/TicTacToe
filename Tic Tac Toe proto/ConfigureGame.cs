using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ConfigureGame
	{
		public IPlayer ConfigureAIPlayer(char[,] board)
		{
			Console.WriteLine("Press 1 for Easy AI and 2 for Impossible AI");
			while (true)
			{
				var playerSelect = Console.ReadKey(true).KeyChar;
				ErrorHandling errHandler = new ErrorHandling();
				var player = (errHandler.IsValidNumber(playerSelect) && (int)char.GetNumericValue(playerSelect) == 1 || (int)char.GetNumericValue(playerSelect) == 2) ? (int)char.GetNumericValue(playerSelect) : -1;
				if (player == -1)
				{
					//Console.Clear();
					ClearLastLine();
					Console.WriteLine("Press 1 for Easy AI and 2 for Impossible AI");
				}
				else
				{
					IPlayer player2 = (playerSelect == 1) ? new EasyComputerPlayer(new GetEasyComputerInput()) : new ImpossibleComputerPlayer(new GetImpossibleComputerInput(board));
					Console.Clear();
					return player2;
				}

			}

		}

		// Refactor: Move to somewhere else? 
		public void ClearLastLine()
		{
			Console.SetCursorPosition(0, Console.CursorTop - 1);
			Console.Write(new String(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, Console.CursorTop);
		}
	}
}
