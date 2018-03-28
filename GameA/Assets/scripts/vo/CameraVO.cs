using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVO
{
    //镜头大小，游戏实际的投影大小
    public Vector3 cameraSize;

    //摄像机位置信息
    public Transform cameraTransform;

    //位置 x
    public float x;

    //位置 y
    public float y;

    //镜头范围，根据屏幕可视范围和移动范围计算得到
    public Rect cameraRange;

    //观察对象
    public Transform lookAtTransform;

    //观察方式(镜头跟随方式)  所有情况都会考虑是否镜头移出可移动范围 参考CameraLookAt
    public string lookAtType = CameraLookAt.NONE;

    //镜头跟随方式是否改变
    public bool lookAtChange = false;

    public void LookAt(Transform lookAtTransform,string lookAtType)
    {
        if(CameraLookAt.Check(lookAtType))
        {
            this.lookAtTransform = lookAtTransform;
            this.lookAtType = lookAtType;
            this.lookAtChange = true;
        }
    }
}
