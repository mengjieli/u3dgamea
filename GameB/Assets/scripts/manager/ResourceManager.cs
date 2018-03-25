using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	public static ResourceManager Instance;

	void Awake()
	{
		Instance = this;
	}

	private Dictionary<string,Sprite> list = new Dictionary<string, Sprite>();

	public Sprite GetResource(string url)
	{
		if (!list.ContainsKey(url)) {
			list.Add(url,Resources.Load (url,typeof(Sprite)) as Sprite);
		}
		return list [url];
	}
}
