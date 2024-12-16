using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI gameOverCurrentScoreText;
    [SerializeField]
    private TextMeshProUGUI gameOverHighscoreText;

    private const string HighScoreKey = "HighScore";

    private void OnEnable()
    {
        GameEvents.IncrementScore += OnIncrementScore;
        GameEvents.RestartGame += OnRestart;
        GameEvents.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.IncrementScore -= OnIncrementScore;
        GameEvents.RestartGame -= OnRestart;
        GameEvents.GameOver -= OnGameOver;
    }

    //private void Start()
    //{
        //    //PlayerPrefs.SetString("PlayerName", "Phaninder"); // PlayerName -> Phaninder
        //    //string playerName = PlayerPrefs.GetString("PlayerName");
        //    //Debug.Log("Player is :" + playerName);

        //    //PlayerPrefs.SetFloat("Version", 5.0f); // Version -> 5.0
        //    //float version = PlayerPrefs.GetFloat("Version");
        //    //Debug.Log("Version:" + version);

        //    //PlayerPrefs.SetInt("Date", 16); //Date -> 16
        //    //Debug.Log("Date:" + PlayerPrefs.GetInt("Date", -1));

    //}

    private void OnIncrementScore()
    {
        score++;
        Debug.Log("Current Score:" + score);
        scoreText.text = "Score: " + score;
    }

    private void OnRestart()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void OnGameOver()
    {
        int prevHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        gameOverCurrentScoreText.text = "Score: "+score.ToString();
        gameOverHighscoreText.text = "Highscore:"+ prevHighScore.ToString();
        
        if(score > prevHighScore)
        {
            //WE have new highscore
            gameOverHighscoreText.text = "New Highscore:" + score.ToString();
            PlayerPrefs.SetInt(HighScoreKey, score);
        }
    }
}
