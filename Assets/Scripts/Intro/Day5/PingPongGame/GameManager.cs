using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int winningScore;
    [SerializeField]
    private bool pauseGame;
    [SerializeField]
    private TextMeshProUGUI winText;

    [SerializeField]
    private GameObject gameOverTextObject;
    [SerializeField]
    private GameObject restartButtonObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckScore(int score, int playerId)
    {
        if (score >= winningScore)
        {
            winText.text = $"Player {playerId} has won the game!";
            Time.timeScale = 0;
            gameOverTextObject.SetActive(true);
            restartButtonObject.SetActive(true);
        }
    }

    public void OnRestartButtonPressed()
    {
        Time.timeScale = 1;
        gameOverTextObject.SetActive(false);
        restartButtonObject.SetActive(false);
    }
}
