using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject skipButt;

    public GameObject[] popUps; // A place to drop all of the game key instructions
    private int popUpIndex = 0;
    public GameObject colliders;

    public Button SellButton;

    void Start()
    {
        Button btn = SellButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void Awake(){
        colliders = GameObject.Find("BirdBlue");
        if(colliders){
            Debug.Log("Found you!");
        }
    }


    private void Update()
    {
        // Want pop up instructions to be displayed in the game view
        for (int i = 0; i < popUps.Length; i++) // Wants to loop through each and every element in popUps array
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }

            else
            {
                popUps[i].SetActive(false);
            }

        }


        // If popUpIndex == 0, tutorial has just started

        if (popUpIndex == 0) // Detects movement [WASD]
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 1) // Detects [ Spacebar ] when collide with bird
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if(colliders.GetComponent<ShopTriggerCollider>().HasCollision()){
                popUpIndex++;
                }
            }

        }

        else if (popUpIndex == 2) // Detects[Spacebar]
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 3) // Detects movement [WASD]
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) // Needs to check if collide with NPC
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 4) // Detects C when collide with horse
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 5) // Checks whether stick is purchased
        {
            if (PlayerController.instance.GetStickAmt() > 0) 
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 6) // Detects C when collide with player's shop
        {
            if (Input.GetKeyDown(KeyCode.C)) 
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 7) // Detects[LEFT MOUSE CLICK]
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 8) // Detects[LEFT MOUSE CLICK]
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 9) // Detects[LEFT MOUSE CLICK]
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                skipButt.SetActive(false);
            }

        }

        else if (popUpIndex == 10) // Detects [ Spacebar ] and start game
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
                PlayerController.instance.SetBreadAmount(30);
                PlayerController.instance.SetInventoryAmount(0);
                SceneManager.LoadScene("StartMenu1");
                Debug.Log("Game is starting...");
            }

        }

    }

    public void SkipTutorial()
    {
        PlayerController.instance.SetBreadAmount(30);
        PlayerController.instance.SetInventoryAmount(0);
        SceneManager.LoadScene("StartMenu 1");
    }

}