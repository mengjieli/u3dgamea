using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicAbility : Ability {

	public float vx = 0;
	public float vy = 0;
    private float morex = 0;
    private float morey = 0;
    public float g = 0.01f;

    private Rigidbody2D r2d;

	public override void init() {
        r2d = body.GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //vy -= g;
		if (vx != 0f || vy != 0f) {
            //r2d.velocity = new Vector2(vx, vy);
            //body.gameObject.transform.position = new Vector3(
            //body.gameObject.transform.position.x + vx,
            //body.gameObject.transform.position.y + vy
            // );
            //return;
            float rx = vx;
            float ry = vy;
            float len = Mathf.Sqrt(vx * vx + vy * vy);
            float allLen = len;
            float mx = 0;
            float my = 0;
            float dis = 0.08f;
            while (len > 0f)
            {
                if(len > dis)
                {
                    mx = vx * dis / allLen;
                    my = vy * dis / allLen;
                    len -= dis;
                    if(len < 0)
                    {
                        len = 0;
                    }
                }
                else
                {
                    mx = vx * len / allLen;
                    my = vy * len / allLen;
                    len = 0;
                }
                if (body.Move(mx, my) == false)
                {
                    vx = 0f;
                    vy = 0f;
                }
                if (vx != rx || vy != ry)
                {
                    break;
                }
            }
		}
	}
}
