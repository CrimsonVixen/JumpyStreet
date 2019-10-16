using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneScript : MonoBehaviour
{
    public HighScoreManager HighScoreManager;
    public UIScript UIScript;

    public Text highScoreTable;



    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            highScoreTable.text = HighScoreManager.Instance.highScores[i].ToString();
        }
    }

    
}
