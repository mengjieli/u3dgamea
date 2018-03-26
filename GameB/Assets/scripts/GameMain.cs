using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMain : MonoBehaviour {

    public DateTime dateBegin;

	void Awake()
	{
        /*Dictionary<string, bool> dic = new Dictionary<string, bool>();
        ArrayList list = new ArrayList();
        int count = 0;
        DateTime dateBegin = DateTime.Now;
        for (int y = -100; y < 100; y++)
        {
            for(int x = -100; x < 100; x++)
            {
                if(UnityEngine.Random.Range(0f,1f) < 0.05f)
                {
                    GameBody body = BufferManager.Instance.CreateGameBody(x, y);
                    Ceil ceil = body.ceils[0] as Ceil;
                    ceil.gameObject.AddComponent<ControllerRandomAbility>();
                    count++;
                }
            }
        }
        Debug.Log("All:" + count);*/

		for (int i = -20; i < 20; i++) {
			BufferManager.Instance.CreateGameBody(i, -2);
		}
		for (int i = 1; i < 20; i++) {
			BufferManager.Instance.CreateGameBody(-20, -2 + i);
			BufferManager.Instance.CreateGameBody(20, -2 + i);
		}
        GameBody body =  BufferManager.Instance.CreateGameBody (0,0);
        Ceil ceil = body.ceils [0] as Ceil;
        ceil.gameObject.AddComponent<ControllerAbility> ();
    }

    // Use this for initialization
    int frame = 0;
    double allTime = 0;
	int fps = 0;
	void Start ()
    {
        dateBegin = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
        frame++;
        DateTime dateEnd = DateTime.Now;
        TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
        TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
        TimeSpan ts3 = ts1.Subtract(ts2).Duration();
        allTime += ts3.TotalMilliseconds;
        if(allTime > 1000)
        {
			fps = (int)(frame * 1000 / allTime);
			//Debug.Log(fps);
            frame = 0;
            allTime = 0;
        }
        dateBegin = dateEnd;
    }
}
