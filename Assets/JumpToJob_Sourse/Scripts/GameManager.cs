using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverTitle;

    public bool gameStart;
    public bool gameOver;

    private float gravityModifier = 3;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        gameStart = false;
        gameOver = false;

        Physics.gravity *= gravityModifier;
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            Physics.gravity /= gravityModifier;
        }
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
