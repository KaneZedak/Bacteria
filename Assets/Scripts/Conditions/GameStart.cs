using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStart", menuName = "ScriptableObjects/Conditions/GameStart", order = 2)]
public class GameStart : ConditionObject
{
    public override void initialize()
    {
        value = false;
    }

}
