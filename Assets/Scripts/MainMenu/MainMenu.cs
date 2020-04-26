using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Button startButton;
    Button HTPButton;
    Button exitButton;

    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        HTPButton = GameObject.Find("HTPButton").GetComponent<Button>();
    }
}
