using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogueManager : MonoBehaviour
{
    public MyEvent progressDialogue;
    public delegate void displayText(string text);
    public static displayText showText;
    public DialogueGroup[] dialogueGroups;
    public DialogueGroup currentDialogueGroup;
    private int index;
    public UnityEvent afterFinishing;

    void Start() {
        index = 0;
        currentDialogueGroup.initialize();
        /*
        foreach(DialogueGroup dgg in dialogueGroups) {
            dgg.initialize();
        }*/
        progressDialogue.subscribe(displayDialogue);
    }

    
    public void displayDialogue() {
        if(currentDialogueGroup.isComplete()) {
            afterFinishing.Invoke();
            return;
        }
        if(showText != null) {
            showText(currentDialogueGroup.getDialogue());
        }
    }

    public void setDialogueGroup(DialogueGroup newDialogueGroup) {
        currentDialogueGroup = newDialogueGroup;
        currentDialogueGroup.initialize();
    }


    /*
    public bool paragraphCompleted() {
        return dialogueGroups[index].isComplete();
    }

    public void nextParagraph() {
        if(index < dialogueGroups.Length - 1) index++;
    }*/
}
