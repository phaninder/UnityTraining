using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbodyRef;
    [SerializeField]
    private Vector2 velocity;

    private Vector3 startPos;
    private bool gameStarted = false;

    private void OnEnable()
    {
        GameEvents.RestartGame += OnRestart;
        GameEvents.StartGame += OnStartGame;
    }

    private void OnDisable()
    {
        GameEvents.RestartGame -= OnRestart;
        GameEvents.StartGame -= OnStartGame;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        rigidbodyRef.gravityScale = 0;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameStarted)
        {
            //rigidbodyRef.AddForce(force);
            rigidbodyRef.velocity = velocity;
        }
    }

    private void OnGameOver()
    {
        GameEvents.GameOver?.Invoke();
    }

    private void OnStartGame()
    {
        gameStarted = true;
        rigidbodyRef.gravityScale = 1;
    }

    private void OnRestart()
    {
        rigidbodyRef.velocity = Vector3.zero;
        transform.position = startPos;
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
