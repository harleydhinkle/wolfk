using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lance : Chessman
{
	public override bool [,] PossibleMove ()
	{
		bool[,] r = new bool[10, 10];
		Chessman c;
		int i;
		i = CurrentY;
		while (true) {
			i++;
			if (i >= 8)
				break;
			c = BoardManager.Instance.Chessmans [CurrentX, i];
			if (c == null)
				r [CurrentX, i] = true;
			else {
				if (c.isWhite != isWhite)
					r [CurrentX, i] = true;


				break;
			}

		}
		return r;
	
	}
}