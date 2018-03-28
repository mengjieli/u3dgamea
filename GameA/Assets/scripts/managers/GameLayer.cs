using UnityEngine;

public class GameLayer : MonoBehaviour {

    //可移动范围
    public Rect moveRange;
    //镜头范围，根据屏幕可视范围和移动范围计算得到
    [HideInInspector]
    public Rect cameraRange;

    private void Awake()
    {
        Vector3 cameraSize = GameVO.Instance.camera.cameraSize;
        //计算镜头实际可移动范围
        cameraRange.x = moveRange.x + Mathf.Abs(cameraSize.x);
        cameraRange.width = moveRange.width - 2 * Mathf.Abs(cameraSize.x);
        cameraRange.y = moveRange.y + Mathf.Abs(cameraSize.y);
        cameraRange.height = moveRange.height - 2 * Mathf.Abs(cameraSize.y);
    }

        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rect cameraRange = GameVO.Instance.camera.cameraRange;
        Transform cameraTransform = GameVO.Instance.camera.cameraTransform;
        if (cameraRange.Equals(this.cameraRange) == false)
        {
            //计算镜头移动比例
            float xPercent = (cameraTransform.position.x - cameraRange.x) / cameraRange.width;
            float yPercent = (cameraTransform.position.y - cameraRange.y) / cameraRange.height;
            float x = this.cameraRange.x + this.cameraRange.width * xPercent;
            float y = this.cameraRange.y + this.cameraRange.height * yPercent;
            float cameraX = cameraRange.x + cameraRange.width * xPercent;
            float cameraY = cameraRange.y + cameraRange.height * yPercent;
            gameObject.transform.position = new Vector3(cameraX - x, cameraY - y, gameObject.transform.position.z);
        }
    }
}
