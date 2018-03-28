using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameVO vo = GameVO.Instance;

        //创建角色信息
        vo.player = new RoleVO();
        vo.player.config = ConfigManager.Instance.GetRole(1);
        GunVO gun = new GunVO();
        gun.config = ConfigManager.Instance.GetGun(1);
        vo.player.guns.Add(gun);
        vo.player.gun = gun;
        gun = new GunVO();
        gun.config = ConfigManager.Instance.GetGun(2);
        vo.player.guns.Add(gun);

        //创建角色
        GameObject player = Instantiate(ResourceManager.Instance.GetResource(vo.player.config.prefabURL)) as GameObject;
        player.transform.parent = LayerManager.Instance.playerLayer.transform;
        player.transform.localPosition = new Vector3(player.transform.localPosition.x,player.transform.localPosition.y,0);
        player.GetComponent<Role>().vo = GameVO.Instance.player;
        //添加角色控制器
        player.AddComponent<RoleController>();
        player.GetComponent<Role>().Init();

        //加上镜头跟随
        vo.camera.LookAt(player.transform, CameraLookAt.LOOK_AT_FRONT);
    }
	
	// Update is called once per frame
	void Update () {
        //计算游戏时间
        GameVO.Instance.currentTime += Time.deltaTime * 1000;
    }
}
