using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memo : MonoBehaviour
{
    public TMP_Text note;
    
    public MemoNote[] noteList;
    //public ConditionList conditionList;

    public enum Condition {PlayerDeath, DropCollected, GameStart, Starvation}
    /*
    private Dictionary<Condition, bool> conditionValue = new Dictionary<Condition, bool>();*/
    //private Dictionary<MemoNote, bool> noteTriggered = new Dictionary<MemoNote, bool>();
    

    void Awake() {
        /*
        MyEventSystem.playerDeath += setPlayerDeath;
        MyEventSystem.playerDeath += countStarvation;
        MyEventSystem.dropletCollected += setDropCollect;*/
        //MyEventSystem.OnConditionUpdate += checkCondition;
        /*
        foreach(MemoNote note in noteList) {
            noteTriggered[note] = false;
        }*/
        foreach(MemoNote singleNote in noteList) {
            singleNote.initialize();
            singleNote.addNote(displayText);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*
    void checkCondition() {
        foreach(MemoNote note in noteList) {
            bool displayNote = true;
            foreach(EventCondition noteCondition in note.conditions) {
                if(noteCondition.value != noteCondition.condition.value) {
                    displayNote = false;
                    break;
                }
            }
            if(displayNote && !noteTriggered[note]) {
                noteTriggered[note] = true;
                displayText(note.text);
            }
        }
        
    }*/

    void displayText(string message) {
        if(note != null) {
            note.text = message;
        }
    }

    /*
    void updateCondition(Condition conditionName, bool value)
    {
        conditionValue[conditionName] = value;
        checkCondition();
    }
    
    void setPlayerDeath() {
        updateCondition(Condition.PlayerDeath, true);
    }

    void countStarvation() {
        starvationCounter += 1;
        if(starvationCounter >= starvationLimit) updateCondition(Condition.Starvation, true);
            
    }
    
    void setDropCollect() {
        updateCondition(Condition.DropCollected, true);
        starvationCounter = 0;
    }*/
}
