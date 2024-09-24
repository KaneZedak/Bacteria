using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "condition_list", menuName = "ScriptableObjects/ConditionList", order = 3)]
public class ConditionList : ScriptableObject
{
    public ConditionObject[] conditionList;

    public void initializeConditions() {
        foreach(ConditionObject condition in conditionList) {
            condition.initialize();
        }
    }
}
