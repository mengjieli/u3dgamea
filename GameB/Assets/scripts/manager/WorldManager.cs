using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public static WorldManager Instance;

	void Awake()
	{
		Instance = this;
	}

	public Ceil[,] coords = new Ceil[100,100];

	public void AddCeilToWorld(int coordx,int coordy,Ceil item) {
		coords [coordy,coordx] = item;
	}

	public void AddGameBodyToWorld(GameBody body) {
		ArrayList ceils = body.ceils;
		foreach (Ceil ceil in ceils) {
			coords [ceil.coordy, ceil.coordx] = ceil;
		}
	}

	public void DeleteGameBodyCoord(GameBody body) {
		ArrayList ceils = body.ceils;
		foreach (Ceil ceil in ceils) {
			coords [ceil.coordy, ceil.coordx] = null;
		}
	}

	public void ChangeGameBodyCoord(GameBody body) {
		ArrayList ceils = body.ceils;
		foreach (Ceil ceil in ceils) {
			coords [ceil.coordy, ceil.coordx] = ceil;
		}
	}

	public bool MoveGameBody(GameBody body,float x,float y) {
		ArrayList ceils = body.ceils;
		float px = (body.gameObject.transform.position.x + x)/0.16f;
		float py = (body.gameObject.transform.position.y + y)/0.16f;
		int cx;
		int cy;
		if (px > 0)
			cx = (int)Mathf.Ceil (px);
		else
			cx = (int)Mathf.Floor (px);
		if (py > 0)
			cy = (int)Mathf.Ceil (py);
		else
			cy = (int)Mathf.Floor (py);
		foreach (Ceil ceil in ceils) {
			if (coords [cy + ceil.ceilx, cx + ceil.ceily] != null) {
				if (coords [cy + ceil.ceilx, cx + ceil.ceily].body != body) {
					return false;
				}
			}
		}
		x = body.gameObject.transform.position.x + x;
		y = body.gameObject.transform.position.y + y;
		if (cx != body.coordx || cy != body.coordy) {
			body.ChangeCoord (cx,cy);
		}
		body.gameObject.transform.position = new Vector3 (x,y);
		return true;
	}

	public bool HasAt(int coordx,int coordy) {
		return coords [coordy,coordx] == null ? false : true;
	}

	public Ceil GetAt(int coordx, int coordy) {
		return coords [coordy,coordx];
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
