using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake {

    //震动时间
    public float time;

    //震动的 x 范围
    public float xRange;

    //震动的 y 范围
    public float yRange;

    //tag
    public string tag;

    //是否唯一，如果唯一，则会覆盖之前相同 tag 的震动
    public bool only;

    //是否结束
    public bool completeFlag = false;

    //当前震动偏移量 x
    public float x;

    //当前震动偏移量 x
    public float y;

    public CameraShake(float time,float xRange,float yRange,string tag,bool only)
    {
        this.time = time;
        this.xRange = xRange;
        this.yRange = yRange;
        this.tag = tag;
        this.only = only;
    }
	
	// Update is called once per frame
	public void Update () {

        time -= GameVO.Instance.timeGap;

        if (time <= 0)
        {
            completeFlag = true;
        }

        //计算震动偏移量
        x = Random.Range(-xRange * 0.5f, xRange * 0.5f);
        y = Random.Range(-yRange * 0.5f, yRange * 0.5f);
    }
}
