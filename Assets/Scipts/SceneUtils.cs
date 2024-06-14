using UnityEngine;
using System.Collections.Generic;

public static class SceneUtils
{
    public static GameObject[] GetAllObjectsInScene()
    {
        return GameObject.FindObjectsOfType<GameObject>();
    }
}
