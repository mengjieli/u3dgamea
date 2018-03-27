using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDownState : RoleState {

    protected override string GetName()
    {
        return RoleState.JUMP_DOWN;
    }

    override public bool Accept(Dictionary<string, StateParam> param)
    {
        if(role.state.StateName == RoleState.STAND || role.state.StateName == RoleState.RUN || role.state.StateName == RoleState.JUMP_UP)
        {
            if(r2d.velocity.y < 0)
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
    }


    // Update is called once per frame
    void Update()
    {
        if (!Active)
        {
            return;
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
