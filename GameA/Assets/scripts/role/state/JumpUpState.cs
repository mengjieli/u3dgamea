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
            if (rc.doubleJump == false)
            {
                rc.doubleJump = true;
                return true;
            }
        }
        return false;
    }

    override public void StartState(Dictionary<string, StateParam> param)
    {
        this.param = param;
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
            role.ChangeState(RoleState.STAND);
        }
    }

    override public void Quit()
    {
    }
}
