﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ImpossibleComputerPlayer : IPlayer
	{
		private char mark;
		private readonly IGetInput<char[,]> _iGetInput;
		private readonly IPlayer _player;
		private GFG_MiniMax miniMax;
		private char[,] board;
		public char Mark => mark;


		public ImpossibleComputerPlayer(IGetInput<char[,]> iGetInput, IPlayer player)
		{
			mark = Marks.Nought;
			_iGetInput = iGetInput;
			_player = player;
			miniMax = new GFG_MiniMax();
			miniMax = new GFG_MiniMax();
			board = _iGetInput.GetGameBoardSquare();
		}


		public Position MakeMove()
		{
			return miniMax.FindBestMove(board, false, _player);
		}

	}
}
