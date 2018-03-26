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
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			PhysicAbility sp = gameObject.GetComponent<PhysicAbility> ();
			sp.vx = 0.03f;
		}
        if (Input.GetKeyDown(KeyCode.A))
        {
            PhysicAbility sp = gameObject.GetComponent<PhysicAbility>();
            sp.vx = -0.03f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PhysicAbility sp = gameObject.GetComponent<PhysicAbility>();
            sp.vy = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PhysicAbility sp = gameObject.GetComponent<PhysicAbility>();
            sp.vy = -0.01f;
        }
    }
}
