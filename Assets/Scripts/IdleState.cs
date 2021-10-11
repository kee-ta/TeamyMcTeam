using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public bool inConvo;
    public PatrolState patrolState;

    public override State RunCurrent()
    {
        if(inConvo){
            return this;
        }
        else{return patrolState;}
    }
}
