using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMain : MonoBehaviour {

    public DateTime dateBegin;

	void Awake()
	{
        Dictionary<string, bool> dic = new Dictionary<string, bool>();
        ArrayList list = new ArrayList();
        int count = 0;
        DateTime dateBegin = DateTime.Now;
        for (int y = -100; y < 100; y++)
        {
            for(int x = -100; x < 100; x++)
            {
                if(UnityEngine.Random.Range(0f,1f) < 0.1f)
                {
                    GameBody body = BufferManager.Instance.CreateGameBody(x, y);
                    /*body.gameObject.AddComponent<Rigidbody2D>();
                    BoxCollider2D  box = body.gameObject.AddComponent<BoxCollider2D>();
                    box.size = new Vector2(0.16f, 0.16f);//*/
                    Ceil ceil = body.ceils[0] as Ceil;
                    ceil.gameObject.AddComponent<ControllerRandomAbility>();
                    count++;
                }
            }
        }
        Debug.Log("All:" + count);

        
        

        /*BufferManager.Instance.CreateGameBody(-10, 0);
        BufferManager.Instance.CreateGameBody(0, 5);
        BufferManager.Instance.CreateGameBody(0, -5);
        GameBody body =  BufferManager.Instance.CreateGameBody (0,0);

        Ceil ceil = body.ceils [0] as Ceil;

        //ceil.ChangeCeilPosition (3, 5);
        ceil.gameObject.AddComponent<ControllerAbility> ();
        //ceil = BufferManager.Instance.CreateCeil();
        //body.AddCeil(ceil, 2, 1);

        body = BufferManager.Instance.CreateGameBody (1,0);
		body.ChangeCoord (10, 0);*/

        //ceil = body.ceils [0] as Ceil;
        //ceil.ChangeCeilPosition (3, 5);

        /*Debug.Log (Mathf.Floor(1.1f));
		Debug.Log (Mathf.Floor(1.5f));
		Debug.Log (Mathf.Ceil(-1.1f));
		Debug.Log (Mathf.Ceil(-1.5f));*/
    }

    // Use this for initialization
    int frame = 0;
    double allTime = 0;
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
            Debug.Log(frame * 1000 / allTime);
            frame = 0;
            allTime = 0;
        }
        dateBegin = dateEnd;
    }
}
