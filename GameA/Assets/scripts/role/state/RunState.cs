using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : RoleState
{

    protected override string GetName()
    {
        return RoleState.RUN;
    }

    override public bool Accept(Dictionary<string, StateParam> param)
    {
        if (role.state == null) return true;
        if (role.state.StateName == RoleState.STAND) return true;
        if (role.state.StateName == RoleState.RUN) return true;
        if (role.state.StateName == RoleState.JUMP_UP) return false;
        if (role.state.StateName == RoleState.JUMP_DOWN) {
            if(r2d.velocity.y == 0)
            {
                return true;
            }
        }
        return false;
    }

    override public void StartState(Dictionary<string, StateParam> param)
    {
        this.param = param;
        Play();
        DirectionParam dir = GetParam(DirectionParam.NAME) as DirectionParam;
        r2d.velocity = new Vector2(dir.direction == DirectionParam.RIGHT ? 1f : -1f, r2d.velocity.y);
    }


    // Update is called once per frame
    void Update()
    {
        if (!Active)
        {
            return;
        }
        if (Mathf.Abs(r2d.velocity.x) < 0.1f) {
            role.ChangeState(RoleState.STAND);
        }
        if (r2d.velocity.y > 0.1f)
        {
            role.ChangeState(RoleState.JUMP_UP);
        }
        else if (r2d.velocity.y < -0.1f)
        {
            role.ChangeState(RoleState.JUMP_DOWN);
        }
    }

    override public void Quit()
    {
    }
}
