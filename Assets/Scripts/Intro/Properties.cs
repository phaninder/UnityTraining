using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    //Variable to edit
    [SerializeField]
    private Vector3 position = new Vector3(0,0,0);
    [SerializeField]
    private Vector3 scale = new Vector3(1,1,1);
    [SerializeField]    
    private Vector3 rotation = new Vector3(0, 0, 0);

    //Component
    [SerializeField]
    private SpriteRenderer renderer;

    [SerializeField]
    private Vector3 endPosition = new Vector3(0,0,0);
    [SerializeField]
    private float moveSpeed = 2.0f; // 2 meters per second

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);

        ////Position
        Debug.Log(transform.position);
        Debug.Log(transform.rotation);
        Debug.Log(transform.localScale);

        ////Changing position
        transform.position = position;

        ////Change Scale
        transform.localScale = scale;

        ////Change Rotation
        transform.rotation = Quaternion.Euler(rotation);

        //Get a component using GetComponent
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer != null )
        {
            renderer.color = Color.yellow;
        }

        //1.  Define a variable of specific type, and use getcomponent
        Basics basics = GetComponent<Basics>();
        //Check for Null
        if (basics != null)
        {
            Debug.Log("Name of script: " + basics.myName);
        }
    }

    // Gets called multiple times in a second,  example 60 - 100
    private void Update()
    {
        Vector3 currentPosition =  Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime); // 2 mt per second
        transform.position = currentPosition;
    }
}
