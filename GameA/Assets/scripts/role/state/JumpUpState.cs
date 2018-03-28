using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpState : RoleState {

    protected override string GetName()
    {
        return RoleState.JUMP_UP;
    }

    override public bool Accept(Dictionary<string, StateParam> param)
    {
        if (role.state.StateName == RoleState.STAND) return true;
        if (role.state.StateName == RoleState.RUN) return true;
        if (role.state.StateName == RoleState.JUMP_UP || role.state.StateName == RoleState.JUMP_DOWN)
        {
            if (vo.doubleJump == false)
            {
                vo.doubleJump = true;
                return true;
            }
        }
        return false;
    }

    override public void StartState(Dictionary<string, StateParam> param)
    {
        this.param = param;
        //角色正在开枪，并且方向跟现在的方向不一直则不允许换方向
        if (param != null && param.ContainsKey(DirectionParam.NAME))
        {
            if (vo.gun.fireFlag && (param[DirectionParam.NAME] as DirectionParam).direction != vo.direction)
            {
                param.Remove(DirectionParam.NAME);
            }
        }
        Play();
        VelocityParam vp = GetParam(VelocityParam.NAME) as VelocityParam;
        r2d.velocity = new Vector2(r2d.velocity.x + vp.x, vp.y);
    }


    // Update is called once per frame
    void Update()
    {
        if (!Active)
        {
            return;
        }
        if(r2d.velocity.y < 0)
        {
            role.ChangeState(RoleState.JUMP_DOWN);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Active)
        {
            return;
        }
        if (collision.gameObject.layer == 8)
        {
            //判断角色脚底是否高于地面上层，如果不加会出现卡在跳台边缘的问题
            if (IsHigherThan(role.gameObject,collision.gameObject))
            {
                //Debug.Log("jump up :" + role.gameObject.transform.position.y + "," + collision.gameObject.transform.position.y);
                role.ChangeState(RoleState.STAND);
            }
        }
    }

    override public void Quit()
    {
    }
}
