using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateSystem : MonoBehaviour
{
    private Player _player;
    private SaveSystem _saveSystem;

    [Header("Game States")]
    public bool gameOver;
    public bool gamePaused;
    public bool levelCompleted;

    [Header("UI")]
    public GameObject pauseMenuUI;
    public GameObject GameOverUI;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _saveSystem = GameObject.Find("Player").GetComponent<SaveSystem>();
        _player.SetDefaults();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if (!gamePaused) { PauseGame(); }
            else { ResumeGame(); }
        }

        if (_player.health <= 0)
        {
            GameOver();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        _player.SetDefaults();
        _saveSystem.SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _player.UpdateScores();
        _saveSystem.SaveData();
        GameOverUI.SetActive(true);
        gameOver = true;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        _player.UpdateScores();
        _saveSystem.SaveData();
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
