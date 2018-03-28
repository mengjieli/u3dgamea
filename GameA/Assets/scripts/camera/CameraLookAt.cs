using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraLookAt {

    public const string NONE = "None";
    public const string LOOK_AT_CENTER = "LookAtCenter";
    public const string LOOK_AT_RANGE = "LookAtRange";

    public static bool Check(string lookAtType)
    {
        if (lookAtType == CameraLookAt.NONE) return true;
        if (lookAtType == CameraLookAt.LOOK_AT_CENTER) return true;
        if (lookAtType == CameraLookAt.LOOK_AT_RANGE) return true;
        return false;
    }

    public string Name
    {
        get { return GetName(); }
    }

    public bool moveFlag = false;
    public float moveX;
    public float moveY;

    abstract protected string GetName();

    // Update is called once per frame
    abstract public void Update();
}
