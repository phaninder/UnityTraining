using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAndScaling : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetScale = Vector3.one;
    [SerializeField]
    private float scaleSpeed = 5.0f; // 5 units per second
    [SerializeField]
    private float deltaDiff = 0.1f;

    [SerializeField]
    private Vector3 targetRotation = new Vector3(0, 0, 45);
    [SerializeField]
    private float rotateSpeed = 15.0f;

    private float tempRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RotateContinuous()
    {
        tempRotation += rotateSpeed * Time.deltaTime;
        Vector3 currentRotation = new Vector3(0, 0, tempRotation);
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    private void RotateUsingLerp()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    private void ScaleUsingLerp()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }

    private void ScaleToTarget()
    {
        // Using speed and manual calculation
        Vector3 currentScale = transform.localScale;
        if ((targetScale.x - currentScale.x) > deltaDiff)
        {
            currentScale.x = currentScale.x + scaleSpeed * Time.deltaTime;
        }
        else
        {
            currentScale.x = targetScale.x;
        }

        if ((targetScale.y - currentScale.y) > deltaDiff)
        {
            currentScale.y = currentScale.y + scaleSpeed * Time.deltaTime;
        }
        else
        {
            currentScale.y = targetScale.y;
        }

        transform.localScale = currentScale;
    }
}
