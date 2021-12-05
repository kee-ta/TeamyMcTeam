using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will sit on an object and allows us to trigger a dialogue
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    /*
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }
    }
    */
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
