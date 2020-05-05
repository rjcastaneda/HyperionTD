using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MapOne");
    }

    public void ExitGame()
    {
        Debug.Log("Game has Quit!");
        Application.Quit();
    }
}
