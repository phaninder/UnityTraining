using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField]
    private OnScreenButtons onScreenButton;

    // Update is called once per frame
    void Update()
    {
        //if(Input.acceleration.magnitude >0)
        //{
        //    // access x and y axis to tilt character
        //    Input.acceleration.x;
        //    Input.acceleration.y;
        //}
        float movementX = Input.acceleration.x;
        onScreenButton.Move?.Invoke(movementX);
    }
}
