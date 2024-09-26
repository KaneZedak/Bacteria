using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "helloState", menuName = "Testing/helloState")]
public class helloState : NPCState
{
    public override void OnUpdate() {
        Debug.Log(((testNPCVariables)npcVariables).a);
    }
}
