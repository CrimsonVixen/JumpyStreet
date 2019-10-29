using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneScript : MonoBehaviour
{
    public Text highScoreTable;

    public void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            highScoreTable.text = HighScoreManager._instance.highScores[i].ToString();
        }
    }
}
