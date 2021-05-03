using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class GetEasyComputerInput:IGetInput<int>
	{
		private List<int> options;

		public GetEasyComputerInput()
		{
			options = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		}
		public int GetGameBoardSquare()
		{
			return options.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
		}
	}
}
