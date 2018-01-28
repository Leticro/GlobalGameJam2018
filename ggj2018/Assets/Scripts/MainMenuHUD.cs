using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHUD : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(startClick);
        exitButton.onClick.AddListener(exitClick);
    }

    void startClick()
    {
        SceneManager.LoadScene("intro");
    }

    void exitClick()
    {
        Application.Quit();
    }
}
    
