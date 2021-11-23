using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public GameObject CurrentScene;
    public GameObject NextScene;

    // Start is called before the first frame update
    public void SceneNext()
    {
        CurrentScene.SetActive(false);
        NextScene.SetActive(true);
    }

    public void ToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the next level in the queue
    }

}
