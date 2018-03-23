using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //角色动画控制
    public Animator avatar;
    //角色的物理对象
    public Rigidbody2D r2d;
    //角色的 transform
    public Transform trans;
    //发射器
    public Shooter gunShooter;
    //向左的控制键
    public KeyCode leftKey = KeyCode.A;
    //向右的控制键
    public KeyCode rightKey = KeyCode.D;
    //向上的控制键
    public KeyCode upKey = KeyCode.W;
    //向下的控制键
    public KeyCode downKey = KeyCode.D;
    //射击键
    public KeyCode shootKey = KeyCode.J;

    //角色水平运动的方向， 1：向右   -1：向左
    int runHorizontal = 0;
    //角色垂直运动的方向， 1：向上   -1：向下
    int runVertical = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            stateGround = true;
        }
    }

    //动画控制属性
    //是否在地面
    bool stateGround
    {
        get { return avatar.GetBool("stateGround"); }
        set { avatar.SetBool("stateGround", value); }
    }
    //是否在跑动
    bool stateRun
    {
        get { return avatar.GetBool("stateRun"); }
        set { avatar.SetBool("stateRun", value); }
    }
    //是否在掉落
    bool stateFall
    {
        get { return avatar.GetBool("stateFall"); }
        set { avatar.SetBool("stateFall", value); }
    }
    //是否反转
    bool flipX
    {
        get { return gameObject.transform.localScale.x == 1.0f?true:false; }
        set { gameObject.transform.localScale = new Vector3(value?-1.0f:1.0f,1.0f,1.0f); }
    }

    //角色是否容许二次跳跃
    bool doubleJump = true;

    //角色是否正在跳跃
    bool jump = false;

    // Use this for initialization
    void Start() {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("check collision");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(leftKey))
        {
            runHorizontal = -1;
        }
        if (Input.GetKeyUp(leftKey) && runHorizontal == -1)
        {
            runHorizontal = 0;
        }
        if (Input.GetKeyDown(rightKey))
        {
            runHorizontal = 1;
        }
        if (Input.GetKeyUp(rightKey) && runHorizontal == 1)
        {
            runHorizontal = 0;
        }
        if (Input.GetKeyDown(upKey) && (stateGround || doubleJump))
        {
            jump = true;
        }
        if(Input.GetKeyDown(shootKey))
        {
            gunShooter.IsShoot = true;
        }
        if (Input.GetKeyUp(shootKey))
        {
            gunShooter.IsShoot = false;
        }
    }

    private void FixedUpdate()
    {
        //控制角色的水平移动
        if (runHorizontal == 1)
        {
            flipX = false;
            //trans.localScale = new Vector3(1, 1, 1);
            r2d.velocity = new Vector2(1f, r2d.velocity.y);
        }
        else if (runHorizontal == -1)
        {
            flipX = true;
            //trans.localScale = new Vector3(-1, 1, 1);
            r2d.velocity = new Vector2(-1f, r2d.velocity.y);
        }

        if (r2d.velocity.x > -0.1f && r2d.velocity.x < 0.1f)
        {
            stateRun = false;
        }
        else
        {
            stateRun = true;
        }

        //控制角色的跳跃
        if (jump)
        {
            if (!stateGround) //如果已经在空中，并且用了跳跃，表示用的二次跳跃
            {
                doubleJump = false; //设置不容许二次跳跃
            }
            r2d.velocity = new Vector2(r2d.velocity.x, 3f);
            jump = false;
            stateGround = false;
        }

        //判断角色是否浮空，目前的判断还有问题，但绝大部分情况下正常
        if (r2d.velocity.y == 0f) //落地
        {
            doubleJump = true; //重置二次跳跃
        }
        else //空中
        {
            if (r2d.velocity.y > 0f)
            {
                stateFall = false;
            }
            else
            {
                stateFall = true;
            }
        }

        //加上临时功能，如果角色掉入舞台外，则重新加入舞台
        if (trans.position.y < -1f) //跳出舞台下面
        {
            trans.position = new Vector3(trans.position.x, 1.36f, trans.position.z);
        }
        if (trans.position.x < -2f) //跳出舞台左边
        {
            trans.position = new Vector3(2f, trans.position.y, trans.position.z);
        }
        if (trans.position.x > 2f) //跳出舞台右边
        {
            trans.position = new Vector3(-2f, trans.position.y, trans.position.z);
        }
    }
}
