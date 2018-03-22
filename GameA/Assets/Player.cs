using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Animator avatar;
	int time = 0;

	// Use this for initialization
	void Start () {
		avatar.Play ("PlayerRun");

	}
	
	// Update is called once per frame
	void Update () {
		time++;
		if (time == 120) {
			avatar.Play ("PlayerStand");
			gameObject.transform.localScale = new Vector3 (-1f, 1, 1);
		}
		if (time == 240) {
			avatar.Play ("PlayerRun");
			gameObject.transform.localScale = new Vector3 (1f, 1, 1);
		} 
	}
}
