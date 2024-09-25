using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventSystem : MonoBehaviour
{
    public delegate void Handler();
    public static Handler playerDeath;
    public static Handler playerRespawn;
    public static Handler dropletCollected;
    public static Handler OnConditionUpdate;
    public static Handler OnBacteriaCatch;
    public static Handler BeingEaten;

    public MyEvent onPlayerDeath;
    public MyEvent dropCollected;
    public MyEvent bacteriaCatch;
    public MyEvent eaten;

    void Awake() {
        playerDeath += onPlayerDeath.invoke;
        dropletCollected += dropCollected.invoke;
        OnBacteriaCatch += bacteriaCatch.invoke;
        BeingEaten += eaten.invoke;
    }
        


}
