using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager Instance;

    //镜头
    public Camera mainCamera;
    //镜头的 transform 属性
    public Transform cameraTransform;
    //可移动范围，直接获取前景层的移动范围
    private Rect moveRange;
    //镜头范围，根据屏幕可视范围和移动范围计算得到
    private Rect cameraRange;

    //测试用
    public bool test = true;
    private int moveRight = 0;
    private int moveUp = 1;

    private void Awake()
    {
        Instance = this;
        Rect frontMoveRange = LayerManager.Instance.frontLayer.GetComponent<GameLayer>().moveRange;
        moveRange = new Rect(frontMoveRange.x, frontMoveRange.y, frontMoveRange.width, frontMoveRange.height);
        //计算镜头实际可移动范围
        Vector3 v = new Vector3();
        v = mainCamera.ViewportToWorldPoint(v);
        Debug.Log(v.x + "," + v.y);
        cameraRange.x = moveRange.x + Mathf.Abs(v.x);
        cameraRange.width = moveRange.width - 2 * Mathf.Abs(v.x);
        cameraRange.y = moveRange.y + Mathf.Abs(v.y);
        cameraRange.height = moveRange.height - 2 * Mathf.Abs(v.y);
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {

        //测试代码
        if(test)
        {
            //测试移动代码
            if (moveRight == 1)
            {
                cameraTransform.Translate(new Vector3(0.01f, 0f, 0f));
            }
            else if (moveRight == -1)
            {
                cameraTransform.Translate(new Vector3(-0.01f, 0f, 0f));
            }
            if (cameraTransform.position.x > cameraRange.x + cameraRange.width)
            {
                moveRight = -1;
            }
            if (cameraTransform.position.x < cameraRange.x)
            {
                moveRight = 1;
            }
            if(moveUp == 1)
            {
                cameraTransform.Translate(new Vector3(0f, 0.01f, 0f));
            }
            else if(moveUp == -1)
            {
                cameraTransform.Translate(new Vector3(0f, -0.01f, 0f));
            }
            if(cameraTransform.position.y > cameraRange.y + cameraRange.height)
            {
                moveUp = -1;
            }
            if(cameraTransform.position.y < cameraRange.y)
            {
                moveUp = 1;
            }
        }
        Debug.Log(cameraTransform.position.x);
	}

}
