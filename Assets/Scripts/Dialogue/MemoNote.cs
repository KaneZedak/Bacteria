using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Note", menuName = "ScriptableObjects/Note", order = 1)]
public class MemoNote : ScriptableObject
{
    public delegate void noteText(string displayText);
    noteText subscriber;
    public string text;
    
    public EventCondition[] allConditions;
    private ConditionChecker conditions;

    public void initialize() {
        conditions = new ConditionChecker();
        conditions.initConditions(allConditions);
        conditions.subscribe(displayNote);
    }

    public void addNote(noteText caller) {
        subscriber = caller;
    }

    public void displayNote() {
        subscriber(text);
    }
}
