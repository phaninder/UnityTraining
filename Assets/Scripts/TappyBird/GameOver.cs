using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject gameOverPanel;

    private void OnEnable()
    {
        GameEvents.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over";
    }

    public void OnRestartButtonPressed()
    {
        GameEvents.RestartGame?.Invoke();
        gameOverPanel.SetActive(false);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
