using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerX : MonoBehaviour
{
    public bool gameOver;

    private int score;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverTitle;

    private float gravityModifier=1.5f;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        gameOver = false;
        score = 0;

        Physics.gravity *= gravityModifier;
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Physics.gravity /= gravityModifier;

        gameOver = true;
        gameOverTitle.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

