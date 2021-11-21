using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    // Making the Visual Cue show up only when the player is in bound with the BoxCollider
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue; // Shows up in the Inspector

    // Listen if the player presses the Interact Button
    // Call Dialogue Manager with the appropriate inkJSON file
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange; // Keeps track if the player is in range

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false); // Inactive visualCue = hide at the start of the game
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager2.GetInstance().dialogueIsPlaying) // Shows the visualCue only when the player is in range
        {
            visualCue.SetActive(true); // Shows visualCue
            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager2.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false); // Hides visualCue
        }
    }

    // Detects whether another collider enters or exits the collider of the GameObject that this script is attached to
    // Needs to make sure that the other collider belongs to the player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

}
