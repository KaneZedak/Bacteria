using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "condition", menuName = "ScriptableObjects/ConditionObject", order = 2)]
public class ConditionObject : MyEvent
{
    public bool value;

    public void setValue(bool value) {
        this.value = value;
        invoke();
    }

    public bool getValue() {
        return this.value;
    }
    public virtual void initialize() {
        value = false;
    }
}
