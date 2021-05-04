using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	public class ErrorHandling
	{
		/**
		 * Checks to see the key pressed is a numeric key, e.g. 1-9.
		 * @param {char} keyPressed - the key input from console. 
		 */
		public bool IsValidNumber(char keyPressed)
		{
			return ((int)char.GetNumericValue(keyPressed) > 0) ? true: false ;
		}
	}
}
