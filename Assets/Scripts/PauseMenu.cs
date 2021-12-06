using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // A variable to keep track of whether or not our game is currently paused
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }

    }

    // Bring down pause menu
    // Set time back to normal
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Disable pause menu
        Time.timeScale = 1f; // Time back to normal rate
        GameIsPaused = false;
    }

    // Bring up pause menu
    // Freeze time in game
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Enable pause menu
        Time.timeScale = 0f; // Completely freeze the game
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
