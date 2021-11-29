using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{    
    public bool inConvo;
    public IdleState idleState;

    public override State RunCurrent()
    {
        if(inConvo){
            return idleState;
        }
        else{
            return this;
        }
    }
}
