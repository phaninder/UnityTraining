using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private void OnEnable()
    {
        GameEvents.IncreaseSpeed += OnIncreaseSpeed;
    }

    private void OnDisable()
    {
        GameEvents.IncreaseSpeed -= OnIncreaseSpeed;
    }

    private void OnIncreaseSpeed(float speedIncrement)
    {
        moveSpeed += speedIncrement;
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
}
