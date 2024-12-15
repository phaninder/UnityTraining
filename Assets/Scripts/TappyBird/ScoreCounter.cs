using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        GameEvents.IncrementScore += OnIncrementScore;
    }

    private void OnDisable()
    {
        GameEvents.IncrementScore -= OnIncrementScore;
    }

    private void OnIncrementScore()
    {
        score++;
        Debug.Log("Current Score:" + score);
        scoreText.text = "Score: " + score;
    }
}
