using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "helloState", menuName = "Testing/helloState")]
public class helloState : NarrativeState
{
    public override void OnUpdate() {
        Debug.Log("hello");
    }
}
