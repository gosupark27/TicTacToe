using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ErrorHandling
	{
		public bool IsValidNumber(Char keyPressed)
		{
			return ((int)char.GetNumericValue(keyPressed) > 0) ? true: false ;
		}
	}
}
