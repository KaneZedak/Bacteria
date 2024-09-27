using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "PlayerExploration", menuName = "ScriptableObjects/Story/States/PlayerExploration")]
public class PlayerExploration : NarrativeState
{
    public ConditionObject killedNanocell;

    public override void OnEnterState() {
        DialogueManager.setAutomaticProgression(true);
    }

    public override void OnLeavingState() {
        DialogueManager.setAutomaticProgression(false);
    }
}
