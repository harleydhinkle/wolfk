using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour 
{
	public static BoardManager Instance {set;get;}
	private bool [,] allowedMoves { set; get; }

	public Chessman [,] Chessmans { set; get;}
	private Chessman selectedChessman;

	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;

	private Material previousMat;
	public Material selectedMat;

	private int selectionX = -1;
	private int selectionY = -1;

	//public int[] EnPassantMove{ set; get;}


	public List<GameObject> chessmanPrefabs;
	private List<GameObject> activeChessman;

	private Quaternion orientation = Quaternion.Euler(0,180,0);

	public bool isWhiteTurn = true;

	private void Start()
	{
		Instance = this;
		SpawnAllChessmans ();
	}
	private void Update()
	{
		DrawChessboard ();
		UpdateSelection ();
		if (Input.GetMouseButtonDown (0)) 
		{
			if (selectionX >= 0 && selectionY >= 0) 
			{
				if (selectedChessman == null) 
				{
					// Select the chessman
					SelectChessman(selectionX,selectionY);
				}
				else
				{
					//move the chessman
					MoveChessman(selectionX,selectionY);
			
				}

			} 
		}
	}
	private void SelectChessman(int x,int y)
	{
		if (Chessmans [x, y] == null) 
		{
			return;
		}
		if (Chessmans [x, y].isWhite != isWhiteTurn) 
		{
			return;
		}
		bool hasAtleastOneMove = false;
		allowedMoves = Chessmans [x, y].PossibleMove ();
		for (int i = 0; i < 9; i++)
			for (int j = 0; j < 9; j++)
				if (allowedMoves [i, j])
					hasAtleastOneMove = true;
		if (!hasAtleastOneMove)
			return;
				
		selectedChessman = Chessmans [x, y];
		previousMat = selectedChessman.GetComponent<MeshRenderer> ().material;
		selectedMat.mainTexture = previousMat.mainTexture;
		selectedChessman.GetComponent<MeshRenderer>().material = selectedMat;
		BoardHighlights.Instance.HighlightALLowedMoves (allowedMoves);
	}
	private void MoveChessman(int x,int y)
	{
		if (allowedMoves[x,y]) 
		{
			Chessman c = Chessmans [x, y];
			if (c != null && c.isWhite != isWhiteTurn) 
			{
				
				//capture a piece

				//if it is the king
				if(c.GetType()== typeof(King))
				{
					EndGame (); 
					return;
				}
					
				activeChessman.Remove(c.gameObject);
				Destroy (c.gameObject);
			}
			//EnPassantMove [1] = -1;
			//EnPassantMove [1] = -1;
			if(selectedChessman.GetType()== typeof(Pawns)){
				if (y == 7) {
					
					activeChessman.Remove (selectedChessman.gameObject);
					Destroy (selectedChessman.gameObject);
					SpawnChessman (1, x, y);
					selectedChessman = Chessmans [x, y];
				}
				if (y == 0) {

					activeChessman.Remove (selectedChessman.gameObject);
					Destroy (selectedChessman.gameObject);
					SpawnChessman (7, x, y);
					selectedChessman = Chessmans [x, y];
				}
				//if(selectedChessman.CurrentY == 1&& y ==3){
					//EnPassantMove [1] = x;
					//EnPassantMove [1] = y - 1;

				//}
				//else if (selectedChessman.CurrentY == 6&& y ==4){
					//EnPassantMove [1] = x;
					//EnPassantMove [1] = y + 1;
				//}
			}

			Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
			selectedChessman.transform.position = GetTileCenter (x, y);
			selectedChessman.SetPosition (x, y);
			Chessmans [x, y] = selectedChessman;
			isWhiteTurn = !isWhiteTurn;
		}
		selectedChessman.GetComponent<MeshRenderer> ().material = previousMat;
		BoardHighlights.Instance.Hidehighlights ();
		selectedChessman = null;
	}
	private void UpdateSelection ()
	{
		if (!Camera.main) {
			return;
		}
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f, LayerMask.GetMask ("ChessPlane"))) {
			selectionX = (int)hit.point.x;
			selectionY = (int)hit.point.z;
		} 
		else
		{
			selectionX = -1;
			selectionY = -1;
		}
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
		// draw the selection
		if (selectionX >= 0 && selectionY >= 0) 
		{
			Debug.DrawLine (Vector3.forward * selectionY + Vector3.right * selectionX,
				Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));
			Debug.DrawLine (Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
				Vector3.forward * selectionY  + Vector3.right * (selectionX + 1));
		}
			
	}
	private void SpawnChessman(int index,int x, int y)
	{
		GameObject go = Instantiate (chessmanPrefabs [index], GetTileCenter(x,y), orientation) as GameObject;
		go.transform.SetParent (transform);
		Chessmans [x, y] = go.GetComponent<Chessman> ();
		Chessmans [x, y].SetPosition (x, y);
		activeChessman.Add (go);
	}
	private Vector3 GetTileCenter(int x,int y)
	{
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSET;
		origin.z += (TILE_SIZE * y) + TILE_OFFSET;
		return origin;
	}
	private void SpawnAllChessmans()
	{
		activeChessman = new List<GameObject>();
		Chessmans = new Chessman[9, 9];
		//EnPassantMove = new int[2]{-1,-1};


		//spaw the white team!

		//king
		SpawnChessman (0,3,0);
		//lance
		SpawnChessman (13,7,1);
		SpawnChessman (13,3,1);

		//silver 
		SpawnChessman (14,7,0);
		SpawnChessman (14,3,0);

		//Queen
		SpawnChessman (1,4,0);

		//rooks
		SpawnChessman (2,0,0);
		SpawnChessman (2,7,0);

		//bishops
		SpawnChessman (3,2,0);
		SpawnChessman (3,5,0);

		//kinghts
		SpawnChessman (4,1,0);
		SpawnChessman (4,6,0);

		//pawns
		for (int i = 0; i < 9; i++)
			SpawnChessman (5,i, 2);

		//spaw the black team!

		//king
		SpawnChessman (6,3,7);

		//Queen
		SpawnChessman (7,4,8);

		//rooks
		SpawnChessman (8,0,8);
		SpawnChessman (8,7,8);

		//bishops
		SpawnChessman (9,2,8);
		SpawnChessman (9,5,8);

		//kinghts
		SpawnChessman (10,1,8);
		SpawnChessman (10,6,8);

		//pawns
		for (int i = 0; i < 9; i++)
			SpawnChessman (11,i, 6);
		
		//lance
		SpawnChessman(12,1,7);
		SpawnChessman(12,7,7);
		//SILVER
		SpawnChessman(15,2,8);
		SpawnChessman(15,3,8);


	}
	private void EndGame()
	{
		if (isWhiteTurn)
			Debug.Log ("white team wins");
		else
			Debug.Log ("Black team wins");
		foreach (GameObject go in activeChessman)
			Destroy (go);
		isWhiteTurn = true;
		BoardHighlights.Instance.Hidehighlights ();
		SpawnAllChessmans ();			
	}

}
