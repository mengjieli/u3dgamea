using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUP : MonoBehaviour {

    //镜头
    public Camera mainCamera;

    private void Awake()
    {
        GameVO.Instance = new GameVO();
        GameVO vo = GameVO.Instance;
        vo.currentTime = 0;

        vo.camera.cameraSize = new Vector3();
        vo.camera.cameraSize = mainCamera.ViewportToWorldPoint(vo.camera.cameraSize);
        vo.camera.cameraSize.x = Mathf.Abs(vo.camera.cameraSize.x);
        vo.camera.cameraSize.y = Mathf.Abs(vo.camera.cameraSize.y);

        mainCamera.gameObject.AddComponent<GameCamera>();
    }

    private void Start()
    {
        GameVO vo = GameVO.Instance;
        //设置镜头属性
        Rect frontCameraRange = LayerManager.Instance.frontLayer.GetComponent<GameLayer>().cameraRange;
        vo.camera.cameraRange = new Rect(frontCameraRange.x, frontCameraRange.y, frontCameraRange.width, frontCameraRange.height);
        vo.camera.cameraTransform = mainCamera.transform;
        //记录场景大小
        Rect moveRange = LayerManager.Instance.frontLayer.GetComponent<GameLayer>().moveRange;
        vo.sceneSize = new Rect(moveRange.x, moveRange.y, moveRange.width, moveRange.height);
    }
}
