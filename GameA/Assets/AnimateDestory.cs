using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDestory : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
