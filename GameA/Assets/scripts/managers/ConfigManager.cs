using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour {

    public static ConfigManager Instance;

    //角色配置
    private Dictionary<int, RoleConfig> roles = new Dictionary<int, RoleConfig>();

    //枪配置
    private Dictionary<int, GunConfig> guns = new Dictionary<int, GunConfig>();

    //子弹配置
    private Dictionary<int, BulletConfig> bullets = new Dictionary<int, BulletConfig>();

    private void Awake()
    {
        Instance = this;
        //模拟第一种角色
        RoleConfig role = new RoleConfig();
        role.id = 1;
        role.prefabURL = "prefab/player";
        roles.Add(role.id, role);

        //模拟第一种子弹
        BulletConfig bullet = new BulletConfig();
        bullet.id = 1;
        bullet.prefabURL = "bullet/FireBullet";
        bullet.hitPrefabURL = "bullet/HitAnimation";
        bullet.startV = 5f;
        bullet.rotationRange = 10;
        bullets.Add(bullet.id,bullet);

        //模拟第二种子弹
        bullet = new BulletConfig();
        bullet.id = 2;
        bullet.prefabURL = "bullet/FireBullet";
        bullet.hitPrefabURL = "bullet/HitAnimation";
        bullet.startV = 1f;
        bullet.rotationRange = 20;
        bullets.Add(bullet.id, bullet);

        //模拟第一种枪
        GunConfig gun = new GunConfig();
        gun.id = 1;
        gun.prefabURL = "gun/Gun";
        gun.bulletId = 1;
        gun.cd = 100;
        gun.bulletCount = 1;
        guns.Add(gun.id, gun);

        //模拟第二种枪
        gun = new GunConfig();
        gun.id = 2;
        gun.prefabURL = "gun/Gun";
        gun.bulletId = 2;
        gun.cd = 50;
        gun.bulletCount = 1;
        guns.Add(gun.id, gun);
    }

    public RoleConfig GetRole(int id)
    {
        return roles[id];
    }

    public GunConfig GetGun(int id)
    {
        return guns[id];
    }

    public BulletConfig GetBullet(int id)
    {
        return bullets[id];
    }
}
