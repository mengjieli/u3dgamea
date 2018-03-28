using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleVO {

    //配置
    public RoleConfig config;

    //角色的方向
    public string direction = DirectionParam.RIGHT;

    //装备的枪
    public List<GunVO> guns = new List<GunVO>();

    //正在使用的枪
    public GunVO gun;

    //是否用过二次跳跃
    public bool doubleJump = false;

    //角色是否切换过枪
    public bool changeGun = false;

    //切换角色身上的下一把枪
    public void ChangeGunNext()
    {
        GunVO old = gun;
        int index = guns.IndexOf(gun);
        if(index == -1)
        {
            index = 0;
        }
        else
        {
            index++;
            index = index % guns.Count;
        }
        gun = guns[index];
        if(gun != old)
        {
            changeGun = true;
        }
    }
}
