using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    public int score;
    public long waves;
    public PlayerData _playerData;
    public void SetDefaults()
    {
        health = 30;
        score = 0;
        waves = 0;
    }

    public void UpdateScores()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "MapOne")
        {
            if(score > _playerData.mapOneHighScore)
            {
                _playerData.mapOneHighScore = score;
            }

            if(waves > _playerData.mapOneHighestWave)
            {
                _playerData.mapOneHighestWave = waves;
            }
        }

        if (scene.name == "MapTwo")
        {
            if (score > _playerData.mapTwoHighScore)
            {
                _playerData.mapTwoHighScore = score;
            }

            if (waves > _playerData.mapOneHighestWave)
            {
                _playerData.mapTwoHighestWave = waves;
            }
        }
    }
}
