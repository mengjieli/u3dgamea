using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVO {

    public static GameVO Instance;

    //场景尺寸
    public Rect sceneSize;

    //摄像机
    public CameraVO camera = new CameraVO();

    //玩家角色
    public RoleVO player;

    //记录游戏当前时间
    public float currentTime;

    //游戏上一帧的运行间隔
    public float timeGap = 0;
}
