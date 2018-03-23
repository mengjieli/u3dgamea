using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 发送器，可以发被发射对象
 **/
public class Shooter : MonoBehaviour {

    //要发射的对象
    public Object shootPrefab;

    public Transform shootTrans;

    //爆炸特效
    public Object boomAnimation;

    //发射时间间隔，帧
    public int timeGap = 10;

    public float speed = 0.1f;

    //发射个数
    public int count = 1;

    //每一个发射的间隔
    public int itemTimeGap = 0;
    private int itemCount;
    private int itemTime;
    private bool firstItem = true;

    //发射初始角度
    public float startRotation = 0f;

    //发射间隔角度
    public float gapRotation = 15f;

    //发射抖动角度
    public float randomRotation = 5f;

    //距离上一次发射多少帧
    private int shootGap = 1000;

    private bool _isShoot = false;
    //是否正在发射
    public bool IsShoot
    {
        get { return _isShoot; }
        set { _isShoot = value; if (value == false) shootGap = 1000; }
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(IsShoot)
        {
            if(firstItem && shootGap >= timeGap)
            {
                itemCount = 0;
                itemTime = itemTimeGap;
                firstItem = false;
            }
            for(; itemCount < count && itemTime >= itemTimeGap; itemCount++)
            {
                GameObject item = Instantiate(shootPrefab, shootTrans.position, transform.localRotation) as GameObject;
                ShootItem info = item.GetComponent<ShootItem>();
                info.boomAnimation = boomAnimation;
                float scale = (gameObject.transform.lossyScale.x > 0 ? 1 : -1);
                float rot = startRotation + gapRotation * itemCount + randomRotation * Random.Range(-0.5f, 0.5f);
                item.transform.Rotate(new Vector3(0f, 0f, rot));
                info.vx = speed * scale * Mathf.Cos(rot * Mathf.PI / 180);
                info.vy = speed * scale * Mathf.Sin(rot * Mathf.PI / 180);
                item.transform.localScale = new Vector3(scale * item.transform.localScale.x, scale * item.transform.localScale.y, 1);
                shootGap = 0;
                itemTime = 0;
            }
            if(itemCount == count)
            {
                firstItem = true;
            }
        }
        shootGap++;
        itemTime++;
    }
}
