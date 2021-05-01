using Omu.ValueInjecter;
using System;
using System.Collections.Generic;


namespace Tic_Tac_Toe_proto
{
	class Test
	{
		private readonly 
		
		DualConverter converter = new DualConverter();

		// Need the current board state & position to be made
		// Create a updated board state w/the position
		// Then go through the board and for every empty board
		// grab the position of that square and add that to 
		// the childNode list 

		// We do not need a position here... get rid of the parameter b/c we are generating
		// a list of all boardStates from currentBoard -
		// Aren't I referencing the currentBoard every time I make a childNode aka
		// it should not be using only one board. 
		public List<char[,]> GetChildNodes(char[,] board, IPlayer player)
		{
			// If this works do I really need a parent node? lol 
			//Board parentNode = new Board(currentBoard);
			var childNodes = new List<char[,]>();
			int index = 0;

			// When a newBoard is passed in every single square is filled with marker
			// We need to be creating a new shallow copy of the board after every pass
			// Right now, we are keeping one copy that's why all of it gets filled lol
			//var childNode = new Board(currentBoard);
			//Board childNode = parentNode;
			//childNode.InjectFrom(parentNode);

			foreach (var square in board)
			{
				
				if (char.IsWhiteSpace(square))
				{
					var position = converter.ConvertSquareToPosition(index);
					//Board newBoard = new Board(changingBoard);
					board[position.Row, position.Column] = player.Mark;
					childNodes.Add(board);
					board[position.Row, position.Column] = ' ';
				}
				index++;
			}
			return childNodes;

		}
	}
}
