using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void OnEnable()
        {
            GameEvents.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            GameEvents.GameOver -= OnGameOver;
        }

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("IncreaseSpeed", 3f, 5f);
        }

        private void IncreaseSpeed()
        {
            if(currentSpeed < maxSpeed)
            {
                currentSpeed += speedIncrement;
                GameEvents.IncreaseSpeed?.Invoke(speedIncrement);
            }
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
        }
    }
}
