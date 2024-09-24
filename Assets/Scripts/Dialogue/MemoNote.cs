using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Note", order = 1)]
public class MemoNote : ScriptableObject
{
    [System.Serializable]
    public class EventCondition
    {
        public ConditionObject condition;
        public bool value;
    }
    public string text;
    
    public EventCondition[] conditions;
    
}
