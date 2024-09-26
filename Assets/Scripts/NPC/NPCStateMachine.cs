using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateMachine : NarrativeStateMachine
{
    protected NPCVariableSheet npcVariables;

    public void setNPCVariable(NPCVariableSheet variables) {
        npcVariables = variables;
    }

    public void initialize() {
        for(int i = 0; i < stateList.Length;i++) {
            stateList[i] = Instantiate(stateList[i]);
        }
        base.initialize();
    }
}
