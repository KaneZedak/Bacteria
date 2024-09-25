using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //public NarrativeState[] stateList;
    //[SerializeField] private int stateIndex = 0;
    public NarrativeState[] stateList;
    [SerializeField] private NarrativeStateMachine stateMachine;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new NarrativeStateMachine();
        stateMachine.stateList = stateList;
        stateMachine.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.OnUpdate();
    }

    public void nextNarrativeState() {
        stateMachine.nextState();
    }
}
