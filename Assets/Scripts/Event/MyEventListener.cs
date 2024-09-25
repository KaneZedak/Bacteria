using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MyEventListener : MonoBehaviour
{
    [System.Serializable]
    public class EventTriggers {
        public MyEvent subscribedEvent;
        public UnityEvent unityEvent;
    }

    public EventTriggers[] subscribedEvents;

    void Start() {
        foreach(EventTriggers singleEvent in subscribedEvents) {
            singleEvent.subscribedEvent.subscribe(singleEvent.unityEvent.Invoke);
        }
    }


}
