using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour {

    Role role;
    float lastJump = 0;

    private void Awake()
    {
        role = GetComponent<Role>();
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Dictionary<string, StateParam> param = new Dictionary<string, StateParam>();
        if (Input.GetAxis("Horizontal") < 0)
        {
            param.Add(DirectionParam.NAME, new DirectionParam(DirectionParam.LEFT));
            role.ChangeState(RoleState.RUN, param);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            param.Add(DirectionParam.NAME, new DirectionParam(DirectionParam.RIGHT));
            role.ChangeState(RoleState.RUN, param);
        }
        if (Input.GetAxis("Jump") != 0 && lastJump == 0)
        {
            param.Add(VelocityParam.NAME, new VelocityParam(0, 2.5f));
            role.ChangeState(RoleState.JUMP_UP, param);
        }
        lastJump = Input.GetAxis("Jump");
        if (Input.GetAxis("Fire1") != 0)
        {
            role.state.Fire();
        }
        else
        {
            role.state.StopFire();
        }
    }
}
