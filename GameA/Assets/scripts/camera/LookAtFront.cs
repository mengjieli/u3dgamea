using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFront : CameraLookAt
{
    public float rangeLeft = 0.1f;
    public float rangeRight = 0.1f;
    public float rangeUp = 0.5f;
    public float rangeDown = 0.5f;

    override protected string GetName()
    {
        return CameraLookAt.LOOK_AT_FRONT;
    }

    // Update is called once per frame
    override public void Update()
    {
        CameraVO vo = GameVO.Instance.camera;
        Transform cameraTransform = vo.cameraTransform;
        Transform lookAtTransform = vo.lookAtTransform;

        //是否需要移动的标志位
        float x = cameraTransform.position.x;
        float y = lookAtTransform.position.y;

        if (lookAtTransform.lossyScale.x > 0)
        {
            x = lookAtTransform.position.x + vo.cameraSize.x * 0.4f;
        }
        else
        {
            x = lookAtTransform.position.x - vo.cameraSize.x * 0.4f;
        }

        this.moveFlag = x != cameraTransform.position.x || y != cameraTransform.position.y ? true : false;
        this.moveX = x;
        this.moveY = y;
    }
}
