using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    private CameraVO vo;

    private CameraLookAt lookAt;

    // Use this for initialization
    void Start () {
        vo = GameVO.Instance.camera;
    }
	
	// Update is called once per frame
	void Update () {
        Rect cameraRange = vo.cameraRange;
        Transform cameraTransform = vo.cameraTransform;

        //移动方式
        if(vo.lookAtChange)
        {
            vo.lookAtChange = false;
            lookAt = null;
            switch (vo.lookAtType)
            {
                case CameraLookAt.LOOK_AT_CENTER:
                    lookAt = new LookAtCenter();
                    break;
                case CameraLookAt.LOOK_AT_RANGE:
                    lookAt = new LookAtRange();
                    break;
                case CameraLookAt.LOOK_AT_FRONT:
                    lookAt = new LookAtFront();
                    break;

            }
        }
        if (lookAt != null)
        {
            lookAt.Update();
            if(lookAt.moveFlag)
            {
                float spped = 0.05f;
                float min = 0.005f;
                float speedx = (lookAt.moveX - cameraTransform.position.x) * spped;
                float speedy = (lookAt.moveY - cameraTransform.position.y) * spped;
                if (speedx > 0 && speedx < min) speedx = min;
                if (speedx < 0 && speedx > -min) speedx = -min;
                if (speedy > 0 && speedy < min) speedy = min;
                if (speedy < 0 && speedy > -min) speedy = -min;
                float xValue = (cameraTransform.position.x - lookAt.moveX) * (cameraTransform.position.x + speedx - lookAt.moveX);
                float yValue = (cameraTransform.position.y - lookAt.moveY) * (cameraTransform.position.y + speedy - lookAt.moveY);
                //Debug.Log(cameraTransform.position.x + "," + cameraTransform.position.y);
                //Debug.Log(lookAt.moveX + "," + lookAt.moveY);
                //Debug.Log(xValue + "," + yValue + "," + speedx + "," + speedy);
                if ((xValue < 0 || speedx == 0) && (yValue < 0 || speedy == 0))
                {
                    //Debug.Log("complete");
                    cameraTransform.position = new Vector3(lookAt.moveX, lookAt.moveY);
                }
                else
                {
                    float x = cameraTransform.position.x;
                    float y = cameraTransform.position.y;
                    if (xValue > 0)
                    {
                        x = cameraTransform.position.x + speedx;
                    }
                    else if (xValue < 0)
                    {
                        x = lookAt.moveX;
                    }
                    if (yValue > 0)
                    {
                        y = cameraTransform.position.y + speedy;
                    }
                    else if (yValue < 0)
                    {
                        y = lookAt.moveY;
                    }
                    cameraTransform.position = new Vector3(x, y);
                }
            }
        }

        //控制镜头移动范围
        if (cameraTransform.position.x > cameraRange.x + cameraRange.width)
        {
            cameraTransform.position = new Vector3(cameraRange.x + cameraRange.width, cameraTransform.position.y, cameraTransform.position.z);
        }
        if (cameraTransform.position.x < cameraRange.x)
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
    }
}
