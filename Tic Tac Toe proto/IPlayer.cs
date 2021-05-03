using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public interface IPlayer
	{
		public char Mark { get; }

		public Position MakeMove();


	}
}
