using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFunctionality : MonoBehaviour
{
    [SerializeField]
    private ObjectMovement objMovementRef;
    private void OnEnable()
    {
        objMovementRef.enabled = false;
        GameEvents.StartGame += OnGameStart;
    }

    private void OnDisable()
    {
        GameEvents.StartGame -= OnGameStart;
    }

    private void OnGameStart()
    {
        objMovementRef.enabled = true;
    }
}
