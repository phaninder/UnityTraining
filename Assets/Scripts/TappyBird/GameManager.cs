using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TappyBird
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private float startinSpeed = 1.0f;
        [SerializeField]
        private float maxSpeed = 10.0f;
        [SerializeField]
        private float currentSpeed = 1.0f;
        [SerializeField]
        private float speedIncrement = 0.5f;

        private bool hasGameStarted = false;

        private void OnEnable()
        {
            GameEvents.GameOver += OnGameOver;
            GameEvents.RestartGame += OnRestart;
        }

        private void OnDisable()
        {
            GameEvents.GameOver -= OnGameOver;
            GameEvents.RestartGame -= OnRestart;
        }

        private void IncreaseSpeed()
        {
            Debug.Log("In increase speed");
            if(currentSpeed < maxSpeed)
            {
                currentSpeed += speedIncrement;
                GameEvents.IncreaseSpeed?.Invoke(speedIncrement);
            }
        }

        private void OnRestart()
        {
            Time.timeScale = 1; 
            currentSpeed = 1.0f;
            InvokeRepeating("IncreaseSpeed", 3f, 5f);
            //SceneManager.LoadScene(1);
        }

        private void OnGameOver()
        {
            CancelInvoke("IncreaseSpeed");
            Time.timeScale = 0;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && !hasGameStarted)
            {
                hasGameStarted = true;
                InvokeRepeating("IncreaseSpeed", 3f, 5f);
                GameEvents.StartGame?.Invoke();
            }
        }
    }
}
