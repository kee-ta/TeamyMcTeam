using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps; // A place to drop all of the game key instructions
    private int popUpIndex;

    private void Update()
    {
        // Want pop up instructions to be displayed in the game view
        for (int i = 0; i < popUps.Length; i++) // Wants to loop through each and every element in popUps array
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }

            else
            {
                popUps[popUpIndex].SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }

        }

    }



}
