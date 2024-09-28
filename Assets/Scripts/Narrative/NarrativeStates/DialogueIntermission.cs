using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "DialogueIntermission", menuName = "ScriptableObjects/Story/States/DialogueIntermission")]
public class DialogueIntermission : NarrativeState
{
    public MyEvent dialogueProgress;
    public override void OnEnterState() {
        base.OnEnterState();
        UserInputManager.playerInputs.Bacteria.MouseInteract.performed += progressDialogue;
        Experiment.pauseGame();
    }
    void progressDialogue(InputAction.CallbackContext obj) {
        dialogueProgress.invoke();
    }
    public override void OnLeavingState() {
        base.OnLeavingState();
        Experiment.unpauseGame();
        UserInputManager.playerInputs.Bacteria.MouseInteract.performed -= progressDialogue;
    }
}
