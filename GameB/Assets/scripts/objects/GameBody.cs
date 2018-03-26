using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBody : MonoBehaviour {

	public ArrayList ceils = new ArrayList ();

	public int coordx;

	public int coordy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeCoord(int x,int y) {
		WorldManager.Instance.DeleteGameBodyCoord (this);
		coordx = x;
		coordy = y;
		gameObject.transform.position = new Vector3 (coordx * 0.16f,coordy * 0.16f);
		WorldManager.Instance.ChangeGameBodyCoord (this);
	}

    private int storeCoordx;
    private int storeCoordy;
    private float storePositionx;
    private float storePositiony;
    //记录位置
    public void StorePosition()
    {
        storeCoordx = coordx;
        storeCoordy = coordy;
        storePositionx = gameObject.transform.position.x;
        storePositiony = gameObject.transform.position.y;
    }

    //还原位置
    public void RestorePosition()
    {
        storeCoordx = coordx;
        storeCoordy = coordy;
        gameObject.transform.position = new Vector3(storePositionx, storePositiony);
    }

	/**
	 * 添加细胞
	 **/
	public void AddCeil(Ceil ceil,int ceilx,int ceily) {
		ceil.gameObject.transform.parent = gameObject.transform;
		ceil._body = this;
		ceil.ChangeCeilPosition (ceilx, ceily);
		ceils.Add (ceil);
	}

	public bool Move(float x,float y) {
		return WorldManager.Instance.MoveGameBody (this,x,y);
	}
}