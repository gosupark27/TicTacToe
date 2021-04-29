using System;

namespace Tic_Tac_Toe_proto
{
	class Program
	{

		static void Main(string[] args)
		{
			Screen scrn = new Screen();
			scrn.ShowMessage = false;
			scrn.Message = "In order to place your marker on a particular square press 1 - 9";
			scrn.DisplayExampleScreen();
			Console.WriteLine("Press enter to start a new game");
			var key = Console.ReadKey(true).Key;
			while (true)
			{

				if (key == ConsoleKey.Enter)
				{
					Console.Clear();
					scrn.ShowMessage = true;
					scrn.DisplayExampleScreen();
					Board board = new Board();
					board.DrawBoard();
					BoardRenderer br = new BoardRenderer();
					ConditionsChecker checker = new ConditionsChecker();
					ErrorHandling eHandle = new ErrorHandling();
					int turn = 0;
					while (!checker.Check(board.BoardState))
					{

						Console.WriteLine("\nMake a move:");
						var input = Console.ReadKey(true).KeyChar;
						if (eHandle.IsValidNumber(input))
						{
							int boardCell = (int)char.GetNumericValue(input);
							if (turn % 2 == 0)
							{
								Player p1 = new Player(Marks.Nought);
								if (board.CheckPosition(p1.GetPosition(boardCell)))
								{
									var newBoard = board.UpdateBoardState(p1.GetPosition(boardCell), p1);
									Console.Clear();
									scrn.DisplayExampleScreen();
									br.RenderBoard(newBoard);
									turn++;
								}
								else
								{
									Console.Clear();
									scrn.DisplayExampleScreen();
									Console.WriteLine("Invalid square. Please pick an empty square to mark.");
									br.RenderBoard(board.BoardState);
								}
							}
							else
							{
								Player p2 = new Player(Marks.Cross);
								if (board.CheckPosition(p2.GetPosition(boardCell)))
								{
									var newBoard = board.UpdateBoardState(p2.GetPosition(boardCell), p2);
									Console.Clear();
									scrn.DisplayExampleScreen();
									br.RenderBoard(newBoard);
									turn++;
								}
								else
								{
									Console.Clear();
									scrn.DisplayExampleScreen();
									Console.WriteLine("Invalid square. Please pick an empty square to mark.");
									br.RenderBoard(board.BoardState);
								}


							}
						}
						else
						{
							Console.WriteLine("[Error: please enter a valid number]");
						}
					}
					scrn.Message = (checker.IsWin) ? "We have a winner!" : "Game Over! Cat's game.";
					scrn.DisplayResultScreen();
					break;
				}
				else
				{
					Console.WriteLine("\nPlease press enter to continue:");
					key = Console.ReadKey(true).Key;
				}
			}
		}
	}

}
