using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/GameEvent", order = 1)]
public class MyEvent : ScriptableObject
{
    private MyEventListener[] listeners;
    public delegate void Handler();
    Handler eventHandler;
    

    public void subscribe(Handler func) {
        eventHandler += func;
    }
    public void unsubscribe(Handler func) {
        eventHandler -= func;
    }
    public void invoke() {
        if(eventHandler != null) eventHandler();
    }

}
