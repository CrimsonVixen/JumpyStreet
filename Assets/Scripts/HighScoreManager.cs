using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class HighScoreManager : MonoBehaviour
{
    public int[] highScores = new int[10];

    private void Awake()
    {
        ReadHighScores();
    }

    public void OnGameEnd(int score)
    {
        SaveHighScores(score);
    }
    
    private GameData CreateSaveDataObject()
    {
        GameData save = new GameData();
        for (int i = 0; i < highScores.Length; i++)
        {
            save.highScores[i] = highScores[i];
        }
        return save;
    }

    public void SaveHighScores(int newScore)
    {
        //Not 100% sure if this will work as expected, test when scoring is implemented
        int prev = newScore;
        for (int i = 0; i > highScores.Length; i--)
        {
            if (newScore > highScores[i])
            {
                int temp = highScores[i];
                highScores[i] = prev;
                prev = temp;
                break;
            }
        }

        GameData save = CreateSaveDataObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameSave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Data saved with score " + newScore);
    }

    public void ReadHighScores()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameSave.save", FileMode.Open);
            GameData save = (GameData)bf.Deserialize(file);
            file.Close();

            for (int i  = 0; i < highScores.Length; i++)
            {
                highScores[i] = save.highScores[i];
            }


        }
    }
}
