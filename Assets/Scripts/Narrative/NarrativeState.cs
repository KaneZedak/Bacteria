using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NarrativeState", menuName = "ScriptableObjects/NarrativeState")]
[System.Serializable]
public class NarrativeState : ScriptableObject
{
    public delegate void StateTransition();
    private StateTransition callback;
    
    public UnityEvent onEnterEvent;
    public UnityEvent onLeaveEvent;
    public bool repeatable;
    public int triggerCount;

    public virtual void initialize() {
    }
    public virtual void setCallback(StateTransition functionCall) {
        callback = functionCall;
    }

    public virtual void OnEnterState() {
        onEnterEvent.Invoke();
        //triggerCount++;
    }

    public virtual void OnUpdate() {
    }

    public virtual void OnLeavingState() {
        onLeaveEvent.Invoke();
    }

    public virtual void stateFinished() {
        if(callback != null) callback();
    }
}
