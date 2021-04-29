using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Screen
	{
		private string message;
		private bool showMessage;
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

		public bool ShowMessage
		{
			set
			{
				showMessage = value;
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
			Console.WriteLine($"{(showMessage ? $"\nInstructions:\n{message}\n" : "")}");
			
		}

		public void DisplayResultScreen()
		{
			Console.WriteLine(message);
		}
	}
}
