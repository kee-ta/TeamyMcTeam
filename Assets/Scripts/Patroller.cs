using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{

        //Reference to waypoints
    public Transform[] waypoints;
    public float speed = 5;

    private int wayIndex;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        wayIndex=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,waypoints[wayIndex].position);
        if(distance < 1.0f){
            IncrementIndex();
        }
        Patrol();
    }

    void Patrol(){
         transform.position = Vector2.MoveTowards(transform.position,waypoints[wayIndex].position,speed*Time.deltaTime);
        
    }

    void IncrementIndex(){
        wayIndex++;
        if(wayIndex>=waypoints.Length){
            wayIndex = 0;
        }
        
    }
}
