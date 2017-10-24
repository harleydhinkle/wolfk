using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRAW : MonoBehaviour {
	public static BoardManager Instance {set;get;}
	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DrawChessboard ();
	}
	private void DrawChessboard ()
	{
		Vector3 widthLine = Vector3.right * 9;
		Vector3 heigthLine = Vector3.forward * 9;
		for (int i = 0; i <= 9; i++) 
		{
			Vector3 start = Vector3.forward * i;
			Debug.DrawLine (start, start + widthLine);
			for (int j =0; j <= 9; j++)
			{
				start = Vector3.right * j;
				Debug.DrawLine (start, start + heigthLine);
			}
		}
}
}
