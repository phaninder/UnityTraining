using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private Vector3 direction = new Vector3(1, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        float randomValue = Random.Range(0, 10);

        if(randomValue % 2 == 0 ) 
        {
            direction.x = 1f;
        }
        else
        {
            direction.x = -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("VerticalDirection") ||
                collision.gameObject.CompareTag("PlayerOne"))
            {
                direction.y = direction.y * -1; // -1 * -1 = 1, 1 * -1 = -1
            }

            if(collision.gameObject.CompareTag("HorizontalDirection"))
            {
                direction.x *= -1;
            }
        }
    }
}
