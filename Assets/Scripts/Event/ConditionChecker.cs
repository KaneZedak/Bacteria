using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConditionChecker", menuName = "ScriptableObjects/EventAndConditions/ConditionChecker")]
[System.Serializable]
public class ConditionChecker : MyEvent
{
    public EventCondition[] conditions;
    public bool repeatedTrigger = false;
    private bool triggered = false;

    public void initConditions(EventCondition[] allConditions) {
        /*
        if(conditions != null) {
            foreach(EventCondition cond in conditions) {
                cond.conditionObj.unsubscribe(checkAllConditions);
            }
        }*/
        conditions = allConditions;
        initialize();
    }
    public void initialize() {
        foreach(EventCondition condition in conditions) {
            condition.conditionObj.subscribe(checkAllConditions);
        }
    }

    public void checkAllConditions() {
        bool allConditionSatisfied = true;
        foreach(EventCondition cond in conditions) {
            if(!cond.isConditionTriggered()) {
                allConditionSatisfied = false;
                break;
            }
        }
        if(allConditionSatisfied) {
            if(repeatedTrigger || (!triggered)) {
                invoke();
                triggered = true;
            }
        }
    }
}
