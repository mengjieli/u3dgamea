using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicAbility : Ability {

	public float vx = 0;
	public float vy = 0;

	public override void init() {
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (vx != 0f || vy != 0f) {
			if (body.Move (vx, vy) == false) {
				vx = 0;
				vy = 0;
			}
		}
	}
}
