using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventCondition
{
    public ConditionObject conditionObj;
    public bool value;

    public bool isConditionTriggered() {
        return value == conditionObj.value;
    }
}
