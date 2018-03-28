using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform bulletTransform;
    private Rect sceneSize;
    public BulletConfig config;

	// Use this for initialization
	void Start () {
        bulletTransform = gameObject.transform;
        sceneSize = GameVO.Instance.sceneSize;
	}
	
	// Update is called once per frame
	void Update () {
        //如果子弹超出场景范围，则直接消失
        if (bulletTransform.position.x < sceneSize.x - 1.0f || bulletTransform.transform.position.x > sceneSize.x + sceneSize.width + 1.0f ||
            bulletTransform.position.y < sceneSize.y - 1.0f || bulletTransform.position.y > sceneSize.y + sceneSize.height + 1.0f)
        {
            //Debug.Log("destory:" + bulletTransform.position.x + "," + bulletTransform.position.y + "," + sceneSize.x + "," + sceneSize.width + "," + sceneSize.y + "," + sceneSize.height);
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);

        /*if (collision.gameObject.layer == 8)
        {
            DestructiveItem ditem = collision.gameObject.GetComponent<DestructiveItem>();
            ditem.goDie();
        }*/

        //播放击中特效
        Instantiate(ResourceManager.Instance.GetResource(config.hitPrefabURL), gameObject.transform.position, transform.localRotation);

        //添加屏幕抖动
        GameVO.Instance.camera.Shake(100, 0.03f, 0.03f,"bullet",true);
    }
}
