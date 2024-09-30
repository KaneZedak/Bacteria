using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "PlayerExploration", menuName = "ScriptableObjects/Story/States/PlayerExploration")]
public class PlayerExploration : NarrativeState
{
    public ConditionObject killedNanocell;
    public PlayerGameAction basicMove;

    public override void OnEnterState() {
        if(basicMove.isActive()) {
            basicMove.enableAction();
        }
        DialogueManager.setAutomaticProgression(true);
    }

    public override void OnLeavingState() {
        DialogueManager.setAutomaticProgression(false);
    }
}
