using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float startingMoveSpeed;
    private Vector3 gameStartPos;

    private void OnEnable()
    {
        GameEvents.IncreaseSpeed += OnIncreaseSpeed;
        GameEvents.RestartGame += OnRestart;
    }

    private void OnDisable()
    {
        GameEvents.IncreaseSpeed -= OnIncreaseSpeed;
        GameEvents.RestartGame -= OnRestart;
    }

    private void Start()
    {
        gameStartPos = transform.position;
        startingMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public Vector3 GetNextUpdatePosition()
    {
        Vector3 nextPos = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
        return nextPos;
    }

    private void OnIncreaseSpeed(float speedIncrement)
    {
        moveSpeed += speedIncrement;
    }

    private void OnRestart()
    {
        transform.position = gameStartPos;
        moveSpeed = startingMoveSpeed;
    }
}
