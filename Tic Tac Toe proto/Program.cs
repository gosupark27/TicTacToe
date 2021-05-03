using System;

namespace Tic_Tac_Toe_proto
{
	class Program
	{

		static void Main(string[] args)
		{
			// WELCOME SCREEN
			Screen scrn = new Screen();
			scrn.Message = "In order to place your marker on a particular square press 1 - 9";
			scrn.DisplayExampleScreen();

			while (true)
			{
				// NEW GAME
				Board gameBoard = new Board();
				BoardRenderer br = new BoardRenderer();
				br.DrawEmptyBoard();

				// Initialize players & assets
				HumanPlayer player1 = new HumanPlayer(new GetHumanInput());
				ComputerPlayer player2 = new ComputerPlayer(new GetComputerInput(gameBoard.BoardState));
				EndGameEvaluator gameEvaluator = new EndGameEvaluator(gameBoard.BoardState);
				LegalMoveEvaluator LegalMoveHandler = new LegalMoveEvaluator(gameBoard.BoardState);
				ConsoleKey key;

				while (!gameEvaluator.Check())
				{
					var move = (gameBoard.Turn) ? player1.MakeMove() : player2.MakeMove();
					LegalMoveHandler.CheckPosition(move);

					while (!LegalMoveHandler.IsLegal)
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
				Console.WriteLine("Press R to start a new game and any other key to quit the application");
				key = Console.ReadKey(true).Key;
				if (key == ConsoleKey.R)
				{
					Console.Clear();
					scrn.Message = "In order to place your marker on a particular square press 1 - 9";
					scrn.DisplayExampleScreen();
					continue;
				}
				else
				{
					Environment.Exit(0);
				}
			}
		}

	}

}
