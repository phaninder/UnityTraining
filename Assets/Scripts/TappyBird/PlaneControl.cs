using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbodyRef;
    [SerializeField]
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //rigidbodyRef.AddForce(force);
            rigidbodyRef.velocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        Debug.Log("Collided with rock");
    }
}
