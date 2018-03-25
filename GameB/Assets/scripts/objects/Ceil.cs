using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceil : MonoBehaviour {

	public GameBody _body;
	//不能直接设置
	public GameBody body {
		get { return _body;}
	}

	//相对世界坐标
	public int coordx {
		get { return _body.coordx + ceilx;}
	}
	//相对世界坐标
	public int coordy {
		get { return _body.coordy + ceily; }
	}

	private int _ceilx = 0;
	//相对物体坐标
	public int ceilx {
		get { return _ceilx;}
	}
	private int _ceily = 0;
	//相对物体坐标
	public int ceily {
		get { return _ceily;}
	}

	private string avatarURL {
		get { return "ceil/default"; }
	}

	public Ability ability {
		get { return gameObject.GetComponent<Ability> ();}
	}

	//public void SetAbility<Ability>() {
	//}

	void Awake() {
		SetAvatar (ResourceManager.Instance.GetResource(avatarURL));
	}

	private void SetAvatar(Sprite sprite) {
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	public void ChangeCeilPosition(int x,int y)
	{
		_ceilx = x;
		_ceily = y;
		gameObject.transform.position = new Vector3(_ceilx * 0.16f+ gameObject.transform.parent.position.x,
			_ceily * 0.16f+ gameObject.transform.parent.position.y);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
