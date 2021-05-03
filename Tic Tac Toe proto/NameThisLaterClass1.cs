using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_proto
{
	//public class LineBoard
	//{
	//	private char[] boardState = new char[9];
	//	private char mark;
	//	private char[,] board;
	//	private GFG_MiniMax gfg;

	//	public LineBoard(char[,] board)
	//	{
	//		this.board = board;
	//		InitalizeLineBoard(board);
	//		gfg = new GFG_MiniMax();
	//	}

	//	public void InitalizeLineBoard(char[,] board)
	//	{
	//		// Refactor to its own function: Line converter
	//		//boardState = board.Cast<char>.ToArray();
	//		int index = 0;
	//		foreach (var square in board)
	//		{
	//			boardState[index] = square;
	//			index++;
	//		}

	//	}

	//	// Rename: CheckEmptySquares
	//	public bool IsMovesLeft()
	//	{
	//		foreach (var square in board)
	//		{
	//			if (char.IsWhiteSpace(square))
	//			{
	//				return true;
	//			}
	//		}
	//		return false;
	//	}

	//	private bool IsThreeInARow(int i, int j, int k, char mark)
	//	{

	//		if (char.IsWhiteSpace(mark))
	//		{
	//			return false;
	//		}
	//		else if (boardState[i] == mark && boardState[j] == mark && boardState[k] == mark && !char.IsWhiteSpace(boardState[i]))
	//		{
	//			this.mark = mark;
	//			return true;
	//		}
	//		return false;
	//	}

	//	private bool CheckAnyLine(int start, int increment)
	//	{
	//		return IsThreeInARow(start, start + increment, start + increment + increment, boardState[start]);
	//	}

	//	private bool CheckHorizontal(int start)
	//	{
	//		return CheckAnyLine(start, 1);
	//	}

	//	private bool CheckVertical(int start)
	//	{
	//		return CheckAnyLine(start, 3);
	//	}

	//	public bool CheckWin()
	//	{
	//		return CheckHorizontal(0) || CheckHorizontal(3) || CheckHorizontal(6) ||
	//			  CheckVertical(0) || CheckVertical(1) || CheckVertical(2) ||
	//			  CheckAnyLine(0, 4) || CheckAnyLine(2, 2);
	//	}


	//	// Rename: EvaluateGameBoard
	//	public double Evaluate()
	//	{
	//		double boardValue = 100;
	//		if (CheckWin())
	//		{
	//			boardValue = (this.mark == 'X') ? 10 : -10; //Math.Pow(10,9) : Math.Pow(-10, 9);
	//		}
	//		else if (!IsMovesLeft())
	//		{
	//			boardValue = 0;
	//		}
	//		return boardValue;
	//	}
	//}
}
