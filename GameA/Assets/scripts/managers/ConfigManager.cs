using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour {

    public static ConfigManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
