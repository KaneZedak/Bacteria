using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue/Dialogue")]
[System.Serializable]
public class DialogueGroup : ScriptableObject
{
    public Dialogue[] dialogues;
    private int index = 0;

    public void initialize() {
        index = 0;
    }
    public string getDialogue() {
        if(index >= dialogues.Length) return null;
        string text = dialogues[index].speaker.speakerName + ": " + dialogues[index].dialogueText;
        index++;
        return text;
    }

    public bool isComplete() {
        return index >= dialogues.Length;
    }
}
