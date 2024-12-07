using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvents : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("From OnCollisionEnter2D Collided with :" + collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("From OnCollisionStay2D Collided with :" + collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("From OnCollisionExit2D Collided with :" + collision.gameObject.name);
    }
}
