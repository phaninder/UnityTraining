using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private Vector3 direction = new Vector3(1, 1, 0);
    [SerializeField]
    private float timeLimit = 3.0f;
    [SerializeField]
    private float maxBallSpeed = 10.0f;
    [SerializeField]
    private PlayerScoreCounter topPlayerScoreCounter;
    [SerializeField]
    private PlayerScoreCounter bottomPlayerScoreCounter;

    [SerializeField]
    private Vector3 startingPos;
    [SerializeField]
    private float startMoveSpeed;

    enum BallState
    {
        Start, //0
        Move, // 1
        Reset //2
    };

    [SerializeField]
    private BallState ballState = BallState.Start;

    private Coroutine changeMoveSpeedCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        ballState = BallState.Start;
        startingPos = transform.position;
        startMoveSpeed = moveSpeed;
        OnInit();
    }

    private void OnInit()
    {
        float randomValue = Random.Range(0, 10);
        moveSpeed = startMoveSpeed;

        if (randomValue % 2 == 0)
        {
            direction.x = 1f;
        }
        else
        {
            direction.x = -1f;
        }
        direction.y = 1f;
        StartCoroutine(ChangeMoveSpeed());
        StartCoroutine(ChangeToMove());
    }

    private IEnumerator ChangeToMove()
    {
        yield return new WaitForSeconds(2);
        ballState = BallState.Move;
    }

    IEnumerator ChangeMoveSpeed()
    {
        yield return new WaitForSeconds(timeLimit);
        if(moveSpeed < maxBallSpeed && ballState == BallState.Move)
        {
            moveSpeed++; // moveSpeed = moveSpeed + 1;
            changeMoveSpeedCoroutine = StartCoroutine(ChangeMoveSpeed());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ballState == BallState.Move)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("VerticalDirection") ||
                collision.gameObject.CompareTag("Bat"))
            {
                direction.y = direction.y * -1; // -1 * -1 = 1, 1 * -1 = -1
            }

            if(collision.gameObject.CompareTag("HorizontalDirection"))
            {
                direction.x *= -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("TopTrigger"))
            {
                if(bottomPlayerScoreCounter != null)
                {
                    bottomPlayerScoreCounter.IncreaseScore();
                }
            }
            else if(collision.gameObject.CompareTag("DownTrigger"))
            {
                if (topPlayerScoreCounter != null)
                {
                    topPlayerScoreCounter.IncreaseScore();
                }
            }
        }

        OnReset();
    }

    private void OnReset()
    {
        StopCoroutine(changeMoveSpeedCoroutine);
        ballState = BallState.Reset;
        transform.position = startingPos;
        OnInit();
    }
}
