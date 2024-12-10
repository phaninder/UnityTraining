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
    // Start is called before the first frame update
    void Start()
    {
       radius = GetComponent<CircleCollider2D>().radius;
    }

    private void OnInit()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var position = Camera.main.WorldToScreenPoint(transform.position);

        position.x -= radius;
        position.y -= radius;
        if (position.x < 0 || position.x > GameData.ScreenWidth())
        {
            direction.x *= -1;
        }
        
        if (position.y < 0 || position.y > GameData.ScreenHeight())
        {
            direction.y *= -1;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
