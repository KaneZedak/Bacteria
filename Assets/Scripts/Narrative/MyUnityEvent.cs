using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyUnityEvent
{
    public bool repeatable;
    public UnityEvent followingActions;
    private bool triggered;
    
    public void Invoke() {
        if(!triggered || repeatable) {
            triggered = true;
            followingActions.Invoke();
        }
    }
}
