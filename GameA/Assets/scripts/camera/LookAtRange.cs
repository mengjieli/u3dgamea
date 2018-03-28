using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRange : CameraLookAt
{
    public float rangeLeft = 0.1f;
    public float rangeRight = 0.1f;
    public float rangeUp = 0.05f;
    public float rangeDown = 0.05f;

    override protected string GetName()
    {
        return CameraLookAt.LOOK_AT_RANGE;
    }

    // Update is called once per frame
    override public void Update()
    {
        CameraVO vo = GameVO.Instance.camera;
        Transform cameraTransform = vo.cameraTransform;
        Transform lookAtTransform = vo.lookAtTransform;

        //是否需要移动的标志位
        bool moveFlag = false;
        float x = cameraTransform.position.x;
        float y = cameraTransform.position.y;
        //如果角色不超过某个区域就不移动

        //超出可移动范围左边
        if (lookAtTransform.position.x < cameraTransform.position.x - vo.cameraSize.x * (0.5f - rangeLeft))
        {
            moveFlag = true;
            x = lookAtTransform.position.x + vo.cameraSize.x * (0.5f - rangeLeft);
        }
        //超出可移动范围右边
        if (lookAtTransform.position.x > cameraTransform.position.x + vo.cameraSize.x * (0.5f - rangeRight))
        {
            moveFlag = true;
            x = lookAtTransform.position.x - vo.cameraSize.x * (0.5f - rangeRight);
        }
        //超出可移动范围下边
        if (lookAtTransform.position.y < cameraTransform.position.y - vo.cameraSize.y * (0.5f - rangeDown))
        {
            moveFlag = true;
            y = lookAtTransform.position.y + vo.cameraSize.y * (0.5f - rangeDown);
        }
        //超出可移动范围上边
        if (lookAtTransform.position.y > cameraTransform.position.y + vo.cameraSize.y * (0.5f - rangeUp))
        {
            moveFlag = true;
            y = lookAtTransform.position.y - vo.cameraSize.y * (0.5f - rangeUp);
        }
        this.moveFlag = moveFlag;
        this.moveX = x;
        this.moveY = y;
    }
}
