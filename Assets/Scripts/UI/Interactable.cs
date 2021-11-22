using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public bool inRange;
    public KeyCode interactKey;
    public UnityEventQueueSystem interactAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange){
            if(Input.GetKeyDown(interactKey)){
                
            }
        }
    }
}
