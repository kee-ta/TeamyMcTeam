using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Show up in inspector for editing

public class Dialogue
{
    public string name; //Name of NPC we are dealing with

    [TextArea(3,10)] //Amount of lines the text area will use
    public string[] sentences; //Sentences we will load into Queue
}
