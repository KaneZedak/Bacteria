using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventSystem
{
    public delegate void Handler();
    public static Handler playerDeath;
    public static Handler playerRespawn;
    public static Handler dropletCollected;
    public static Handler OnConditionUpdate;
    public static Handler OnBacteriaCatch;
    public static Handler BeingEaten;
}
