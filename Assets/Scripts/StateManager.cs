using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState;
    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine(){
        State nextState = currentState?.RunCurrent;

        if(nextState != null){
            SwitchToNext(nextState);
        }
    }
    private void SwitchToNext(State nextState){
        currentState = nextState;
    }
}
