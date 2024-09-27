using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeState", menuName = "ScriptableObjects/NarrativeState")]
public class NarrativeState : ScriptableObject
{
    public delegate void StateTransition();
    private StateTransition callback;
    
    public virtual void setCallback(StateTransition functionCall) {
        callback = functionCall;
    }

    public virtual void OnEnterState() {

    }

    public virtual void OnUpdate() {
    }

    public virtual void OnLeavingState() {

    }

    public virtual void stateFinished() {
        if(callback != null) callback();
    }
}
