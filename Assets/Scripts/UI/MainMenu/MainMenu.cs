using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private Player _player;

    public GameObject mainMenuUI;
    public GameObject mapSelectUI;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        _saveSystem = GameObject.Find("Player").GetComponent<SaveSystem>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        _saveSystem.LoadData();
    }

    public void StartGame()
    {
        mapSelectUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CreditsReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Debug.Log("Game has Quit!");
        Application.Quit();
    }

    public void ReturnButton()
    {
        mapSelectUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void MapOneButton()
    {
        SceneManager.LoadScene("MapOne");
    }

    public void MapTwoButton()
    {
        SceneManager.LoadScene("MapTwo");
    }

    public void OnHoverEnterMapOne()
    {
        waveText.text = _player._playerData.mapOneHighestWave.ToString("D4");
        scoreText.text = _player._playerData.mapOneHighScore.ToString("D12");
    }


    public void OnHoverEnterMapTwo()
    {
        waveText.text = _player._playerData.mapTwoHighestWave.ToString("D4");
        scoreText.text = _player._playerData.mapTwoHighScore.ToString("D12");
    }

    public void OnHoverExit()
    {
        waveText.text = "0000";
        scoreText.text = "000000000000";
    }
}
