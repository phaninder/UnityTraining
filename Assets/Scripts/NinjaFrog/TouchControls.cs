using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField]
    private OnScreenButtons onScreenButton;
    [SerializeField]
    private Vector3 touchStartPos, touchEndPos;
    [SerializeField]
    private float swipeDelta = 100;

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

        if (Input.touchCount > 0)
        {
            //for (int i = 0; i < Input.touchCount; i++)
            //{
            //    Touch touch = Input.touches[i];
            //    //if (touch.phase == TouchPhase.Began)
            //    //{
            //    //    onScreenButton.JumpEvent?.Invoke();
            //    //}


            //    if (touch.phase == TouchPhase.Began)
            //    {
            //        Debug.Log($"{touch.fingerId} has started");
            //    }

            //    if (touch.phase == TouchPhase.Moved)
            //    {
            //        Debug.Log($"{touch.fingerId} Move started");
            //    }

            //    if (touch.phase == TouchPhase.Stationary)
            //    {
            //        Debug.Log($"{touch.fingerId} Touch is Idle");
            //    }

            //    if (touch.phase == TouchPhase.Ended)
            //    {
            //        Debug.Log($"{touch.fingerId} Touch has ended");
            //    }

            //    if (touch.phase == TouchPhase.Canceled)
            //    {
            //        Debug.Log($"{touch.fingerId} Touch has cancelled");
            //    }
            //}

            //Drag detection
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;

                if (touchEndPos.x < touchStartPos.x)
                {
                    //swiped toward left
                    if (touchStartPos.x - touchEndPos.x > swipeDelta)
                    {
                        Debug.Log("Swiped toward left");
                    }
                }
                else if(touchEndPos.x >  touchStartPos.x)
                {
                    //Check for Right swipe
                    if(touchEndPos.x - touchStartPos.x > swipeDelta)
                    {
                        Debug.Log("Swiped toward right");
                    }
                }

                //Top and bottom check
                if (touchEndPos.y < touchStartPos.y)
                {
                    //swiped toward down
                    if (touchStartPos.y - touchEndPos.y > swipeDelta)
                    {
                        Debug.Log("Swiped toward down");
                    }
                }
                else if (touchEndPos.y > touchStartPos.y)
                {
                    //Check for Right swipe
                    if (touchEndPos.y - touchStartPos.y > swipeDelta)
                    {
                        Debug.Log("Swiped toward Up");
                    }
                }
            }
        }
    }
}
