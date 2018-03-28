using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform shootPointTransform;

    public GunVO vo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(vo.fireFlag)
        {
            if (GameVO.Instance.currentTime - vo.lastShootTime > vo.config.cd)
            {
                vo.lastShootTime = GameVO.Instance.currentTime;
                //发射子弹
                //获取子弹信息
                BulletConfig bulletConfig = ConfigManager.Instance.GetBullet(vo.config.bulletId);
                GameObject bullet = Instantiate(ResourceManager.Instance.GetResource(bulletConfig.prefabURL), shootPointTransform.position, shootPointTransform.localRotation) as GameObject;
                bullet.GetComponent<Bullet>().config = bulletConfig;
                bullet.transform.parent = LayerManager.Instance.bulletLayer.transform;
                bullet.transform.localPosition = new Vector3(bullet.transform.localPosition.x, bullet.transform.localPosition.y, 0);
                float scale = shootPointTransform.lossyScale.x > 0 ? 1 : -1;
                //设置子弹的缩放，根据角色的左右
                bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * scale, bullet.transform.localScale.y, bullet.transform.localScale.z);
                //设置子弹的初始速度
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletConfig.startV * scale, 0);
            }
        }
	}
}
