using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {

	protected Ceil ceil;
	protected GameBody body;


	void Awake()
	{
		ceil = gameObject.GetComponent<Ceil> ();
		body = ceil.body;
		this.init ();
	}

	public abstract void init();
}
