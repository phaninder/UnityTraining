using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int screenWidth;
    private static int screenHeight;
    private static Vector2 screenStartPosition;
    private static Vector2 screenEndPosition;

    void Awake()
    {
        screenEndPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenStartPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);

        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    public static int ScreenWidth()
    {
        return screenWidth;
    }

    public static int ScreenHeight() => screenHeight;

    public static Vector2 ScreenStartPosition => screenStartPosition;

    public static Vector2 ScreenEndPosition => screenEndPosition;

}
