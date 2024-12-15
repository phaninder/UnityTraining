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

    private void OnGameOver()
    {
        GameEvents.GameOver?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            OnGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Trigger"))
            {
                OnGameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("ScoreTrigger"))
            {
                Debug.Log("Increment Score");
                //if(GameEvents.IncrementScore != null)
                //{
                //    GameEvents.IncrementScore();
                //}
                GameEvents.IncrementScore?.Invoke();
            }
        }
    }
}
