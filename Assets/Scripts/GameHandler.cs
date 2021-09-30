using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    private void Awake(){
        SoundManager.Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
