using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public GameObject _Player;

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(filePath, FileMode.Create);
        PlayerData data = _Player.GetComponent<Player>()._playerData;
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/player.data";
        if(File.Exists(filePath))
        {
            Debug.Log("file exists" + filePath);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            PlayerData currentData = _Player.GetComponent<Player>()._playerData;
            currentData.mapOneHighestWave = data.mapOneHighestWave;
            currentData.mapOneHighScore = data.mapOneHighScore;
            currentData.mapTwoHighestWave = data.mapTwoHighestWave;
            currentData.mapTwoHighScore = data.mapTwoHighScore;
            return;
        }
        else
        {
            Debug.Log("No Save File " + filePath);
            return;
        }
    }
}

