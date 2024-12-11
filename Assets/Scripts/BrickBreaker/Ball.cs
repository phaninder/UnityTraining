using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector2 direction;

    public float radius;

    public float leftLimit, rightLimit, bottomLimit, topLimit;

    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;
        leftLimit = GameData.ScreenStartPosition.x + radius;
        bottomLimit = GameData.ScreenStartPosition.y + radius;
        rightLimit = GameData.ScreenEndPosition.x - radius;
        topLimit = GameData.ScreenEndPosition.y - radius;
    }

    private void OnInit()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;

        if (position.x < leftLimit || position.x > rightLimit)
        {
            direction.x *= -1;
        }
        
        if (position.y < bottomLimit || position.y > topLimit)
        {
            direction.y *= -1;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("Bat"))
            {
                direction.y *= -1;
            }
            else if(collision.gameObject.CompareTag("Brick"))
            {
                direction.y *= -1;
                Destroy(collision.gameObject);
            }
        }
    }
}
