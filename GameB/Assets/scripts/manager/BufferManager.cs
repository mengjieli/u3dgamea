using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferManager : MonoBehaviour {

	public static BufferManager Instance;

	public Object ceilPerfab;

	public Object ceilItemNodePerfab;

	void Awake()
	{
		Instance = this;
	}

	public GameBody CreateGameBody(int coordx,int coordy)
	{
		GameObject obj = new GameObject ();
		GameBody body = obj.AddComponent<GameBody> ();
        body.ChangeCoord(coordx, coordy);
        body.AddCeil (CreateCeil(),0,0);
		WorldManager.Instance.AddGameBodyToWorld(body);
		return body;
	}

	public Ceil CreateCeil()
	{
		GameObject obj = new GameObject ();
		obj.AddComponent<SpriteRenderer> ();
		return obj.AddComponent<Ceil> ();
	}
}
