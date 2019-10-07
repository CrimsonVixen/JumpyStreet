using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject gameOverWindow;
    public GameObject scoreText;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            gameOverWindow = GameObject.FindGameObjectWithTag("GameOverWindow");
            scoreText = GameObject.FindGameObjectWithTag("ScoreText");
            gameOverWindow.SetActive(false);
        }
    }

    public void OnStartButtonClick()
    {
        //Change scene name to whatever the completed game scene is
        SceneManager.LoadScene("GameScene");
    }

    public void OnHelpButtonClick()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(int score)
    {
        gameOverWindow.SetActive(true);
        scoreText.GetComponent<Text>().text = score.ToString();
    }


}
