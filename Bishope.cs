using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishope : Chessman 
{
	public override bool [,] PossibleMove ()
	{
		bool[,] r = new bool[9, 9];
		Chessman c;
		int i, j;
		//top left
		i = CurrentX;
		j = CurrentY;
		while (true) 
		{
			i--;
			j++;
			if (i < 0 || j >= 8)
				break;
			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else 
			{
                if (isWhite != c.isWhite)
                {
                    r[i, j] = true;
                }
				break;
			}
		}
		//top right
		i = CurrentX;
		j = CurrentY;
		while (true) 
		{
			i++;
			j++;
			if (i >= 8 || j >= 8)
				break;
			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else 
			{
				if (isWhite != c.isWhite)
					r [i, j] = true;
				break;
			}
		}
		//down left
		i = CurrentX;
		j = CurrentY;
		while (true) 
		{
			i--;
			j--;
			if (i < 0 || j < 0)
				break;
			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else 
			{
				if (isWhite != c.isWhite)
					r [i, j] = true;
				break;
			}
		}
		//down right
		i = CurrentX;
		j = CurrentY;
		while (true) 
		{
			i++;
			j--;
			if (i >= 8 || j < 0)
				break;
			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else 
			{
				if (isWhite != c.isWhite)
					r [i, j] = true;
				break;
			}
		}
		return r;
	}
}
