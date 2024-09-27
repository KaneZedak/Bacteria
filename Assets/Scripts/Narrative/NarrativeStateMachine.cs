using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeStateMachine", menuName = "ScriptableObjects/NarrativeStateMachine")]
[System.Serializable]
public class NarrativeStateMachine: ScriptableObject
{
    public NarrativeState[] stateList;
    public MyEvent stateCompleted;
    public NarrativeState startingState;
    private NarrativeState currentState;
    [SerializeField] private int stateIndex = 0;
    
    public void initialize() {
        foreach(NarrativeState state in stateList) {
            state.setCallback(nextState);
        }
        stateCompleted.subscribe(nextState);
        currentState = startingState;
    }
    
    public void startNarrative() {
        currentState.OnEnterState();
    }
    public void OnUpdate()
    {
        currentState.OnUpdate();
    }

    public void transitionToState(NarrativeState newState) {
        currentState.OnLeavingState();
        currentState = newState;
        currentState.OnEnterState();
    }
    public void nextState() {
        if(stateIndex >= stateList.Length) return;
        stateList[stateIndex].OnLeavingState();
        if(stateIndex < stateList.Length - 1) stateIndex++;
        stateList[stateIndex].OnEnterState();
    }

    public void previousState() {
        if(stateIndex <= 0) return;
        stateList[stateIndex].OnLeavingState();
        if(stateIndex > 0) stateIndex--;
        stateList[stateIndex].OnEnterState();
    }
}
