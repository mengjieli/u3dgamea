﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour {

    public float vx = 0;
    public float vy = 0;
    private Transform trans;
    //爆炸特效
    public Object boomAnimation;

    // Use this for initialization
    void Start () {
        trans = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        trans.position = new Vector3(trans.position.x + vx, trans.position.y + vy);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);

        if(collision.gameObject.tag == "Enemy")
        {
            DestructiveItem ditem = collision.gameObject.GetComponent<DestructiveItem>();
            ditem.goDie();
        }

        Instantiate(boomAnimation, gameObject.transform.position, transform.localRotation);
    }

}
