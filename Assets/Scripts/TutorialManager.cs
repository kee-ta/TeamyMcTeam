using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps; // A place to drop all of the game key instructions
    private int popUpIndex = 0;
    public GameObject colliders;
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

        if (popUpIndex == 0) // If popUpIndex == 0, tutorial has just started
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Needs to check if collides with NPC
            {
                if(colliders.GetComponent<ShopTriggerCollider>().HasCollision()){
                popUpIndex++;
                }
            }

        }

        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Needs to check if collide with NPC
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 5)
        {
            if (PlayerController.instance.GetStickAmt() > 0) // Detects left mouse click
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.C)) 
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 7)
        {
            if (Input.GetMouseButtonDown(0)) // Detects left mouse click
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 8)
        {
            if (Input.GetMouseButtonDown(0)) // Detects left mouse click
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 9)
        {
            if (Input.GetMouseButtonDown(0)) // Detects left mouse click
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 10)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
                PlayerController.instance.SetBreadAmount(30);
                SceneManager.LoadScene("StartMenu1");
                Debug.Log("Game is starting...");
            }

        }

    }



}
