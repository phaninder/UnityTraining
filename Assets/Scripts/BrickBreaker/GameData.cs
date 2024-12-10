using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int screenWidth;
    private static int screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    public static int ScreenWidth()
    {
        return screenWidth;
    }

    public static int ScreenHeight() => screenHeight;
}
