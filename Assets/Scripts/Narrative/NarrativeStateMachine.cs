using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NarrativeStateMachine: ScriptableObject
{
    public NarrativeState[] stateList;
    [SerializeField] private int stateIndex = 0;
    
    public void initialize() {
        foreach(NarrativeState state in stateList) {
            state.setCallback(nextState);
        }
    }
    public void OnUpdate()
    {
        stateList[stateIndex].OnUpdate();
    }

    public void nextState() {
        if(stateIndex < stateList.Length - 1) stateIndex++;
    }

    public void previousState() {
        if(stateIndex > 0) stateIndex--;
    }
}
