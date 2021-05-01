using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{

	//Rename: HardComputerPlayer
	public class Player
	{
		private char mark;
		// TODO: Remove
		private bool turn;
		//private readonly IPosition _position;

		public Player(char mark)
		{
			this.mark = mark;
		}

		// TODO: Delete? 
		public bool Turn
		{
			get
			{
				return turn;
			}
			set
			{
				turn = value;
			}
		}
		
		public char Mark => mark;

		public Position MakeMove()
		{
			throw new NotImplementedException();
		}
	}
}
