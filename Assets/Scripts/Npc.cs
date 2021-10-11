using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    Vector2 startPos;
    int id;
    string npcName;
    Dialogue[] dialogues;
    public Npc(){
        id = -1;
        npcName = "Debug NPCno";
    }
    

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


