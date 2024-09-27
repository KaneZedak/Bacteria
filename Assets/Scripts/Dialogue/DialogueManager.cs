using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogueManager : MonoBehaviour
{
    public MyEvent progressDialogue;
    public MyEvent textFinishDisplaying;
    public delegate void displayText(string text);
    public static displayText showText;

    public delegate void callback();
    public static callback OnDialogueFinish;

    public DialogueGroup[] dialogueGroups;
    public DialogueGroup currentDialogueGroup;
    private int index;

    public UnityEvent afterFinishing;

    private static bool automatic = false;
    public float waitTime = 2;

    public static void setAutomaticProgression(bool value) {
        automatic = value;
    }

    void Start() {
        index = 0;
        currentDialogueGroup.initialize();
        /*
        foreach(DialogueGroup dgg in dialogueGroups) {
            dgg.initialize();
        }*/
        progressDialogue.subscribe(displayDialogue);
        textFinishDisplaying.subscribe(afterTextFinish);
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

    public void afterTextFinish() {
        if(automatic) {
            StartCoroutine(displayNextDialogue());
        }
    }

    IEnumerator displayNextDialogue() {
        yield return new WaitForSeconds(waitTime);
        progressDialogue.invoke();
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
