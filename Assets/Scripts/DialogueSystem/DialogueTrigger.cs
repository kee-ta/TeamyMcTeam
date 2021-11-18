using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script sits on an object and allows us to trigger a new dialogue.
public class DialogueTrigger : MonoBehaviour 
{
    public Dialogue dialogue;

    public void TriggerDialogue() //Feed variable to Dialogue Manager
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
