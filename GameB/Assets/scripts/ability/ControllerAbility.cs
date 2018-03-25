using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAbility : Ability {


	public override void init()
	{
		gameObject.AddComponent<PhysicAbility> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			if (gameObject.GetComponent<PhysicAbility> () == null) {
			//	gameObject.AddComponent<SimplePhysic> ();
			}
			PhysicAbility sp = gameObject.GetComponent<PhysicAbility> ();
			sp.vx = 0.01f;
		}
	}
}
