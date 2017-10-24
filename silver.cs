using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silver : Chessman {
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[10, 10];
        Chessman c;
        int i, j;
        //top left
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i <= 0 || j >= 9)
                break;
            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
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
        //i = CurrentX;
        //j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i <= 0 || j >= 1)
                break;
            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
                r[i, j] = true;
            else
            {
                if (isWhite != c.isWhite)
                {
                    r[i, j] = true;
                }
                break;
            }
        }
        return r;

    }
		//middle left
		//if (CurrentX !=0)
		//{
			//c = BoardManager.Instance.Chessmans [CurrentX -1, CurrentY];
			//if (c == null)
			///	r [CurrentX - 1, CurrentY] = true;
			//else if (isWhite != c.isWhite)
		///		r [CurrentY - 1, CurrentY] = true;
		//}
		//middle right
		//if (CurrentX !=7)
		//{
			//c = BoardManager.Instance.Chessmans [CurrentX + 1, CurrentY];
			///if (c == null)
				//r [CurrentX + 1, CurrentY] = true;
			//else if (isWhite != c.isWhite)
				//r [CurrentY + 1, CurrentY] = true ;
		//}
		
        }

