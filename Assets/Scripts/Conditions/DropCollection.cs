using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropCollection", menuName = "ScriptableObjects/Conditions/DropCollection", order = 4)]
public class DropCollection : ConditionObject
{
    public int numDropCollected = 0;
    public int dropLimit;
    public override void initialize() {
        value = false;
        numDropCollected = 0;
        MyEventSystem.dropletCollected += recordDrop;
    }

    void recordDrop() {
        numDropCollected += 1;
        if(numDropCollected >= dropLimit) {
            setValue(true);
        }
    }
    
}
