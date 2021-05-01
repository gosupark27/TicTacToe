using System;

namespace Tic_Tac_Toe_proto
{
	class Program
	{

		static void Main(string[] args)
		{
			// WELCOME SCREEN
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
					// NEW GAME
					Console.Clear();
					scrn.ShowMessage = true;
					scrn.DisplayExampleScreen();
					BoardRenderer br = new BoardRenderer();
					br.DrawEmptyBoard();

					// Initialize players & assets
					HumanPlayer player1 = new HumanPlayer(new GetUserInput());
					ComputerPlayer player2 = new ComputerPlayer(new GetComputerInput());
					Board gameBoard = new Board();
					EndGameEvaluator gameEvaluator = new EndGameEvaluator(gameBoard.BoardState);
					LegalMoveEvaluator LegalMoveHandler = new LegalMoveEvaluator(gameBoard.BoardState);

					while (!gameEvaluator.Check())
					{
						var move = (gameBoard.Turn) ? player1.MakeMove() : player2.MakeMove();
						LegalMoveHandler.CheckPosition(move);

						while(!LegalMoveHandler.IsLegal)
						{
							scrn.DisplayErrorScreen();
							br.RenderBoard(gameBoard.BoardState);
							if (gameBoard.Turn)
							{	
								move = player1.MakeMove();
							}
							else
							{
								move = player2.MakeMove();
							}
							LegalMoveHandler.CheckPosition(move);
						}

						if (LegalMoveHandler.IsLegal && gameBoard.Turn)
						{
							gameBoard.UpdateBoardState(player1.Mark, move);
						}
						else
						{
							gameBoard.UpdateBoardState(player2.Mark, move);
						}
						
						Console.Clear();
						scrn.DisplayExampleScreen();
						br.RenderBoard(gameBoard.BoardState);

					}
					scrn.Message = (gameEvaluator.IsAWin) ? "\nWe have a winner!" : "\nGame Over! Cat's game.";
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
