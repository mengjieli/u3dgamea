using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRandomAbility : Ability {

    PhysicAbility pa;

    public override void init()
    {
        pa = gameObject.AddComponent<PhysicAbility>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pa.vx = Random.Range(-0.1f, 0.1f);
        pa.vy = Random.Range(-0.1f, 0.1f);
    }
}
