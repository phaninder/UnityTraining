using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private int playerId;
    [SerializeField]
    private GameManager gameManager;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Player "+ playerId +" : "+ score;
        gameManager.CheckScore(score, playerId);
    }
}
