using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "DialogueIntermission", menuName = "ScriptableObjects/Story/States/DialogueIntermission")]
public class DialogueIntermission : NarrativeState
{
    public MyEvent dialogueProgress;
    public MyEvent textFinished;

    private bool dialogueFinishDisplaying;
    public bool canSkipDialogue;

    public override void initialize() {
        textFinished.subscribe(OnFinishDisplay);
    }

    public void OnFinishDisplay() {
        dialogueFinishDisplaying = true;
    }

    public override void OnEnterState() {
        base.OnEnterState();
        UserInputManager.playerInputs.Bacteria.MouseInteract.performed += tryProgressDialogue;
        Experiment.pauseGame();
    }

    public override void OnLeavingState() {
        base.OnLeavingState();
        Experiment.unpauseGame();
        UserInputManager.playerInputs.Bacteria.MouseInteract.performed -= tryProgressDialogue;
    }

    void tryProgressDialogue(InputAction.CallbackContext obj) {
        if(dialogueFinishDisplaying || canSkipDialogue) {
            dialogueFinishDisplaying = false;
            dialogueProgress.invoke();
        }
    }
}
