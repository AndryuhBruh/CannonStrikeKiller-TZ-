using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // Лучше конечно поместить все настройки в другое место, но пока что так.
    public static int BallCount = 30;
    public static int WinCount = 20;
    public static bool isMusicOn = true;
    public static int CurrentLevel = 1;
}

public static class MenuHolder
{
    private static GameObject prefabName;
    public static GameObject Prefab
    {
        get
        {
            return prefabName;
        }
        set
        {
            prefabName = value;
        }
    }
}