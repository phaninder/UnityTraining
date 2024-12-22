using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenButtons : MonoBehaviour
{
    public Action JumpEvent;
    public Action<float> Move;

    public Joystick onScreenJoystick;

    private bool moveRight, moveLeft;

    private void Update()
    {
        Move?.Invoke(onScreenJoystick.Horizontal);
        //if (moveRight)
        //{
        //    Move?.Invoke(1);
        //}
        //else if (moveLeft)
        //{
        //    Move?.Invoke(-1);
        //}
        //else
        //{
        //    Move?.Invoke(0);
        //}
    }


    public void OnLeftButtonPressed()
    {
        moveLeft = true;
    }

    public void OnLeftButtonReleased()
    {
        moveLeft = false;
    }

    public void OnRightButtonPressed()
    {
        moveRight = true;
    }

    public void OnRightButtonReleased()
    {
        moveRight = false;
    }

    public void OnJumpButtonPressed()
    {
        JumpEvent?.Invoke();
    }
}
