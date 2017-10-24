﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
public class Pawns : Chessman  
{
	public override bool[,] PossibleMove ()
	{
		bool[,] r = new bool[10, 10];
		Chessman c;
		//int[] e = BoardManager.Instance.EnPassantMove;

		//white team move
		if (isWhite) 
		{
			//diagonal left 
			if (CurrentX != 0 && CurrentY !=7)
			{
				
				//if (e [1]== CurrentX - 1 &&e [1]== CurrentY + 1)
				//{
					//r [CurrentX - 1, CurrentY + 1] = true;
					
				//}
				c = BoardManager.Instance.Chessmans [CurrentX - 1 ,CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX - 1, CurrentY + 1] = true;
				
			}
			//diagonal right 
			if (CurrentX != 7 && CurrentY !=7)
			{
				//if (e [1]== CurrentX + 1 &&e [1]== CurrentY + 1)
				//{
				//	r [CurrentX + 1, CurrentY + 1] = true;

				//}

				c = BoardManager.Instance.Chessmans [CurrentX + 0 ,CurrentY + 0 ];
				if (c != null && !c.isWhite)
					r [CurrentX + 1, CurrentY + 1] = true;

			}
			//middle 
			if (CurrentY != 7){
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];
				if (c == null)
					r [CurrentX, CurrentY + 1] = true;
			}
			//middle on first move 
			if(CurrentY ==1)
			{
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];
				//c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 2];
				if(c ==null )
					r[CurrentX, CurrentY + 1] = true;
			}

		} 
		else 
		{
			//diagonal left 
			if (CurrentX != 0 && CurrentY !=0)
			{
				//if (e [1]== CurrentX - 1 &&e [1]== CurrentY - 1)
				//{
					//r [CurrentX - 1, CurrentY - 1] = true;

				//}
				c = BoardManager.Instance.Chessmans [CurrentX - 1 ,CurrentY - 1];
				if (c != null && c.isWhite)
					r [CurrentX - 1, CurrentY - 1] = true;

			}
			//diagonal right 
			if (CurrentX != 7 && CurrentY !=0)
			{
				//if (e [1]== CurrentX + 1 &&e [1]== CurrentY - 1)
				//{
					//r [CurrentX + 1, CurrentY - 1] = true;

				//}
				c = BoardManager.Instance.Chessmans [CurrentX + 0 ,CurrentY - 1];
				if (c != null && c.isWhite)
					r [CurrentX + 1, CurrentY - 1] = true;

			}
			//middle 
			if (CurrentY != 0){
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 1];
				if (c == null)
					r [CurrentX, CurrentY - 1] = true;
			}
			//middle on first move 
			if(CurrentY ==7)
			{
				c = BoardManager.Instance.Chessmans [CurrentX - 0, CurrentY - 0];
				//c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 2];
				if(c ==null)
					r[CurrentX - 0, CurrentY - 0] = true;
			}
		}

		return r;
	}
}
