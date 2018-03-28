using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour {

    public static LayerManager Instance;

    //背景层
    public GameObject backLayer;
    //前景层
    public GameObject frontLayer;
    //怪物层
    public GameObject monsterLayer;
    //角色层
    public GameObject playerLayer;
    //子弹层，特效层
    public GameObject bulletLayer;

    private void Awake()
    {
        Instance = this;

        Rect rect = frontLayer.GetComponent<GameLayer>().moveRange;
        monsterLayer.GetComponent<GameLayer>().moveRange = rect;
        playerLayer.GetComponent<GameLayer>().moveRange = rect;
        bulletLayer.GetComponent<GameLayer>().moveRange = rect;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
}
