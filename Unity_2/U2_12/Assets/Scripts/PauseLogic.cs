using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PausePanel;

    public GameObject SettingsPanel;

    public void ResumeGame()
    {
        IsGamePaused = false;
        Time.timeScale = 1f; 
        PausePanel.SetActive(IsGamePaused);
    }

    public void PauseGame()
    {
        IsGamePaused = true;
        Time.timeScale = 0;
        PausePanel.SetActive(IsGamePaused);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
