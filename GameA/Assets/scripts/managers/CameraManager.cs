using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager Instance;

    //镜头
    public Camera mainCamera;
    //镜头的 transform 属性
    public Transform cameraTransform;


    //镜头范围，根据屏幕可视范围和移动范围计算得到
    [HideInInspector]
    public Rect cameraRange;
    //镜头在移动范围内 x 的移动比例
    [HideInInspector]
    public float cameraXPercent = 0;
    //镜头在移动范围内 y 的移动比例
    [HideInInspector]
    public float cameraYPercent = 0;

    //测试用
    public bool test = true;
    private int moveRight = 0;
    private int moveUp = 1;

    private void Awake()
    {
        Instance = this;
        Rect frontCameraRange = LayerManager.Instance.frontLayer.GetComponent<GameLayer>().cameraRange;
        cameraRange = new Rect(frontCameraRange.x, frontCameraRange.y, frontCameraRange.width, frontCameraRange.height);
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

        //控制镜头移动范围
        if (cameraTransform.position.x > cameraRange.x + cameraRange.width)
        {
            cameraTransform.position = new Vector3(cameraRange.x + cameraRange.width, cameraTransform.position.y, cameraTransform.position.z);
        }
        if(cameraTransform.position.x < cameraRange.x)
        {
            cameraTransform.position = new Vector3(cameraRange.x, cameraTransform.position.y, cameraTransform.position.z);
        }
        if (cameraTransform.position.y > cameraRange.y + cameraRange.height)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, cameraRange.y + cameraRange.height, cameraTransform.position.z);
        }
        if (cameraTransform.position.y < cameraRange.y)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, cameraRange.y, cameraTransform.position.z);
        }

        //计算镜头移动比例
        cameraXPercent = (cameraTransform.position.x - cameraRange.x) / cameraRange.width;
        cameraYPercent = (cameraTransform.position.y - cameraRange.y) / cameraRange.height;

    }

}
