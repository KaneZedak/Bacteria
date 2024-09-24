using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BacteriaCatch", menuName = "ScriptableObjects/Conditions/BacteriaCatch")]
public class BacteriaCatch : ConditionObject
{
    public override void initialize() {
        base.initialize();
        MyEventSystem.OnBacteriaCatch += recordCatch;
    }

    void recordCatch() {
        if(value != true) setValue(true);
    }
    
}
