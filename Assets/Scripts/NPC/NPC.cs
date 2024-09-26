using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //public NarrativeState[] stateList;
    //[SerializeField] private int stateIndex = 0;
    public NarrativeState[] stateList;
    [SerializeField] private NPCStateMachine stateMachine;

    void Awake() {
        stateMachine = new NPCStateMachine();
        stateMachine.stateList = stateList;
        stateMachine.initialize();
        stateList = stateMachine.stateList;
    }
    // Start is called before the first frame update
    void Start()
    {

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
