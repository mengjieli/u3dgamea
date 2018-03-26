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

	//return 0.没撞到 1.撞到左边 2.撞到上面 3.撞到右边  4.撞到下面
	public int MoveGameBody(GameBody body,float x,float y) {
		ArrayList ceils = body.ceils;
		float px = (body.gameObject.transform.position.x + x)/0.16f;
		float py = (body.gameObject.transform.position.y + y)/0.16f;
		int cx = 0;// = Mathf.RoundToInt(px);
		int cy = 0;// = Mathf.RoundToInt(py);
		int tx = 0;
		if (x > 0) {
			cx = (int)Mathf.Ceil (px);
			tx = (int)Mathf.Floor (px);
		} else {
			cx = (int)Mathf.Floor (px);
			tx = (int)Mathf.Ceil (px);
		}
		if (y > 0) {
			cx = (int)Mathf.Ceil (py);
		} else {
			cy = (int)Mathf.Floor (py);
		}
		int result = 0;
		int ground = -1;
		foreach (Ceil ceil in ceils) {
            if(coords.ContainsKey((cx + ceil.ceilx) + "," + (cy + ceil.ceily))) {
				if (coords[(cx + ceil.ceilx) + "," + (cy + ceil.ceily)].body != body) {
					if (cy - ceil.coordy == 0) {
						if (cx - ceil.coordx > 0) {
							result = 3;
							body.gameObject.transform.position = new Vector3 (body.coordx * 0.16f,body.gameObject.transform.position.y);
						} else {
							result = 1;
							body.gameObject.transform.position = new Vector3 (body.coordx * 0.16f,body.gameObject.transform.position.y);
						}
					} else {
						if (cy - ceil.coordy > 0) {
							result = 2;
							body.gameObject.transform.position = new Vector3 (body.gameObject.transform.position.x,body.coordy * 0.16f);
						} else {
							result = 4;
							body.gameObject.transform.position = new Vector3 (body.gameObject.transform.position.x,body.coordy * 0.16f);
						}
					}
					break;
				}
			}
			if (y == 0 && ground == -1) {
				if (coords.ContainsKey ((tx + ceil.ceilx) + "," + (-1 + ceil.coordy))) {
					if (coords [(tx + ceil.ceilx) + "," + (-1 + ceil.coordy)].body != body) {
						ground = 0;
					}
				}
			}
		}
		if (result == 0) {
			x = body.gameObject.transform.position.x + x;
			y = body.gameObject.transform.position.y + y;
			if (cx != body.coordx || cy != body.coordy) {
				body.ChangeCoord (cx,cy);
			}
			body.gameObject.transform.position = new Vector3 (x,y);
			return ground;
		}
		return result;
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
