using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ScreenRenderer
	{
		private string message;
		public String Message
		{
			get
			{
				return message;
			}
			set
			{
				message = value;
			}
		}
		public void DisplayExampleScreen()
		{
			Console.WriteLine("Let's play a game of Tic Tac Toe!\n");
			Console.WriteLine(" 1 | 2 | 3 ");
			Console.WriteLine("---+---+---");
			Console.WriteLine(" 4 | 5 | 6 ");
			Console.WriteLine("---+---+---");
			Console.WriteLine(" 7 | 8 | 9 ");
			Console.WriteLine($"\nInstructions:\n{message}\n");
			
		}

		public void DisplayResultScreen()
		{
			Console.WriteLine(message);
		}

		public void DisplayErrorScreen()
		{
			Console.Clear();
			DisplayExampleScreen();
			Console.WriteLine("[ERROR: Invalid square - Please pick an empty square to mark.]\n");
		}
	}
}
