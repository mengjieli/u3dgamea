using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public static WorldManager Instance;

	void Awake()
	{
		Instance = this;
	}

    public Dictionary<string, Ceil> coords = new Dictionary<string, Ceil>();

	public void AddCeilToWorld(int coordx,int coordy,Ceil item) {
        coords.Add(coordx + "," + coordy, item);
	}

	public void AddGameBodyToWorld(GameBody body) {
		ArrayList ceils = body.ceils;
		foreach (Ceil ceil in ceils) {
            coords.Add(ceil.coordx + "," + ceil.coordy, ceil);
		}
	}

	public void DeleteGameBodyCoord(GameBody body) {
		ArrayList ceils = body.ceils;
		foreach (Ceil ceil in ceils)
        {
            coords.Remove(ceil.coordx + "," + ceil.coordy);
		}
	}

	public void ChangeGameBodyCoord(GameBody body) {
		ArrayList ceils = body.ceils;
		foreach (Ceil ceil in ceils)
        {
            coords.Add(ceil.coordx + "," + ceil.coordy, ceil);
		}
	}

	public bool MoveGameBody(GameBody body,float x,float y) {
		ArrayList ceils = body.ceils;
		float px = (body.gameObject.transform.position.x + x)/0.16f;
		float py = (body.gameObject.transform.position.y + y)/0.16f;
		int cx = Mathf.RoundToInt(px);
        int cy = Mathf.RoundToInt(py);
		foreach (Ceil ceil in ceils) {
            if(coords.ContainsKey((cx + ceil.ceilx) + "," + (cy + ceil.ceily))) { 
				if (coords[(cx + ceil.ceilx) + "," + (cy + ceil.ceily)].body != body) {
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
		return coords.ContainsKey(coordx + "," + coordy);
	}

	public Ceil GetAt(int coordx, int coordy) {
		return coords [coordx + "," + coordy];
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
