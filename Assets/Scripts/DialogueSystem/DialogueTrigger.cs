using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will sit on an object and allows us to trigger a dialogue
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }   
    }

}
