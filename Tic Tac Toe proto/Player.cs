using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class Player:IPlayer
	{
		private string mark;
		private bool turn;
		//private readonly IPosition _position;

		public Player(String mark)
		{
			this.mark = mark;
		}

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

		public String Mark
		{
			get
			{
				return mark;
			}
		}

		public Position MakeMove()
		{
			throw new NotImplementedException();
		}
	}
}
