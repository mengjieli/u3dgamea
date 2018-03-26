using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicAbility : Ability {

	public float vx = 0;
	public float vy = 0;
    public float g = 0.007f;
	public bool atGround = false;

	public override void init() {
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!atGround) {
			vy -= g;
		}
		if (vx != 0f || vy != 0f) {
            float rx = vx;
            float ry = vy;
            float len = Mathf.Sqrt(vx * vx + vy * vy);
            float allLen = len;
            float mx = 0;
            float my = 0;
            float dis = 0.08f;
			int result;
            while (len > 0f)
			{
				if (vy != 0) {
					atGround = false;
				}
                if(len > dis)
                {
                    mx = vx * dis / allLen;
                    my = vy * dis / allLen;
                    len -= dis;
                }
                else
                {
                    mx = vx * len / allLen;
                    my = vy * len / allLen;
                    len = 0;
                }
				result = body.Move (mx, my);
				if (result == 1) { //碰到左边
					vx = 0;
				} else if (result == 2) { //碰到上面
					vy = 0;
				} else if (result == 3) { //碰到右边
					vx = 0;
				} else if (result == 4) { //碰到下面
					vy = 0;
					if (!atGround) {
						vx = 0;
						atGround = true;
					}
				} else if (result == -1) {
					atGround = false;
				}
                if (vx != rx || vy != ry)
                {
                    break;
                }
            }
		}
	}
}
