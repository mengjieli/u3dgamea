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
            Debug.Log("camera:" + vo.lookAtType);
            switch (vo.lookAtType)
            {
                case CameraLookAt.LOOK_AT_CENTER:
                    lookAt = new LookAtCenter();
                    break;
                case CameraLookAt.LOOK_AT_RANGE:
                    lookAt = new LookAtRange();
                    break;
                    
            }
        }
        if (lookAt != null)
        {
            lookAt.Update();
            if(lookAt.moveFlag)
            {
                cameraTransform.position = new Vector3(lookAt.moveX,lookAt.moveY);
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
