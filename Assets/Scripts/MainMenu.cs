using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Allows us to change scenes in Unity

public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the next level in the queue
    }

    public void QuitGame()
    {
        Application.Quit(); // Close down the program
    }

    public void VictoryScreen()
    {
        //Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene("Victory");
    }

    public void DefeatScreen()
    {
        //Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene("Defeat");
    }

    public void CreditsScreen()
    {
        //Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene("Credits");
    }

    public void MainScreen()
    {
        //Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene("MainMenu");
    }

}
