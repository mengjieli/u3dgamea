using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenter : CameraLookAt
{

    override protected string GetName()
    {
        return CameraLookAt.LOOK_AT_CENTER;
    }
	
	// Update is called once per frame
	override public void Update ()
    {
        CameraVO vo = GameVO.Instance.camera;
        Transform cameraTransform = vo.cameraTransform;
        Transform lookAtTransform = vo.lookAtTransform;
        cameraTransform.localPosition = new Vector3(lookAtTransform.position.x, lookAtTransform.position.y);
    }
}
