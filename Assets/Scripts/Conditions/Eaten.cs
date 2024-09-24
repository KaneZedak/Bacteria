using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Eaten", menuName = "ScriptableObjects/Conditions/Eaten")]
public class Eaten : ConditionObject
{
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
        base.initialize();
        MyEventSystem.BeingEaten += recordEaten;
    }

    void recordEaten() {
        if(value != true) setValue(true);
    }

    // Update is called once per frame
    
}
