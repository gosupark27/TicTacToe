using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public interface IGetInput<T>
	{
		public T GetGameBoardSquare();
	}
}
