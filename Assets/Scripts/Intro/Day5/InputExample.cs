using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("From KeyDown Left Arrow");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("From GetKey Left Arrow");
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("From GetKeyUp Left Arrow");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("From GetKeyDown Right Arrow");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("From GetKeyRight Arrow");
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("From GetKeyUp Right Arrow");
        }
    }

    void KeyDownExample()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("From KeyDown Left Arrow");
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
