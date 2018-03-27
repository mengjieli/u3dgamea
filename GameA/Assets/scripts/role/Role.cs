using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour {

    private ArrayList states = new ArrayList();
    private Animator animator;
    //角色当前状态
    public RoleState state = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            switch (animator.runtimeAnimatorController.animationClips[i].name) {
                case RoleState.STAND:
                    states.Add(gameObject.AddComponent< StandState>());
                    break;
                case RoleState.RUN:
                    states.Add(gameObject.AddComponent<RunState>());
                    break;
                case RoleState.JUMP_UP:
                    states.Add(gameObject.AddComponent<JumpUpState>());
                    break;
                case RoleState.JUMP_DOWN:
                    states.Add(gameObject.AddComponent<JumpDownState>());
                    break;
            }
        }
        ChangeState(RoleState.STAND);
    }

    //转换状态
    public void ChangeState(string value,Dictionary<string,StateParam> param = null)
    {
        foreach (RoleState s in states) {
            if (s.StateName == value && s.Accept(param)) {
                if (state != null)
                {
                    state.Active = false;
                    state.Quit();
                }
                state = s;
                state.Active = true;
                state.StartState(param);
                break;
            }
        }
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="name">动作名</param>
    /// <param name="flipx">水平缩放</param>
    public void Play(string name,int flipx = 0)
    {
        animator.Play(name);
        if(flipx != 0)
        {
            gameObject.transform.localScale = new Vector3(flipx, gameObject.transform.localScale.y);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
