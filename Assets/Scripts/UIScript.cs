using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject gameOverWindow;
    public GameObject scoreText;

    private int score;

    private static UIScript _instance;

    public static UIScript Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    { 


        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            scoreText.GetComponent<Text>().text = score.ToString();
        }
        else
        {
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

    public void OnHighScoreButtonClick()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void GameOver(int scoreToSave)
    {
        score = scoreToSave;
        SceneManager.LoadScene("GameOverScene");
        //gameOverWindow.SetActive(true);
        //scoreText.GetComponent<Text>().text = score.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.GetComponent<Text>().text = score.ToString();

    }


}
