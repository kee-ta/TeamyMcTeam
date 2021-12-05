using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

// Make the class serializable to show up in the Inspector so that we can edit it
[System.Serializable]

public class Dialogue
{
    // An object that we can pass into the DialogueManager whenever we want to start a new dialogue
    // Hosts all information that we need about a single dialogue

    public string name; // Name of the NPC we are talking with

    // Makes space for longer sentences
    [TextArea(3,10)] // Minimum amount of lines, Maximum amount of lines

    public string[] sentences; // Sentences that we will load into our queue

    public Sprite Character; // Image of NPC we are talking with
}
