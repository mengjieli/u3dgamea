using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : RoleState {

    protected override string GetName()
    {
        return RoleState.STAND;
    }

    override public bool Accept(Dictionary<string, StateParam> param)
    {
        return true;
    }

    override public void StartState(Dictionary<string, StateParam> param)
    {
        this.param = param;
        Play();
        r2d.velocity = new Vector2(0, 0);
        vo.doubleJump = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(!Active)
        {
            return;
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
