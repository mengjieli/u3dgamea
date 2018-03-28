using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色状态
public abstract class RoleState : MonoBehaviour
{
    //空
    public const string  NONE = "None";
    //站立
    public const string STAND = "Stand";
    //跑步
    public const string RUN = "Run";
    //跳起
    public const string JUMP_UP = "JumpUp";
    //跳落
    public const string JUMP_DOWN = "JumpDown";
    //受伤
    public const string HURT = "Hurt";
    //爬
    public const string CLIMB = "Climb";

    private bool _active = false;
    public bool Active
    {
        get { return _active; }
        set { _active = value; }
    }

    public string StateName
    {
        get { return GetName(); }
    }

    protected Role role;

    protected Rigidbody2D r2d;

    protected RoleController rc;

    protected RoleVO vo;

    protected Dictionary<string, StateParam> param;

    private void Awake()
    {
        role = GetComponent<Role>();
        r2d = GetComponent<Rigidbody2D>();
        rc = GetComponent<RoleController>();
        vo = role.vo;
    }

    protected void Play()
    {
        DirectionParam dir = GetParam(DirectionParam.NAME) as DirectionParam;
        if (dir != null)
        {
            vo.direction = dir.direction;
            role.Play(StateName, dir.flipx);
        }
        else
        {
            role.Play(StateName);
        }
    }

    protected StateParam GetParam(string name)
    {
        if (param != null && param.ContainsKey(name)) return param[name];
        return null;
    }

    //开火
    public void Fire()
    {
        if(StateName == RoleState.STAND || StateName == RoleState.RUN || StateName == RoleState.JUMP_UP || StateName == RoleState.JUMP_DOWN)
        {
            if(vo.gun != null)
            {
                vo.gun.Fire();
            }
        }
    }

    public void StopFire()
    {
        if (vo.gun != null)
        {
            vo.gun.StopFire();
        }
    }

    abstract public bool Accept(Dictionary<string, StateParam> param);

    abstract public void StartState(Dictionary<string, StateParam> param);

    abstract public void Quit();

    abstract protected string GetName();
}
