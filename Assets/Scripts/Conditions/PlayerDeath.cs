using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDeath", menuName = "ScriptableObjects/Conditions/PlayerDeath", order = 3)]
public class PlayerDeath : ConditionObject
{
    public override void initialize() {
        value = false;
        MyEventSystem.playerDeath += recordPlayerDeath;
    }

    public void recordPlayerDeath() {
        Experiment.updateCondition(this, true);
    }
}
