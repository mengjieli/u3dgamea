using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

	void Awake()
	{
		GameBody body =  BufferManager.Instance.CreateGameBody ();
		Ceil ceil = body.ceils [0] as Ceil;
		//ceil.ChangeCeilPosition (3, 5);
		ceil.gameObject.AddComponent<ControllerAbility> ();


		body = BufferManager.Instance.CreateGameBody ();
		body.ChangeCoord (10, 0);
		//ceil = body.ceils [0] as Ceil;
		//ceil.ChangeCeilPosition (3, 5);

		/*Debug.Log (Mathf.Floor(1.1f));
		Debug.Log (Mathf.Floor(1.5f));
		Debug.Log (Mathf.Ceil(-1.1f));
		Debug.Log (Mathf.Ceil(-1.5f));*/
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
