using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Starvation", menuName = "ScriptableObjects/Conditions/Starvation", order = 1)]
public class Starvation : ConditionObject
{
    public int starvationCounter;
    public int starvationLimit;
    
    // Start is called before the first frame update
    /*
    void Awake() {
        MyEventSystem.playerDeath += recordStarvation;
        MyEventSystem.dropletCollected += resetStarvation;
    }
    void Start()
    {
        starvationCounter = 0;
    }*/

    public override void initialize() {
        value = false;
        MyEventSystem.playerDeath += recordStarvation;
        MyEventSystem.dropletCollected += resetStarvation;
        starvationCounter = 0;
    }

    void recordStarvation() {
        starvationCounter += 1;
        if(starvationCounter >= starvationLimit) {
            Experiment.updateCondition(this, true);
        }
    }
    
    void resetStarvation() {
        starvationCounter = 0;
    }
    // Update is called once per frame
    
}
