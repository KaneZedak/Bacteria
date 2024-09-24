using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "condition", menuName = "ScriptableObjects/ConditionObject", order = 2)]
public class ConditionObject : ScriptableObject
{
    public bool value;

    public void setValue(bool value) {
        this.value = value;
        if(MyEventSystem.OnConditionUpdate != null) MyEventSystem.OnConditionUpdate();
    }

    public virtual void initialize() {
        value = false;
    }
}
