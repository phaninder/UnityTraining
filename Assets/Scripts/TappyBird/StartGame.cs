using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject taptapGameObject;

    private void OnEnable()
    {
        GameEvents.StartGame += OnGameStart;
    }

    private void OnDisable()
    {
        GameEvents.StartGame -= OnGameStart;
    }

    private void OnGameStart()
    {
        taptapGameObject.SetActive(false);
    }
}
