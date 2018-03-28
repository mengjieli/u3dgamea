using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager Instance;

    private static Dictionary<string, Object> resources = new Dictionary<string, Object>();

    private void Awake()
    {
        Instance = this;
    }

    //获取资源
    public Object GetResource(string url)
    {
        if(resources.ContainsKey(url) == false)
        {
            resources.Add(url, Resources.Load(url));
            Resources.UnloadUnusedAssets();
        }
        return resources[url];
    }
}
