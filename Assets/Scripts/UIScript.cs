using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject scorePanel;
    public GameObject scoreText;
    public GameObject gameOverWindow;
    public GameObject gameOverScoreText;
    public GameObject highScoreTable;

    public GameObject HighScoreManager;

    private int score;
    private string highScoreString;
    private List<int> highScores = new List<int>();

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

        scorePanel.SetActive(true);
        gameOverWindow.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            highScores.Add(HighScoreManager.GetComponent<HighScoreManager>().highScores[i]);
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
        gameOverWindow.SetActive(true);
        scorePanel.SetActive(false);
        gameOverScoreText.GetComponent<Text>().text = scoreToSave.ToString();
        for (int i = 0; i < 10; i++)
        {
            if (highScores[i] < scoreToSave)
            {
                highScores.Add(scoreToSave);                
            }
        }
        highScores.Sort();
        foreach (int i in highScores)
        {
            highScoreTable.GetComponent<Text>().text = i.ToString();
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();

    }



}
