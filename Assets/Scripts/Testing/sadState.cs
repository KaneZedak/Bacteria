using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sadState", menuName = "Testing/sadState")]
public class sadState : NarrativeState
{
    public override void OnUpdate() {
        Debug.Log("crying");
    }
}
