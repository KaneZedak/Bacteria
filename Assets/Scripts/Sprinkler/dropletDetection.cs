using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropletDetection : MonoBehaviour
{
    public ConditionChecker checker;
    public MyUnityEvent dropCollected;

    void Start() {
        checker.initialize();
        checker.subscribe(dropCollected.Invoke);
    }
}
