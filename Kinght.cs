using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinght : Chessman 
{
	public override bool [,] PossibleMove ()
	{
		bool[,] r = new bool[10, 10];
		//upleft
		KnightMove(CurrentX - 1, CurrentY + 2,ref r);
		//upright
		KnightMove(CurrentX + 1, CurrentY + 2,ref r);
		//rightup
		KnightMove(CurrentX + 2, CurrentY + 1,ref r);
		//RightDown
		KnightMove(CurrentX + 2, CurrentY - 1,ref r);
		//downleft
		KnightMove(CurrentX - 1, CurrentY - 2,ref r);
		//downright
		KnightMove(CurrentX + 1, CurrentY - 2,ref r);
		//Leftup
		KnightMove(CurrentX - 2, CurrentY + 1,ref r);
		//leftDown
		KnightMove(CurrentX - 2, CurrentY - 1,ref r);
		return r;
	}
	public void KnightMove (int x,int y, ref bool[,] r)
	{
		Chessman c;
		if (x >= 0 && x < 8 && y >= 0 && y < 8) 
		{
			c = BoardManager.Instance.Chessmans [x, y];
			if (c == null)
				r [x, y] = true;
			else if (isWhite != c.isWhite)
				r [x, y] = true;
			
		}
	}
}
