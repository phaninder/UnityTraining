using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float leftMaxPos = -11.5f;
    [SerializeField]
    private float rightMaxPos = 11.5f;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && transform.position.x > leftMaxPos)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && transform.position.x < rightMaxPos)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
