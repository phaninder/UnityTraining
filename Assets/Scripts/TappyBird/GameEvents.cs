using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action IncrementScore;
    public static Action<float> IncreaseSpeed;
    public static Action GameOver;
    public static Action RestartGame;
}
