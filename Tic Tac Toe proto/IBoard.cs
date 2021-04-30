using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public interface IBoard
	{
		public String[,] BoardState { get; set; }
		void DrawBoard();
		String[,] UpdateBoardState();
		bool CheckPosition(String[,] board);
	}
}
