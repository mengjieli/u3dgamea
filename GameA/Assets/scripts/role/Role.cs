using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour {

    //角色全部可用的状态
    private ArrayList states = new ArrayList();

    //动画信息
    private Animator animator;

    //武器偏移点
    public Transform gunTransform;
    
    //角色当前状态
    [HideInInspector]
    public RoleState state = null;

    //角色信息
    [HideInInspector]
    public RoleVO vo;

    //角色当前身上的枪
    private GameObject gun;

    //初始化角色相关内容
    public void Init()
    {
        //获取角色相关的动画内容
        animator = GetComponent<Animator>();
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            switch (animator.runtimeAnimatorController.animationClips[i].name)
            {
                case RoleState.STAND:
                    states.Add(gameObject.AddComponent<StandState>());
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

        //初始化角色身上的武器(枪)
        ChangeGun();

        //跳转第一个状态
        ChangeState(RoleState.STAND);
    }

    //切换枪
    public void ChangeGun()
    {
        //删除旧的枪
        if(gun != null)
        {
            Destroy(gun);
        }
        //加入新的枪械
        if(vo.gun != null)
        {
            gun = Instantiate(ResourceManager.Instance.GetResource(vo.gun.config.prefabURL)) as GameObject;
            gun.GetComponent<Gun>().vo = vo.gun;
            gun.transform.parent = gunTransform;
            //设置枪的位置
            gun.transform.position = new Vector3(gunTransform.position.x,gunTransform.position.y,gunTransform.position.z);
        }
    }

    //转换状态
    public void ChangeState(string value,Dictionary<string,StateParam> param = null)
    {
        foreach (RoleState s in states) {
            //新的状态如果接受才能跳转
            if (s.StateName == value && s.Accept(param)) {
                if (state != null)
                {
                    //if(value != state.StateName)
                    //Debug.Log("quit " + state.StateName + "," + value + "," + gameObject.transform.position.y);
                    state.Active = false;
                    state.Quit();
                }
                state = s;
                state.Active = true;
                state.StartState(param);
                //Debug.Log("enter " + state.StateName + "," + gameObject.transform.position.y);
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
	
	// Update is called once per frame
	void Update () {
		if(vo.changeGun)
        {
            ChangeGun();
        }
	}
}
