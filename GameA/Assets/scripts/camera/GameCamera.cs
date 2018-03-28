using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    private CameraVO vo;

    private CameraLookAt lookAt;

    private ArrayList shakes = new ArrayList();

    // Use this for initialization
    void Start () {
        vo = GameVO.Instance.camera;
    }
	
	// Update is called once per frame
	void Update () {
        Rect cameraRange = vo.cameraRange;
        Transform cameraTransform = vo.cameraTransform;

        //镜头新的位置
        float cameraX = cameraTransform.position.x;
        float cameraY = cameraTransform.position.y;

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
            if(lookAt.moveFlag) //镜头缓动效果，离目标点越近移动越慢，但有最小速度限制
            {
                float spped = 0.05f; //每次移动剩余距离的 0.05 倍，计算总的时间需要用到积分，有点难度 (@.@)
                float min = 0.005f;
                float speedx = (lookAt.moveX - cameraTransform.position.x) * spped;
                float speedy = (lookAt.moveY - cameraTransform.position.y) * spped;
                if (speedx > 0 && speedx < min) speedx = min;
                if (speedx < 0 && speedx > -min) speedx = -min;
                if (speedy > 0 && speedy < min) speedy = min;
                if (speedy < 0 && speedy > -min) speedy = -min;
                float xValue = (cameraTransform.position.x - lookAt.moveX) * (cameraTransform.position.x + speedx - lookAt.moveX);
                float yValue = (cameraTransform.position.y - lookAt.moveY) * (cameraTransform.position.y + speedy - lookAt.moveY);
                if ((xValue < 0 || speedx == 0) && (yValue < 0 || speedy == 0)) //移动完成
                {
                    cameraX = lookAt.moveX;
                    cameraY = lookAt.moveY;
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
                    cameraX = x;
                    cameraY = y;
                }
            }
        }

        //添加新的屏幕震动
        while(vo.shakes.Count != 0)
        {
            CameraShake shake = vo.shakes[0] as CameraShake;
            //震动唯一，则覆盖之前的
            if (shake.only)
            {
                for (int i = 0; i < shakes.Count; i++)
                {
                    if((shakes[i] as CameraShake).tag == shake.tag)
                    {
                        shakes.RemoveAt(i);
                        i--;
                    }
                }
            }
            shakes.Add(shake);
            vo.shakes.RemoveAt(0);
        }

        //计算屏幕震动
        for (int i = 0; i < shakes.Count; i++)
        {
            (shakes[i] as CameraShake).Update();
            cameraX += (shakes[i] as CameraShake).x;
            cameraY += (shakes[i] as CameraShake).y;
            if ((shakes[i] as CameraShake).completeFlag == true)
            {
                shakes.RemoveAt(i);
                i--;
            }
        }

        //控制镜头移动范围
        if (cameraX > cameraRange.x + cameraRange.width)
        {
            cameraX = cameraRange.x + cameraRange.width;
        }
        if (cameraX < cameraRange.x)
        {
            cameraX = cameraRange.x;
        }
        if (cameraY > cameraRange.y + cameraRange.height)
        {
            cameraY = cameraRange.y + cameraRange.height;
        }
        if (cameraY < cameraRange.y)
        {
            cameraY = cameraRange.y;
        }

        //设置镜头位置
        cameraTransform.position = new Vector3(cameraX, cameraY);
    }
}
